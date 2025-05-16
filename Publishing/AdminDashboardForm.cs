using System;
using System.Collections.Generic;
using System.Drawing; // For Point
using System.Linq;
using System.Windows.Forms;
using PublishingSystem.BLL;
using PublishingSystem.Models;
using Publishing; 
using Microsoft.VisualBasic;
using System.Text.RegularExpressions; // For email validation

namespace PublishingSystem.UI
{
    public partial class AdminDashboardForm : Form
    {
        private readonly User _admin;
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly ReviewService _reviewService;

        private MenuStrip menuStripUser; // This will be created programmatically
        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;

        private class StatusDisplay
        {
            public string DisplayName { get; set; }
            public bool Value { get; set; }
            public override string ToString() => DisplayName;
        }

        public AdminDashboardForm(User admin)
        {
            InitializeComponent(); // This initializes tableLayoutPanelMain and tabControlMain
            _admin = admin;
            _userService = new UserService();
            _bookService = new BookService();
            _reviewService = new ReviewService();

            InitializeUserMenu(); // This creates menuStripUser and adds it to tableLayoutPanelMain

            // Configure controls on tabAddUser
            comboAddRole.Items.AddRange(new[] { "author", "editor", "critic", "designer" });
            var statusOptions = new List<StatusDisplay>
            {
                new StatusDisplay { DisplayName = "Active", Value = true },
                new StatusDisplay { DisplayName = "Inactive", Value = false }
            };
            comboAddStatus.DataSource = new List<StatusDisplay>(statusOptions);
            comboAddStatus.DisplayMember = "DisplayName";
            comboAddStatus.ValueMember = "Value";
            if (comboAddRole.Items.Count > 0) comboAddRole.SelectedIndex = 0;
            comboAddStatus.SelectedValue = true;

            // Configure controls on tabViewUsers
            comboRoleFilter.Items.AddRange(new[] { "All Roles", "author", "editor", "critic", "designer" }); // Added "All Roles"
            var statusFilterOptions = new List<object> { "All" };
            statusFilterOptions.AddRange(statusOptions);
            comboStatusFilter.DataSource = statusFilterOptions;
            comboRoleFilter.SelectedItem = "All Roles";
            comboStatusFilter.SelectedItem = "All";
            
            LoadUsers();
            
            SetupBooksTabUI(); // Renamed to avoid conflict with TabPage field
            SetupReviewsTabUI(); // Renamed

            // Event handlers for buttons on tabBooks and tabReviews are now assigned in Designer.cs
            // or should be assigned here if not in Designer.cs for some reason.
            // Example (if btnBooksRefresh was not wired in Designer):
            // this.btnBooksRefresh.Click += (s, e) => LoadBooksAdmin();
            // This is already done for btnAddUser, btnSearch, btnEditUser, btnDeleteUser in Designer.cs.
            // Ensure btnGeneratePassword, btnBooksRefresh etc. also have their Click events wired up in Designer.cs if you expect them to work.
            // If they are not wired in Designer.cs (e.g. no this.btnGeneratePassword.Click += ... line), add them here:
             if (this.btnGeneratePassword != null) this.btnGeneratePassword.Click += BtnGeneratePassword_Click;
             if (this.btnBooksRefresh != null) this.btnBooksRefresh.Click += (s, e) => LoadBooksAdmin();
             if (this.btnBookEdit != null) this.btnBookEdit.Click += BtnBookEdit_Click;
             if (this.btnBookDelete != null) this.btnBookDelete.Click += BtnBookDelete_Click;
             if (this.btnReviewsRefresh != null) this.btnReviewsRefresh.Click += (s, e) => LoadReviewsAdmin();
             if (this.btnReviewDelete != null) this.btnReviewDelete.Click += BtnReviewDelete_Click;
        }

        private void InitializeUserMenu()
        {
            this.menuStripUser = new MenuStrip();
            this.menuItemUserActions = new ToolStripMenuItem();
            this.menuItemChangePassword = new ToolStripMenuItem();
            this.menuItemChangeProfile = new ToolStripMenuItem();
            this.menuItemLogout = new ToolStripMenuItem();

            this.menuStripUser.Items.AddRange(new ToolStripItem[] { this.menuItemUserActions });
            this.menuStripUser.Name = "menuStripUser";
            this.menuStripUser.Dock = DockStyle.Fill; // Fill the cell in TableLayoutPanel

            this.menuItemUserActions.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuItemChangePassword,
                this.menuItemChangeProfile,
                new ToolStripSeparator(),
                this.menuItemLogout});
            this.menuItemUserActions.Text = $"{_admin.FirstName} {_admin.LastName}";
            this.menuItemUserActions.Alignment = ToolStripItemAlignment.Right;
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
            
            // Add MenuStrip to the first row of tableLayoutPanelMain
            if (this.tableLayoutPanelMain != null)
            {
                this.tableLayoutPanelMain.Controls.Add(this.menuStripUser, 0, 0);
                 this.tableLayoutPanelMain.SetColumnSpan(this.menuStripUser, this.tableLayoutPanelMain.ColumnCount);
            }
             // Set as main menu strip for the form for standard menu key handling (like Alt keys)
             this.MainMenuStrip = this.menuStripUser;
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
            string roleFilter = comboRoleFilter.SelectedItem?.ToString();
            if (roleFilter == "All Roles") roleFilter = null;

            bool? isActiveFilter = null;
            if (comboStatusFilter.SelectedItem is StatusDisplay sd) isActiveFilter = sd.Value;
            // No need for "All" string check if "All" is the first item and selectedIndex = 0 means "All" (isActiveFilter = null)
            
            string email = txtEmailFilter.Text.Trim();
            try
            {
                dataGridUsers.DataSource = _userService.GetUsers(roleFilter, isActiveFilter, email);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // This method is called by the designer if you named the event handler this way
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
        
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim();
            }
            catch { return false; }
        }

        // This method is called by the designer
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (comboAddRole.SelectedItem == null || comboAddStatus.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("All fields are required, and role/status must be selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string emailToValidate = txtEmail.Text.Trim();
            if (!IsValidEmail(emailToValidate))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
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
                    Email = emailToValidate, // Use validated email
                    Password = hashedPassword,
                    Role = comboAddRole.SelectedItem.ToString(),
                    IsActive = (bool)comboAddStatus.SelectedValue
                };
                int newUserId = _userService.CreateUser(userToCreate); // UserService CreateUser should NOT hash again
                AuditService.LogAdminAction(_admin.Email, $"Created user with role {userToCreate.Role}", newUserId);

                string successMessage = $"User successfully added.\nEmail: {userToCreate.Email}\nPassword: {plainPassword}\n\nPassword copied to clipboard.";
                try { Clipboard.SetText(plainPassword); }
                catch (Exception clipEx)
                {
                    successMessage = $"User successfully added.\nEmail: {userToCreate.Email}\nPassword: {plainPassword}\n\n(Could not copy password to clipboard: {clipEx.Message})";
                    Console.WriteLine($"Clipboard error: {clipEx.Message}");
                }
                MessageBox.Show(successMessage, "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearUserForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method is called by the designer
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count != 1)
            { MessageBox.Show("Please select a single user to edit."); return; }
            var selectedUser = (User)dataGridUsers.SelectedRows[0].DataBoundItem;
            
            string newFirstName = Interaction.InputBox("Edit First Name:", "Edit User", selectedUser.FirstName);
            if (string.IsNullOrEmpty(newFirstName) && newFirstName != selectedUser.FirstName) { /* User might have cleared it, or cancelled if Interaction.InputBox returns empty on cancel */ return; }
            
            string newLastName = Interaction.InputBox("Edit Last Name:", "Edit User", selectedUser.LastName);
            if (string.IsNullOrEmpty(newLastName) && newLastName != selectedUser.LastName) return;

            string currentStatusStr = selectedUser.IsActive ? "active" : "inactive";
            string newStatusStr = Interaction.InputBox($"Edit Status (active/inactive):", "Edit User Status", currentStatusStr);
             if (string.IsNullOrEmpty(newStatusStr) && newStatusStr != currentStatusStr) return;


            bool newIsActive = selectedUser.IsActive; // Default to current if input is invalid/empty
            if (newStatusStr.Trim().ToLower() == "active") newIsActive = true;
            else if (newStatusStr.Trim().ToLower() == "inactive") newIsActive = false;
            else if (!string.IsNullOrEmpty(newStatusStr) && newStatusStr != currentStatusStr) // only show error if user entered something invalid
            { MessageBox.Show("Invalid status. Enter 'active' or 'inactive'. Status not changed.", "Input Error"); return; }

            selectedUser.FirstName = newFirstName; // Assign even if empty is user confirmed empty
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

        // This method is called by the designer
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count != 1)
            { MessageBox.Show("Please select a single user to delete."); return; }
            var selectedUser = (User)dataGridUsers.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show($"Are you sure you want to delete user {selectedUser.Email}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void SetupBooksTabUI() // Renamed
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
            // TODO: Implement a proper BookEditForm
            MessageBox.Show($"Editing book ID: {selectedBook.Id}. (Edit form not implemented yet).", "Info");
            LoadBooksAdmin();
        }
        private void BtnBookDelete_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridBooks.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show($"Delete book '{selectedBook.Name}' (ID: {selectedBook.Id})?\nThis will also delete associated reviews.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            try
            {
                _bookService.DeleteBook(selectedBook.Id);
                AuditService.LogAdminAction(_admin.Email, $"Deleted book '{selectedBook.Name}'", selectedBook.Id);
                MessageBox.Show("Book deleted successfully.");
                LoadBooksAdmin();
            }
            catch (Exception ex) { MessageBox.Show($"Error deleting book: {ex.Message}"); }
        }

        private void SetupReviewsTabUI() // Renamed
        {
            dataGridReviews.AutoGenerateColumns = false;
            dataGridReviews.Columns.Clear();
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewId", DataPropertyName = "Id", HeaderText = "ID", Width = 40 });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewBook", DataPropertyName = "BookName", HeaderText = "Book", Width = 200 });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewCritic", DataPropertyName = "CriticName", HeaderText = "Critic", Width = 120 });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewDate", DataPropertyName = "DateTime", HeaderText = "Date", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" } });
            dataGridReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewText", DataPropertyName = "RtfText", HeaderText = "Review Text (RTF)", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); // Displaying RTF as plain text
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
            var confirm = MessageBox.Show($"Delete review ID {selectedReview.Id} by {selectedReview.CriticName} for book '{selectedReview.BookName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            try
            {
                _reviewService.DeleteReview(selectedReview.Id);
                AuditService.LogAdminAction(_admin.Email, $"Deleted review for book '{selectedReview.BookName}' by critic ID {selectedReview.IdCritic}", selectedReview.Id);
                MessageBox.Show("Review deleted successfully.");
                LoadReviewsAdmin();
            }
            catch (Exception ex) { MessageBox.Show($"Error deleting review: {ex.Message}"); }
        }
        
        private void ClearUserForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            if (comboAddRole.Items.Count > 0) comboAddRole.SelectedIndex = 0;
            if (comboAddStatus.Items.Count > 0) comboAddStatus.SelectedValue = true;
        }
    }
}