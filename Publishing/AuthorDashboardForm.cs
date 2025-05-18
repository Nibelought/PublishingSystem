using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using Publishing; // Для LoginForm
// using Microsoft.VisualBasic; // Больше не нужен для InputBox, если заменяем панелью

namespace PublishingSystem.UI
{
    public partial class AuthorDashboardForm : Form
    {
        private readonly User _currentUser;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        // Предполагаем, что эти контролы добавлены в Designer.cs:
        // dataGridViewBooks, menuStrip1 (или menuStripUser если программно)
        // panelAddBook, txtBookName, dtpEstimatedEndDate, comboAgeRestrictionAdd
        // btnSaveNewBook, btnCancelAddBook, btnShowAddBookPanel, btnEditBook

        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;

        public AuthorDashboardForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _bookService = new BookService();
            _userService = new UserService();

            InitializeUserMenu();
            SetupDataGridView();
            LoadBooks();
            InitializeAddBookPanel(); // Настройка панели добавления

            // Привязка событий
            if (this.btnShowAddBookPanel != null) this.btnShowAddBookPanel.Click += BtnShowAddBookPanel_Click;
            if (this.btnSaveNewBook != null) this.btnSaveNewBook.Click += BtnSaveNewBook_Click;
            if (this.btnCancelAddBook != null) this.btnCancelAddBook.Click += BtnCancelAddBook_Click;
            if (this.btnEditBook != null) this.btnEditBook.Click += BtnEditBook_Click;
            if (this.dataGridViewBooks != null) dataGridViewBooks.SelectionChanged += DataGridViewBooks_SelectionChanged;

            if (this.panelAddBook != null) this.panelAddBook.Visible = false; // Скрыть панель по умолчанию
            if (this.btnEditBook != null) this.btnEditBook.Enabled = false; // Кнопка редактирования выключена
        }

        private void InitializeUserMenu()
        {
            // ... (КОД ИЗ ПРЕДЫДУЩЕГО ОТВЕТА ДЛЯ ИНИЦИАЛИЗАЦИИ МЕНЮ) ...
            // Убедитесь, что используется this.menuStrip1 (если из дизайнера)
            // или создается новый MenuStrip (если программно)
             if (this.menuStrip1 == null) // Запасной вариант, если menuStrip1 не из дизайнера
            {
                this.menuStrip1 = new MenuStrip(); // Предположим, что menuStrip1 объявлен в Designer.cs
                this.menuStrip1.Name = "menuStripAuthorProgrammatic";
                this.menuStrip1.Dock = DockStyle.Top;
                this.Controls.Add(this.menuStrip1);
                this.MainMenuStrip = this.menuStrip1;
            }
            
            this.menuItemUserActions = new ToolStripMenuItem();
            this.menuItemChangePassword = new ToolStripMenuItem();
            this.menuItemChangeProfile = new ToolStripMenuItem();
            this.menuItemLogout = new ToolStripMenuItem();

            this.menuItemUserActions.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuItemChangePassword,
                this.menuItemChangeProfile,
                new ToolStripSeparator(),
                this.menuItemLogout});
            this.menuItemUserActions.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
            this.menuItemUserActions.Alignment = ToolStripItemAlignment.Right;
            this.menuItemUserActions.Name = "menuItemUserActionsAuthor";

            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemChangePassword.Name = "menuItemChangePasswordAuthor";

            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemChangeProfile.Name = "menuItemChangeProfileAuthor";

            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemLogout.Name = "menuItemLogoutAuthor";

            this.menuStrip1.Items.Add(this.menuItemUserActions);
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

        private void SetupDataGridView()
        {
            if (this.dataGridViewBooks == null) return;
            // ... (КОД НАСТРОЙКИ СТОЛБЦОВ DataGridView ИЗ ПРЕДЫДУЩЕГО ОТВЕТА) ...
            dataGridViewBooks.AutoGenerateColumns = false;
            dataGridViewBooks.Columns.Clear();
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "State", DataPropertyName = "StateDisplay", HeaderText = "Status", Width = 100 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "AgeRestriction", DataPropertyName = "AgeRestrictionDisplay", HeaderText = "Age", Width = 50 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "StartDate", DataPropertyName = "StartDate", HeaderText = "Start Date", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstimatedEndDate", DataPropertyName = "EstimatedEndDate", HeaderText = "Est. End Date", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Editor", DataPropertyName = "EditorName", HeaderText = "Editor", Width = 120 }); // Может быть пустым
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Designer", DataPropertyName = "DesignerName", HeaderText = "Designer", Width = 120 }); // Может быть пустым
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.MultiSelect = false;
            dataGridViewBooks.ReadOnly = true;
            dataGridViewBooks.AllowUserToAddRows = false;
        }

        private void LoadBooks()
        {
            if (this.dataGridViewBooks == null) return;
            try
            {
                dataGridViewBooks.DataSource = _bookService.GetBooksByAuthor(_currentUser.Id);
                if (this.btnEditBook != null) btnEditBook.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeAddBookPanel()
        {
            if (this.dtpEstimatedEndDate != null)
            {
                this.dtpEstimatedEndDate.MinDate = DateTime.Now.AddDays(1);
                this.dtpEstimatedEndDate.Value = DateTime.Now.AddMonths(3);
                this.dtpEstimatedEndDate.Format = DateTimePickerFormat.Short;
            }

            if (this.comboAgeRestrictionAdd != null)
            {
                // Заполняем ComboBox значениями из Enum AgeRestriction
                comboAgeRestrictionAdd.DataSource = Enum.GetValues(typeof(AgeRestriction))
                                                        .Cast<AgeRestriction>()
                                                        .Select(ar => new { Name = ar.ToString().Replace("_", "").Replace("plus", "+"), Value = ar })
                                                        .ToList();
                comboAgeRestrictionAdd.DisplayMember = "Name";
                comboAgeRestrictionAdd.ValueMember = "Value";
                comboAgeRestrictionAdd.DropDownStyle = ComboBoxStyle.DropDownList;
                if (comboAgeRestrictionAdd.Items.Count > 0) comboAgeRestrictionAdd.SelectedIndex = 0;
            }
        }

        private void BtnShowAddBookPanel_Click(object sender, EventArgs e)
        {
            if (this.panelAddBook != null)
            {
                this.panelAddBook.Visible = true;
                // Очистить поля при открытии
                if(this.txtBookName != null) this.txtBookName.Clear();
                if(this.dtpEstimatedEndDate != null) this.dtpEstimatedEndDate.Value = DateTime.Now.AddMonths(3);
                if (this.comboAgeRestrictionAdd != null && this.comboAgeRestrictionAdd.Items.Count > 0) this.comboAgeRestrictionAdd.SelectedIndex = 0;
            }
        }

        private void BtnSaveNewBook_Click(object sender, EventArgs e)
        {
            if (this.txtBookName == null || this.dtpEstimatedEndDate == null || this.comboAgeRestrictionAdd == null || this.panelAddBook == null) return;

            string bookName = txtBookName.Text.Trim();
            DateTime estimatedEndDate = dtpEstimatedEndDate.Value;
            
            if (string.IsNullOrWhiteSpace(bookName))
            {
                MessageBox.Show("Book name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBookName.Focus();
                return;
            }
            if (estimatedEndDate.Date <= DateTime.Now.Date)
            {
                 MessageBox.Show("Estimated end date must be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 dtpEstimatedEndDate.Focus();
                 return;
            }
            if (comboAgeRestrictionAdd.SelectedValue == null)
            {
                MessageBox.Show("Please select an age restriction.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgeRestriction ageRestriction = (AgeRestriction)comboAgeRestrictionAdd.SelectedValue;

            try
            {
                var newBook = new Book
                {
                    Name = bookName,
                    IdAuthor = _currentUser.Id,
                    EstimatedEndDate = estimatedEndDate.Date,
                    AgeRestrictions = ageRestriction,
                    StartDate = DateTime.Now.Date,
                    State = BookState.in_progress,
                    IdEditor = null,
                    IdDesigner = null,
                    CoverImagePath = null 
                };

                _bookService.AddBook(newBook); // BookService должен корректно обработать null для FK
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
                panelAddBook.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelAddBook_Click(object sender, EventArgs e)
        {
            if (this.panelAddBook != null) this.panelAddBook.Visible = false;
        }
        
        private void DataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewBooks == null || this.btnEditBook == null) return;
            if (dataGridViewBooks.SelectedRows.Count == 1)
            {
                var selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
                // Разрешить редактирование только если книга еще в работе у автора
                // и не назначена редактору (подразумевая, что после этого автор не может менять даты)
                btnEditBook.Enabled = (selectedBook.State == BookState.in_progress && !selectedBook.IdEditor.HasValue);
            }
            else
            {
                btnEditBook.Enabled = false;
            }
        }

        private void BtnEditBook_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewBooks == null || dataGridViewBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;

            // Используем тот же DateTimePicker, что и для добавления, но предзаполняем его.
            // Для простоты можно снова использовать Interaction.InputBox или создать отдельную форму редактирования.
            // Здесь для примера изменим только дату через InputBox.
            string currentEstEndDateStr = selectedBook.EstimatedEndDate.ToString("yyyy-MM-dd");
            string newEstEndDateStr = Microsoft.VisualBasic.Interaction.InputBox("Edit Estimated End Date (YYYY-MM-DD):", "Edit Book Estimate", currentEstEndDateStr);
            
            if (string.IsNullOrWhiteSpace(newEstEndDateStr) || newEstEndDateStr == currentEstEndDateStr) return; // Нет изменений или отмена

            if (!DateTime.TryParse(newEstEndDateStr, out DateTime newEstEndDate) || newEstEndDate.Date < selectedBook.StartDate.Date)
            {
                MessageBox.Show("Invalid estimated end date. Must be after start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _bookService.UpdateBookEstimate(selectedBook.Id, newEstEndDate);
                MessageBox.Show("Book estimated end date updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}