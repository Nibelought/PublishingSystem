using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Publishing; // For LoginForm
using PublishingSystem.UI.Helpers; // For dgv sort

namespace PublishingSystem.UI
{
    public partial class EditorDashboardForm : Form
    {
        private readonly User _currentUser;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        // Эти контролы должны быть созданы в EditorDashboardForm.Designer.cs
        // private System.Windows.Forms.DataGridView dataGridViewAvailableBooks;
        // private System.Windows.Forms.DataGridView dataGridViewMyBooks;
        // private System.Windows.Forms.Button btnAssignToMe;
        // private System.Windows.Forms.Button btnSetStatusEditing;
        // private System.Windows.Forms.Button btnChangeAgeRestriction;
        // private System.Windows.Forms.Button btnReleaseBook;
        // private System.Windows.Forms.Button btnRefreshLists;
        // private System.Windows.Forms.MenuStrip menuStrip1; (или menuStripUser, если программно)

        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;
        private ToolStripMenuItem menuItemRefreshLists;

        public EditorDashboardForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _bookService = new BookService();
            _userService = new UserService();

            InitializeUserMenu();
            SetupDataGridViews();
            RefreshAllBookLists(); // Initial load
            
            if (this.dataGridViewAvailableBooks != null)
            {
                this.dataGridViewAvailableBooks.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }
            if (this.dataGridViewMyBooks != null)
            {
                this.dataGridViewMyBooks.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }

            // Wire up events (ensure buttons are not null, meaning they exist in Designer.cs)
            if (this.btnAssignToMe != null) this.btnAssignToMe.Click += BtnAssignToMe_Click;
            if (this.btnSetStatusEditing != null) this.btnSetStatusEditing.Click += BtnSetStatusEditing_Click;
            if (this.btnChangeAgeRestriction != null) this.btnChangeAgeRestriction.Click += BtnChangeAgeRestriction_Click;
            if (this.btnReleaseBook != null) this.btnReleaseBook.Click += BtnReleaseBook_Click;

            if (this.dataGridViewAvailableBooks != null) this.dataGridViewAvailableBooks.SelectionChanged += (s,e) => UpdateButtonStates();
            if (this.dataGridViewMyBooks != null) this.dataGridViewMyBooks.SelectionChanged += (s,e) => UpdateButtonStates();
            
            UpdateButtonStates();
        }

        private void InitializeUserMenu()
        {
            // Assuming menuStrip1 is added via the designer and is the main menu for the form
            if (this.menuStrip1 == null)
            {
                // Этого не должно происходить, если menuStrip1 добавлен в дизайнере.
                // Но как запасной вариант, можно создать его здесь,
                // хотя это указывает на проблему с Designer.cs.
                MessageBox.Show("Warning: menuStrip1 was not found from the designer. Creating it programmatically.", "Menu Warning");
                this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                this.menuStrip1.Name = "menuStripFallback";
                this.menuStrip1.Dock = DockStyle.Top;
                this.Controls.Add(this.menuStrip1); // Добавляем на форму
                this.MainMenuStrip = this.menuStrip1; // Устанавливаем как главное меню формы
            }

            this.menuItemUserActions = new ToolStripMenuItem();
            this.menuItemChangePassword = new ToolStripMenuItem();
            this.menuItemChangeProfile = new ToolStripMenuItem();
            this.menuItemRefreshLists = new ToolStripMenuItem(); // Создаем новый пункт
            this.menuItemLogout = new ToolStripMenuItem();

            // 3. Настраиваем menuItemUserActions (главный пункт с именем пользователя)
            this.menuItemUserActions.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
            this.menuItemUserActions.Name = "menuItemUserActionsDynamic"; // Уникальное имя для отладки
            this.menuItemUserActions.Alignment = ToolStripItemAlignment.Right; // Чтобы он был справа на MenuStrip

            // 4. Настраиваем подпункты и добавляем их в menuItemUserActions
            // Change Password
            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Name = "menuItemChangePasswordDynamic";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemUserActions.DropDownItems.Add(this.menuItemChangePassword);

            // Change Name/Surname
            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Name = "menuItemChangeProfileDynamic";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemUserActions.DropDownItems.Add(this.menuItemChangeProfile);

            // Refresh Lists (F5) - НОВЫЙ ПУНКТ
            this.menuItemRefreshLists.Text = "Refresh Lists (F5)";
            this.menuItemRefreshLists.Name = "menuItemRefreshListsDynamic";
            this.menuItemRefreshLists.ShortcutKeys = Keys.F5;
            this.menuItemRefreshLists.ShowShortcutKeys = true; // Чтобы отображалась (F5)
            this.menuItemRefreshLists.Click += (sender, e) => RefreshAllBookLists(); // Привязываем к вашему методу обновления
            this.menuItemUserActions.DropDownItems.Add(this.menuItemRefreshLists);

            // Separator
            this.menuItemUserActions.DropDownItems.Add(new ToolStripSeparator());

            // Logout
            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Name = "menuItemLogoutDynamic";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemUserActions.DropDownItems.Add(this.menuItemLogout);

            ToolStripItem existingUserActionsMenu = null;
            foreach (ToolStripItem item in this.menuStrip1.Items)
            {
                if (item.Name == "menuItemUserActionsDynamic") // Ищем по имени, которое мы задали
                {
                    existingUserActionsMenu = item;
                    break;
                }
            }
            if (existingUserActionsMenu != null)
            {
                this.menuStrip1.Items.Remove(existingUserActionsMenu);
            }
    
            this.menuStrip1.Items.Add(this.menuItemUserActions);

            // 6. Убедимся, что меню видно
            this.menuStrip1.BringToFront();
        }

        private void MenuItemChangePassword_Click(object sender, EventArgs e)
        {
            using (var changePasswordForm = new ChangePasswordForm(_currentUser.Id, _currentUser.Role))
            {
                changePasswordForm.ShowDialog(this);
            }
        }

        private void MenuItemChangeProfile_Click(object sender, EventArgs e)
        {
            using (var changeProfileForm = new ChangeProfileForm(_currentUser))
            {
                if (changeProfileForm.ShowDialog(this) == DialogResult.OK)
                {
                    _currentUser.FirstName = changeProfileForm.NewFirstName;
                    _currentUser.LastName = changeProfileForm.NewLastName;
                    if (menuItemUserActions != null) menuItemUserActions.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
                }
            }
        }

        private void MenuItemLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void SetupDataGridViews()
        {
            ConfigureDataGridView(dataGridViewAvailableBooks);
            ConfigureDataGridView(dataGridViewMyBooks);
            // Add specific columns if needed for dataGridViewMyBooks, e.g., Designer name
            if (dataGridViewMyBooks != null && !dataGridViewMyBooks.Columns.Contains("DesignerName"))
            {
                 dataGridViewMyBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "DesignerName", DataPropertyName = "DesignerName", HeaderText = "Designer", Width = 120 });
            }
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // ID (скрытый)
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            
            // Title (заполняет оставшееся место, но с минимальной шириной)
            var titleCol = new DataGridViewTextBoxColumn { Name = "BookTitle", DataPropertyName = "Name", HeaderText = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth = 150 };
            dgv.Columns.Add(titleCol);

            // Author (подгоняется по содержимому, но не становится слишком узким)
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Author", DataPropertyName = "AuthorName", HeaderText = "Author", Width = 120, AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet, MinimumWidth = 80 });
            
            // Status (фиксированная ширина или по содержимому)
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "CurrentState", DataPropertyName = "StateDisplay", HeaderText = "Status", Width = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader });
            
            // Age (фиксированная ширина или по содержимому)
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "AgeRestriction", DataPropertyName = "AgeRestrictionDisplay", HeaderText = "Age", Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            
            // Est. End Date (фиксированная ширина)
            var estEndDateCol = new DataGridViewTextBoxColumn { Name = "EstEndDate", DataPropertyName = "EstimatedEndDate", HeaderText = "Est. End", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } };
            dgv.Columns.Add(estEndDateCol);

            // Общие настройки
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false; // Запретить пользователю менять высоту строк вручную
            
            // Для переноса текста, если нужно (но может выглядеть не очень для коротких данных)
            // dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Или DisplayedCells
        }

        private void RefreshAllBookLists()
        {
            LoadAvailableBooks();
            LoadMyAssignedBooks();
            UpdateButtonStates();
        }

        private void LoadAvailableBooks()
        {
            if (dataGridViewAvailableBooks == null) return;
            try
            {
                dataGridViewAvailableBooks.DataSource = _bookService.GetBooksNeedingEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading available books: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyAssignedBooks()
        {
            if (dataGridViewMyBooks == null) return;
            try
            {
                dataGridViewMyBooks.DataSource = _bookService.GetBooksByEditor(_currentUser.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading your books: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void UpdateButtonStates()
        {
            bool availableBookSelected = dataGridViewAvailableBooks != null && dataGridViewAvailableBooks.SelectedRows.Count == 1;
            bool myBookSelected = dataGridViewMyBooks != null && dataGridViewMyBooks.SelectedRows.Count == 1;

            if (btnAssignToMe != null) btnAssignToMe.Enabled = availableBookSelected;

            if (btnSetStatusEditing != null) btnSetStatusEditing.Enabled = myBookSelected;
            if (btnChangeAgeRestriction != null) btnChangeAgeRestriction.Enabled = myBookSelected;
            if (btnReleaseBook != null) btnReleaseBook.Enabled = myBookSelected;

            if(myBookSelected)
            {
                var selectedBook = (Book)dataGridViewMyBooks.SelectedRows[0].DataBoundItem;
                // Кнопка "Set Status to Editing" активна, только если книга еще не в этом статусе (или в in_progress)
                if (btnSetStatusEditing != null)
                    btnSetStatusEditing.Enabled = (selectedBook.State == BookState.in_progress);
            }
        }


        private void BtnAssignToMe_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableBooks == null || dataGridViewAvailableBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewAvailableBooks.SelectedRows[0].DataBoundItem;

            try
            {
                _bookService.AssignEditor(selectedBook.Id, _currentUser.Id); // This also changes state to 'editing'
                MessageBox.Show($"Book '{selectedBook.Name}' has been assigned to you.", "Book Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAllBookLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning book: {ex.Message}", "Assignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSetStatusEditing_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyBooks == null || dataGridViewMyBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewMyBooks.SelectedRows[0].DataBoundItem;

            if (selectedBook.State == BookState.editing)
            {
                MessageBox.Show("Book is already in 'editing' state.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectedBook.State != BookState.in_progress)
            {
                 MessageBox.Show($"Cannot set state to 'editing'. Book is currently '{selectedBook.StateDisplay}'.", "State Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
            }

            try
            {
                // Можно вызвать общий UpdateBookDetailsByEditor или специфичный UpdateBookState
                // _bookService.UpdateBookState(selectedBook.Id, BookState.editing);
                _bookService.EditorUpdateBookDetails(selectedBook.Id, _currentUser.Id, selectedBook.AgeRestrictions, BookState.editing);

                MessageBox.Show($"Book '{selectedBook.Name}' status set to 'editing'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAllBookLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book status: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChangeAgeRestriction_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyBooks == null || dataGridViewMyBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewMyBooks.SelectedRows[0].DataBoundItem;

            // Открыть диалог для выбора нового AgeRestriction
            // Для простоты используем ComboBox в простом диалоге или InputBox со строгим вводом
            // Здесь пример с временным диалогом для выбора
            using (var ageDialog = new Form { Text = "Select Age Restriction", Size = new Size(250, 150), StartPosition = FormStartPosition.CenterParent })
            {
                ComboBox comboAge = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
                comboAge.DataSource = Enum.GetValues(typeof(AgeRestriction))
                                          .Cast<AgeRestriction>()
                                          .Select(ar => new { Name = ar.ToString().Replace("_", "").Replace("plus", "+"), Value = ar })
                                          .ToList();
                comboAge.DisplayMember = "Name";
                comboAge.ValueMember = "Value";
                comboAge.SelectedValue = selectedBook.AgeRestrictions;

                Button btnOk = new Button { Text = "OK", Dock = DockStyle.Bottom, DialogResult = DialogResult.OK };
                ageDialog.Controls.Add(comboAge);
                ageDialog.Controls.Add(btnOk);
                ageDialog.AcceptButton = btnOk;

                if (ageDialog.ShowDialog(this) == DialogResult.OK)
                {
                    AgeRestriction newAgeRestriction = (AgeRestriction)comboAge.SelectedValue;
                    if (newAgeRestriction != selectedBook.AgeRestrictions)
                    {
                        try
                        {
                            _bookService.EditorUpdateBookDetails(selectedBook.Id, _currentUser.Id, newAgeRestriction, selectedBook.State); // Передаем текущий статус, чтобы он не менялся
                            MessageBox.Show($"Age restriction for '{selectedBook.Name}' updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshAllBookLists();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating age restriction: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BtnReleaseBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyBooks == null || dataGridViewMyBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewMyBooks.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show($"Are you sure you want to release the book '{selectedBook.Name}'? It will become available for other editors.", "Confirm Release", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _bookService.ReleaseBookFromEditor(selectedBook.Id, _currentUser.Id);
                MessageBox.Show($"Book '{selectedBook.Name}' has been released.", "Book Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAllBookLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error releasing book: {ex.Message}", "Release Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}