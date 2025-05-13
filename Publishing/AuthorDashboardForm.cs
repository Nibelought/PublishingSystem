using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using Publishing; // Для LoginForm
using Microsoft.VisualBasic; // Для Interaction.InputBox

namespace PublishingSystem.UI
{
    public partial class AuthorDashboardForm : Form
    {
        private readonly User _currentUser;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        // dataGridViewBooks должен быть объявлен в Designer.cs
        // menuStrip1 должен быть объявлен в Designer.cs (если вы его там создали)
        // или menuStripUser, если создаете программно (как в AdminDashboardForm)

        // Эти поля для элементов меню, если вы их создаете программно
        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;

        public AuthorDashboardForm(User currentUser)
        {
            InitializeComponent(); // Это инициализирует dataGridViewBooks и menuStrip1 из Designer.cs
            _currentUser = currentUser;
            _bookService = new BookService();
            _userService = new UserService();

            InitializeUserMenu(); // Настраивает menuStrip1 (или программно созданный menuStripUser)
            SetupDataGridView();  // Настраивает dataGridViewBooks
            LoadBooks();

            // Привязка событий (убедитесь, что кнопки btnAddBook, btnEditBook есть в Designer.cs)
            if (this.btnAddBook != null) btnAddBook.Click += BtnAddBook_Click;
            if (this.btnEditBook != null) btnEditBook.Click += BtnEditBook_Click;
            if (this.dataGridViewBooks != null) dataGridViewBooks.SelectionChanged += DataGridViewBooks_SelectionChanged;
        }

        private void InitializeUserMenu()
        {
            // Используем menuStrip1, который должен быть на форме из Designer.cs
            if (this.menuStrip1 == null)
            {
                // Если menuStrip1 не был добавлен в дизайнере, создаем его программно
                // Это запасной вариант, лучше добавлять через дизайнер
                this.menuStrip1 = new MenuStrip();
                this.menuStrip1.Name = "menuStripUserProgrammatic";
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


            this.menuStrip1.Items.Add(this.menuItemUserActions); // Добавляем в существующий menuStrip1
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
            // dataGridViewBooks должен быть инициализирован дизайнером
            if (this.dataGridViewBooks == null) return; // Защита, если его нет

            dataGridViewBooks.AutoGenerateColumns = false;
            dataGridViewBooks.Columns.Clear();
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "State", DataPropertyName = "StateDisplay", HeaderText = "Status", Width = 100 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "AgeRestriction", DataPropertyName = "AgeRestrictionDisplay", HeaderText = "Age", Width = 50 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "StartDate", DataPropertyName = "StartDate", HeaderText = "Start Date", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstimatedEndDate", DataPropertyName = "EstimatedEndDate", HeaderText = "Est. End Date", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Editor", DataPropertyName = "EditorName", HeaderText = "Editor", Width = 120 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Designer", DataPropertyName = "DesignerName", HeaderText = "Designer", Width = 120 });
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
                var books = _bookService.GetBooksByAuthor(_currentUser.Id);
                dataGridViewBooks.DataSource = books;
                if (this.btnEditBook != null) btnEditBook.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewBooks == null || this.btnEditBook == null) return;
            if (dataGridViewBooks.SelectedRows.Count == 1)
            {
                var selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
                btnEditBook.Enabled = (selectedBook.State == BookState.in_progress);
            }
            else
            {
                btnEditBook.Enabled = false;
            }
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            string bookName = Interaction.InputBox("Enter Book Title:", "Add New Book", "");
            if (string.IsNullOrWhiteSpace(bookName)) return;
            string estEndDateStr = Interaction.InputBox("Enter Estimated End Date (YYYY-MM-DD):", "Add New Book", DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd"));
            if (!DateTime.TryParse(estEndDateStr, out DateTime estEndDate) || estEndDate <= DateTime.Now.Date)
            {
                MessageBox.Show("Invalid estimated end date.", "Error"); return;
            }
            AgeRestriction age = AgeRestriction._0plus; // Упрощенный выбор
            try
            {
                var newBook = new Book { Name = bookName, IdAuthor = _currentUser.Id, EstimatedEndDate = estEndDate, AgeRestrictions = age };
                _bookService.AddBook(newBook);
                MessageBox.Show("Book added successfully!", "Success");
                LoadBooks();
            }
            catch (Exception ex) { MessageBox.Show($"Error adding book: {ex.Message}", "Error"); }
        }

        private void BtnEditBook_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewBooks == null || dataGridViewBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
            string estEndDateStr = Interaction.InputBox("Edit Estimated End Date (YYYY-MM-DD):", "Edit Book", selectedBook.EstimatedEndDate.ToString("yyyy-MM-dd"));
            if (!DateTime.TryParse(estEndDateStr, out DateTime estEndDate) || estEndDate < selectedBook.StartDate)
            {
                MessageBox.Show("Invalid estimated end date.", "Error"); return;
            }
            try
            {
                _bookService.UpdateBookEstimate(selectedBook.Id, estEndDate);
                MessageBox.Show("Book updated successfully!", "Success");
                LoadBooks();
            }
            catch (Exception ex) { MessageBox.Show($"Error updating book: {ex.Message}", "Error"); }
        }
    }
}