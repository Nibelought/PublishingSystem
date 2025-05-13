using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PublishingSystem.BLL;
using PublishingSystem.Models;
using Publishing; // Для LoginForm
using Microsoft.VisualBasic; // Для Interaction.InputBox

namespace PublishingSystem.UI
{
    public partial class AdminDashboardForm : Form
    {
        private readonly User _admin;
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly ReviewService _reviewService;

        // Объявляем MenuStrip здесь, если он создается программно
        // Если он добавлен через Designer (например, с именем this.menuStrip1),
        // то это поле не нужно, и в InitializeUserMenu нужно использовать this.menuStrip1.
        // Судя по вашему Designer.cs, menuStripUser там объявлено, но не инициализировано,
        // что странно. Безопаснее создать его программно здесь.
        private MenuStrip menuStripUser;
        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;


        // Класс-обертка для ComboBox статуса
        private class StatusDisplay
        {
            public string DisplayName { get; set; }
            public bool Value { get; set; }
            public override string ToString() => DisplayName;
        }

        public AdminDashboardForm(User admin)
        {
            InitializeComponent();
            _admin = admin;
            _userService = new UserService();
            _bookService = new BookService();
            _reviewService = new ReviewService();

            InitializeUserMenu(); // Инициализация меню пользователя

            // Настройка вкладки "Add User" и "View Users"
            comboRoleFilter.Items.AddRange(new[] { "author", "editor", "critic", "designer" });
            comboAddRole.Items.AddRange(new[] { "author", "editor", "critic", "designer" });

            var statusOptions = new List<StatusDisplay>
            {
                new StatusDisplay { DisplayName = "Active", Value = true },
                new StatusDisplay { DisplayName = "Inactive", Value = false }
            };
            var statusFilterOptions = new List<object> { "All" };
            statusFilterOptions.AddRange(statusOptions);

            comboAddStatus.DataSource = new List<StatusDisplay>(statusOptions); // Клон списка
            comboAddStatus.DisplayMember = "DisplayName";
            comboAddStatus.ValueMember = "Value";

            comboStatusFilter.DataSource = statusFilterOptions; // Будет использовать ToString() для "All" и StatusDisplay

            comboRoleFilter.SelectedIndex = -1;
            comboStatusFilter.SelectedItem = "All";
            comboAddRole.SelectedIndex = 0;
            comboAddStatus.SelectedValue = true;

            LoadUsers(); // Загрузка пользователей

            // Инициализация новых вкладок
            SetupBooksTab();
            SetupReviewsTab();

            // Привязка событий для элементов (убедитесь, что эти кнопки есть в Designer.cs)
            if (this.btnGeneratePassword != null) btnGeneratePassword.Click += BtnGeneratePassword_Click;
            if (this.btnBooksRefresh != null) btnBooksRefresh.Click += (s, e) => LoadBooksAdmin();
            if (this.btnBookEdit != null) btnBookEdit.Click += BtnBookEdit_Click;
            if (this.btnBookDelete != null) btnBookDelete.Click += BtnBookDelete_Click;
            if (this.btnReviewsRefresh != null) btnReviewsRefresh.Click += (s, e) => LoadReviewsAdmin();
            if (this.btnReviewDelete != null) btnReviewDelete.Click += BtnReviewDelete_Click;

            // Обработчики из Designer.cs должны быть реализованы
            // btnAddUser.Click += btnAddUser_Click; // Уже привязано в Designer.cs
            // btnSearch.Click += btnSearch_Click; // Уже привязано в Designer.cs
            // btnEditUser.Click += btnEditUser_Click; // Уже привязано в Designer.cs
            // btnDeleteUser.Click += btnDeleteUser_Click; // Уже привязано в Designer.cs
        }

        private void InitializeUserMenu()
        {
            this.menuStripUser = new MenuStrip(); // Создаем MenuStrip программно
            this.menuItemUserActions = new ToolStripMenuItem();
            this.menuItemChangePassword = new ToolStripMenuItem();
            this.menuItemChangeProfile = new ToolStripMenuItem();
            this.menuItemLogout = new ToolStripMenuItem();

            this.menuStripUser.Items.AddRange(new ToolStripItem[] { this.menuItemUserActions });
            this.menuStripUser.Name = "menuStripUser";
            this.menuStripUser.Dock = DockStyle.Top; // Располагаем вверху
            this.Controls.Add(this.menuStripUser);   // Добавляем на форму
            this.MainMenuStrip = this.menuStripUser; // Устанавливаем как главное меню

            this.menuItemUserActions.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuItemChangePassword,
                this.menuItemChangeProfile,
                new ToolStripSeparator(),
                this.menuItemLogout});
            this.menuItemUserActions.Text = $"{_admin.FirstName} {_admin.LastName}";
            this.menuItemUserActions.Alignment = ToolStripItemAlignment.Right; // Выровнять текст или сам элемент
            this.menuItemUserActions.Name = "menuItemUserActions";

            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemChangePassword.Name = "menuItemChangePassword";

            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemChangeProfile.Name = "menuItemChangeProfile";

            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemLogout.Name = "menuItemLogout";
            
            this.menuStripUser.BringToFront(); // Чтобы было поверх TabControl
        }

        private void MenuItemChangePassword_Click(object sender, EventArgs e)
        {
            using (var changePasswordForm = new ChangePasswordForm(_admin.Id, _admin.Role))
            {
                changePasswordForm.ShowDialog(this);
            }
        }

        private void MenuItemChangeProfile_Click(object sender, EventArgs e)
        {
            using (var changeProfileForm = new ChangeProfileForm(_admin))
            {
                if (changeProfileForm.ShowDialog(this) == DialogResult.OK)
                {
                    _admin.FirstName = changeProfileForm.NewFirstName;
                    _admin.LastName = changeProfileForm.NewLastName;
                    menuItemUserActions.Text = $"{_admin.FirstName} {_admin.LastName}";
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

        private void LoadUsers()
        {
            string role = comboRoleFilter.SelectedItem?.ToString();
            bool? isActiveFilter = null;
            if (comboStatusFilter.SelectedItem is StatusDisplay sd) isActiveFilter = sd.Value;
            else if (comboStatusFilter.SelectedItem is "All") isActiveFilter = null;

            string email = txtEmailFilter.Text.Trim();
            try
            {
                dataGridUsers.DataSource = _userService.GetUsers(role, isActiveFilter, email);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void BtnGeneratePassword_Click(object sender, EventArgs e)
        {
            try
            {
                txtPassword.Text = _userService.GeneratePassword();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (comboAddRole.SelectedItem == null || comboAddStatus.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("All fields are required, and role/status must be selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirm = MessageBox.Show("Подтвердите правильность введённых данных", "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;
            try
            {
                string plainPassword = txtPassword.Text;
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
                var userToCreate = new User
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = hashedPassword,
                    Role = comboAddRole.SelectedItem.ToString(),
                    IsActive = (bool)comboAddStatus.SelectedValue
                };
                int newUserId = _userService.CreateUser(userToCreate);
                AuditService.LogAdminAction(_admin.Email, $"Created user with role {userToCreate.Role}", newUserId);
                MessageBox.Show($"Пользователь успешно добавлен.\nEmail: {userToCreate.Email}\nPassword: {plainPassword}", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearUserForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single user to edit."); return;
            }
            var selectedUser = (User)dataGridUsers.SelectedRows[0].DataBoundItem;
            string newFirstName = Prompt("Edit First Name:", selectedUser.FirstName);
            if (newFirstName == null) return; // User cancelled
            string newLastName = Prompt("Edit Last Name:", selectedUser.LastName);
            if (newLastName == null) return;

            // Для IsActive лучше использовать ComboBox в диалоге
            string currentStatus = selectedUser.IsActive ? "active" : "inactive";
            string newStatusStr = Prompt($"Edit Status (active/inactive):", currentStatus);
            if (newStatusStr == null) return;

            bool newIsActive;
            if (newStatusStr.ToLower() == "active") newIsActive = true;
            else if (newStatusStr.ToLower() == "inactive") newIsActive = false;
            else { MessageBox.Show("Invalid status. Enter 'active' or 'inactive'."); return; }

            selectedUser.FirstName = newFirstName;
            selectedUser.LastName = newLastName;
            selectedUser.IsActive = newIsActive;
            try
            {
                _userService.UpdateUser(selectedUser);
                AuditService.LogAdminAction(_admin.Email, $"Updated user {selectedUser.Email}", selectedUser.Id);
                MessageBox.Show("User updated successfully.");
                LoadUsers();
            }
            catch (Exception ex) { MessageBox.Show("Error updating user: " + ex.Message); }
        }
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single user to delete."); return;
            }
            var selectedUser = (User)dataGridUsers.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show($"Are you sure you want to delete user {selectedUser.Email}?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;
            try
            {
                _userService.DeleteUser(selectedUser);
                AuditService.LogAdminAction(_admin.Email, $"Deleted user {selectedUser.Email}", selectedUser.Id);
                MessageBox.Show("User deleted successfully.");
                LoadUsers();
            }
            catch (Exception ex) { MessageBox.Show("Error deleting user: " + ex.Message); }
        }

        private void SetupBooksTab()
        {
            dataGridBooks.AutoGenerateColumns = false;
            dataGridBooks.Columns.Clear();
            dataGridBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookId", DataPropertyName = "Id", HeaderText = "ID", Width = 40 });
            dataGridBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookName", DataPropertyName = "Name", HeaderText = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookAuthor", DataPropertyName = "AuthorName", HeaderText = "Author", Width = 120 });
            dataGridBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookState", DataPropertyName = "StateDisplay", HeaderText = "Status", Width = 100 });
            dataGridBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridBooks.MultiSelect = false;
            dataGridBooks.ReadOnly = true;
            dataGridBooks.AllowUserToAddRows = false;
            LoadBooksAdmin();
        }
        private void LoadBooksAdmin()
        {
            try { dataGridBooks.DataSource = _bookService.GetAllBooks(); }
            catch (Exception ex) { MessageBox.Show($"Error loading books: {ex.Message}"); }
        }
        private void BtnBookEdit_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridBooks.SelectedRows[0].DataBoundItem;
            MessageBox.Show($"Editing book ID: {selectedBook.Id}. Implement a proper edit form.", "Info");
            // TODO: Открыть форму редактирования книги (BookEditForm), передать selectedBook.
            // В BookEditForm вызвать _bookService.UpdateBook(editedBook);
            LoadBooksAdmin();
        }
        private void BtnBookDelete_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridBooks.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show($"Delete book '{selectedBook.Name}'? This also deletes reviews.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            try
            {
                _bookService.DeleteBook(selectedBook.Id);
                AuditService.LogAdminAction(_admin.Email, $"Deleted book '{selectedBook.Name}'", selectedBook.Id);
                LoadBooksAdmin();
            }
            catch (Exception ex) { MessageBox.Show($"Error deleting book: {ex.Message}"); }
        }

        private void SetupReviewsTab()
        {
            dataGridReviews.AutoGenerateColumns = false;
            dataGridReviews.Columns.Clear();
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewId", DataPropertyName = "Id", HeaderText = "ID", Width = 40 });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewBook", DataPropertyName = "BookName", HeaderText = "Book", Width = 200 });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewCritic", DataPropertyName = "CriticName", HeaderText = "Critic", Width = 120 });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewDate", DataPropertyName = "DateTime", HeaderText = "Date", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" } });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewText", DataPropertyName = "RtfText", HeaderText = "Review Text (RTF)", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dataGridReviews.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridReviews.MultiSelect = false;
            dataGridReviews.ReadOnly = true;
            dataGridReviews.AllowUserToAddRows = false;
            LoadReviewsAdmin();
        }
        private void LoadReviewsAdmin()
        {
            try { dataGridReviews.DataSource = _reviewService.GetAllReviews(); }
            catch (Exception ex) { MessageBox.Show($"Error loading reviews: {ex.Message}"); }
        }
        private void BtnReviewDelete_Click(object sender, EventArgs e)
        {
            if (dataGridReviews.SelectedRows.Count != 1) return;
            var selectedReview = (Review)dataGridReviews.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show($"Delete review ID {selectedReview.Id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            try
            {
                _reviewService.DeleteReview(selectedReview.Id);
                AuditService.LogAdminAction(_admin.Email, $"Deleted review ID {selectedReview.Id}", selectedReview.Id);
                LoadReviewsAdmin();
            }
            catch (Exception ex) { MessageBox.Show($"Error deleting review: {ex.Message}"); }
        }

        private string Prompt(string message, string defaultValue)
        {
            return Interaction.InputBox(message, "Edit Field", defaultValue);
        }
        private void ClearUserForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            if (comboAddRole.Items.Count > 0) comboAddRole.SelectedIndex = 0;
            if (comboAddStatus.Items.Count > 0) comboAddStatus.SelectedValue = true; // Предполагая, что true это "Active"
        }

        // Обработчик для tabPage1_Click (если он все еще привязан в дизайнере и не нужен)
        private void tabPage1_Click(object sender, EventArgs e)
        {
            // Оставьте пустым или удалите привязку в дизайнере
        }
    }
}