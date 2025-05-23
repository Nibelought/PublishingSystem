using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PublishingSystem.BLL; // Business Logic Layer
using PublishingSystem.Models; // Core Models
using PublishingSystem.Models.DTO; // Data Transfer Objects
using Publishing; // For LoginForm, if it's in this namespace
using Microsoft.VisualBasic; // For Interaction.InputBox
using System.Text.RegularExpressions; // For email validation
using Dapper; // For executing SQL queries directly
using PublishingSystem.DAL; // For DbContext
using PublishingSystem.UI.Helpers; // For dgv sort

namespace PublishingSystem.UI
{
    public partial class AdminDashboardForm : Form
    {
        private readonly User _admin;
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly ReviewService _reviewService;

        private MenuStrip menuStripUser;
        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;
        private ToolStripMenuItem menuItemRefreshAll;

        // Helper class for ComboBox items displaying user status
        private class StatusDisplay
        {
            public string DisplayName { get; set; }
            public bool Value { get; set; }
            public override string ToString() => DisplayName;
        }

        // Helper class for ComboBox items for selecting queries
        private class QueryDropDownItem
        {
            public string Text { get; set; }
            public object QueryType { get; set; }
            public override string ToString() => Text;
        }

        private enum BookAnalyticsQueryType
        {
            SelectPrompt,
            BooksByAgeRestriction,
            BookCountByState,
            BooksPublishedBetweenDates,
            ReviewsByBook // Will use comboAnalyticsBookSelect
        }

        private enum UserActivityQueryType
        {
            SelectPrompt,
            InactiveUsersByRole,
            BooksAwaitingAssignment,
            EmployeeWorkload,
            ReviewsByCritic,
            ReviewsByCriticInDateRange
        }

        public AdminDashboardForm(User admin)
        {
            InitializeComponent();
            _admin = admin;
            _userService = new UserService();
            _bookService = new BookService();
            _reviewService = new ReviewService();

            InitializeUserMenu();
            InitializeUserManagementTab();
            InitializeBooksTab();
            InitializeReviewsTab();
            InitializeAnalyticsTabs(); // This will now populate new ComboBoxes too
            
            // --- ADD SORTING EVENT HANDLERS ---
            if (this.dataGridUsers != null)
            {
                this.dataGridUsers.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }
            if (this.dataGridBooks != null)
            {
                this.dataGridBooks.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }
            if (this.dataGridReviews != null)
            {
                this.dataGridReviews.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }
            // For analytics grids, it might be simpler to re-run the query with an ORDER BY clause
            // rather than client-side sorting, but you could apply this pattern too.
            if (this.dataGridBookAnalytics != null)
            {
                this.dataGridBookAnalytics.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }
            if (this.dataGridUserActivity != null)
            {
                this.dataGridUserActivity.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }
        }

        #region Menu Initialization and Handlers
        private void InitializeUserMenu()
        {
            this.menuStripUser = new MenuStrip();
            this.menuItemUserActions = new ToolStripMenuItem();
            this.menuItemChangePassword = new ToolStripMenuItem();
            this.menuItemChangeProfile = new ToolStripMenuItem();
            this.menuItemRefreshAll = new ToolStripMenuItem();
            this.menuItemLogout = new ToolStripMenuItem();

            this.menuStripUser.Items.AddRange(new ToolStripItem[] { this.menuItemUserActions });
            this.menuStripUser.Name = "menuStripUser";
            this.menuStripUser.Dock = DockStyle.Fill;

            this.menuItemUserActions.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuItemChangePassword, this.menuItemChangeProfile, this.menuItemRefreshAll,
                new ToolStripSeparator(), this.menuItemLogout});
            this.menuItemUserActions.Text = $"{_admin.FirstName} {_admin.LastName}";
            this.menuItemUserActions.Alignment = ToolStripItemAlignment.Right;
            this.menuItemUserActions.Name = "menuItemUserActionsAdmin";

            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemChangePassword.Name = "menuItemChangePasswordAdmin";

            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemChangeProfile.Name = "menuItemChangeProfileAdmin";
            
            this.menuItemRefreshAll.Text = "Refresh All Data (F5)";
            this.menuItemRefreshAll.ShortcutKeys = Keys.F5;
            this.menuItemRefreshAll.ShowShortcutKeys = true;
            this.menuItemRefreshAll.Click += (s, e) => RefreshAllAdminData();
            this.menuItemRefreshAll.Name = "menuItemRefreshAllAdmin";

            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemLogout.Name = "menuItemLogoutAdmin";
            
            if (this.tableLayoutPanelMain != null) // Ensure tableLayoutPanelMain exists
            {
                this.tableLayoutPanelMain.Controls.Add(this.menuStripUser, 0, 0);
                this.tableLayoutPanelMain.SetColumnSpan(this.menuStripUser, this.tableLayoutPanelMain.ColumnCount);
            }
            this.MainMenuStrip = this.menuStripUser;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                RefreshAllAdminData();
                return true; 
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RefreshAllAdminData()
        {
            LoadUsers();
            LoadBooksAdmin();
            LoadReviewsAdmin();
            // Optionally re-run analytics if needed, or just clear them
            if(dataGridBookAnalytics != null) dataGridBookAnalytics.DataSource = null;
            if(dataGridUserActivity != null) dataGridUserActivity.DataSource = null;
            MessageBox.Show("All data lists refreshed.", "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if(menuItemUserActions != null) menuItemUserActions.Text = $"{_admin.FirstName} {_admin.LastName}";
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
        #endregion

        #region User Management Tab
        private void InitializeUserManagementTab()
        {
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

            comboRoleFilter.Items.AddRange(new[] { "All Roles", "author", "editor", "critic", "designer" });
            var statusFilterOptions = new List<object> { "All" }; // "All" is a string
            statusFilterOptions.AddRange(statusOptions); // Add StatusDisplay objects
            comboStatusFilter.DataSource = statusFilterOptions;
            comboRoleFilter.SelectedItem = "All Roles";
            comboStatusFilter.SelectedItem = "All"; // Select the string "All"

            LoadUsers();

            if (this.btnGeneratePassword != null) this.btnGeneratePassword.Click += BtnGeneratePassword_Click;
            // btnAddUser, btnSearch, btnEditUser, btnDeleteUser are wired in Designer.cs via their Click properties
        }

        private void LoadUsers()
        {
            string roleFilter = comboRoleFilter.SelectedItem?.ToString();
            if (roleFilter == "All Roles") roleFilter = null;

            bool? isActiveFilter = null;
            if (comboStatusFilter.SelectedItem is StatusDisplay sd) isActiveFilter = sd.Value;
            else if (comboStatusFilter.SelectedItem is "All") isActiveFilter = null;
            
            string email = txtEmailFilter.Text.Trim();
            try
            {
                dataGridUsers.DataSource = _userService.GetUsers(roleFilter, isActiveFilter, email);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error");
            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e) { LoadUsers(); }
        private void BtnGeneratePassword_Click(object sender, EventArgs e) { txtPassword.Text = _userService.GeneratePassword(); }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try { var addr = new System.Net.Mail.MailAddress(email); return addr.Address == email.Trim(); }
            catch { return false; }
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
            
            string emailToValidate = txtEmail.Text.Trim();
            if (!IsValidEmail(emailToValidate))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            var confirm = MessageBox.Show("Confirm the correctness of the entered data", "Confirmation", MessageBoxButtons.YesNo);
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

        private void ClearUserForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            if (comboAddRole.Items.Count > 0) comboAddRole.SelectedIndex = 0;
            if (comboAddStatus.Items.Count > 0) comboAddStatus.SelectedValue = true;
        }
        
        private string Prompt(string message, string defaultValue) { return Interaction.InputBox(message, "Input", defaultValue); }

        #endregion

        #region Books Tab
        private void InitializeBooksTab()
        {
            SetupBooksTabUI(); // Sets up columns for dataGridBooks
            // Event handlers for buttons on this tab (btnBooksRefresh, btnBookEdit, btnBookDelete, btnDeepAnalytics)
            // should be wired in Designer.cs or here if not.
            if (this.btnBooksRefresh != null) this.btnBooksRefresh.Click += (s, e) => LoadBooksAdmin();
            if (this.btnBookEdit != null) this.btnBookEdit.Click += BtnBookEdit_Click;
            if (this.btnBookDelete != null) this.btnBookDelete.Click += BtnBookDelete_Click;
            if (this.btnDeepAnalytics != null)
            {
                this.btnDeepAnalytics.Click += BtnDeepAnalytics_Click;
                this.btnDeepAnalytics.Enabled = false; // Initially disabled
            }
            if (this.dataGridBooks != null) this.dataGridBooks.SelectionChanged += DataGridBooks_SelectionChanged_Admin;
        }
        
        private void SetupBooksTabUI()
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

        // Handler for “Deep Analytics” button
        private void BtnDeepAnalytics_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single book from the list to view deep analytics.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected book. Make sure DataGridView binds to the Book object list
            if (!(dataGridBooks.SelectedRows[0].DataBoundItem is Book selectedBookObject))
            {
                MessageBox.Show("Could not retrieve book data from the selected row.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int bookId = selectedBookObject.Id;

            BookAnalyticsReportData reportData = null;
            using (var connection = DAL.DbContext.GetConnection())
            {
                string sql = @"
                    WITH BookReviewsAvg AS (
                        SELECT id_book, AVG(grade_book) AS avg_book_grade_for_this_book, AVG(grade_cover) AS avg_cover_grade_for_this_book, COUNT(id) AS total_reviews_for_this_book
                        FROM review WHERE id_book = @BookIdParam GROUP BY id_book
                    ), AuthorWorksAvg AS (
                        SELECT b_auth.id_author, AVG(r.grade_book) AS avg_author_overall_book_grade, COUNT(DISTINCT r.id_book) AS total_reviewed_books_by_author
                        FROM review r JOIN book b_rev ON r.id_book = b_rev.id JOIN book b_auth ON b_rev.id_author = b_auth.id_author
                        WHERE b_auth.id_author = (SELECT id_author FROM book WHERE id = @BookIdParam) GROUP BY b_auth.id_author
                    ), DesignerWorksAvg AS (
                        SELECT b_des.id_designer, AVG(r.grade_cover) AS avg_designer_overall_cover_grade, COUNT(DISTINCT r.id_book) AS total_reviewed_covers_by_designer
                        FROM review r JOIN book b_rev ON r.id_book = b_rev.id JOIN book b_des ON b_rev.id_designer = b_des.id_designer
                        WHERE b_des.id_designer = (SELECT id_designer FROM book WHERE id = @BookIdParam) AND b_des.id_designer IS NOT NULL GROUP BY b_des.id_designer
                    )
                    SELECT
                        b.id AS BookId, b.name AS BookTitle, b.state::text AS BookState,
                        auth.first_name || ' ' || auth.last_name AS AuthorName,
                        COALESCE(ed.first_name || ' ' || ed.last_name, 'N/A') AS EditorName,
                        COALESCE(des.first_name || ' ' || des.last_name, 'N/A') AS DesignerName,
                        b.start_date AS StartDate, b.estimated_end_date AS EstimatedEndDate, b.publish_date AS PublishDate, 
                        b.age_restrictions::text AS AgeRestrictions, b.cover_image_path AS CoverImagePath,
                        COALESCE(bra.avg_book_grade_for_this_book, 0) AS ThisBookAvgBookGrade,
                        COALESCE(bra.avg_cover_grade_for_this_book, 0) AS ThisBookAvgCoverGrade,
                        COALESCE(bra.total_reviews_for_this_book, 0) AS ThisBookTotalReviews,
                        COALESCE(awa.avg_author_overall_book_grade, 0) AS AuthorOverallAvgBookGrade,
                        COALESCE(awa.total_reviewed_books_by_author, 0) AS AuthorTotalReviewedBooks,
                        COALESCE(dwa.avg_designer_overall_cover_grade, 0) AS DesignerOverallAvgCoverGrade,
                        COALESCE(dwa.total_reviewed_covers_by_designer, 0) AS DesignerTotalReviewedCovers
                    FROM book b
                    JOIN author auth ON b.id_author = auth.id
                    LEFT JOIN editor ed ON b.id_editor = ed.id
                    LEFT JOIN designer des ON b.id_designer = des.id
                    LEFT JOIN BookReviewsAvg bra ON b.id = bra.id_book
                    LEFT JOIN AuthorWorksAvg awa ON b.id_author = awa.id_author
                    LEFT JOIN DesignerWorksAvg dwa ON b.id_designer = dwa.id_designer
                    WHERE b.id = @BookIdParam;";
                
                try
                {
                    reportData = connection.QueryFirstOrDefault<BookAnalyticsReportData>(sql, new { BookIdParam = bookId });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching deep analytics data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (reportData != null)
            {
                BookDeepAnalyticsForm analyticsForm = new BookDeepAnalyticsForm(reportData);
                analyticsForm.Show(); 
            }
            else
            {
                MessageBox.Show("Could not retrieve analytics data for the selected book.", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Event handler of row selection event in dataGridBooks (on the “Books” tab)
        private void DataGridBooks_SelectionChanged_Admin(object sender, EventArgs e)
        {
            bool bookSelected = dataGridBooks.SelectedRows.Count == 1;

            if (btnDeepAnalytics != null)
            {
                btnDeepAnalytics.Enabled = bookSelected;
            }
            if (btnBookEdit != null)
            {
                btnBookEdit.Enabled = bookSelected;
            }
            if (btnBookDelete != null)
            {
                btnBookDelete.Enabled = bookSelected;
            }
        }
        #endregion

        #region Reviews Tab
        private void InitializeReviewsTab()
        {
            SetupReviewsTabUI();
            if (this.btnReviewsRefresh != null) this.btnReviewsRefresh.Click += (s, e) => LoadReviewsAdmin();
            if (this.btnReviewDelete != null) this.btnReviewDelete.Click += BtnReviewDelete_Click;
        }

        private void SetupReviewsTabUI()
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
        #endregion
        
        #region Analytics Tabs
        private void InitializeAnalyticsTabs()
        {
            // Populate ComboBox for Book Analytics
            if (comboBookAnalyticsQuery != null)
            {
                comboBookAnalyticsQuery.Items.Clear();
                comboBookAnalyticsQuery.Items.Add(new QueryDropDownItem { Text = "Select a report...", QueryType = BookAnalyticsQueryType.SelectPrompt });
                comboBookAnalyticsQuery.Items.Add(new QueryDropDownItem { Text = "Books by Age Restriction", QueryType = BookAnalyticsQueryType.BooksByAgeRestriction });
                comboBookAnalyticsQuery.Items.Add(new QueryDropDownItem { Text = "Book Count by State", QueryType = BookAnalyticsQueryType.BookCountByState });
                comboBookAnalyticsQuery.Items.Add(new QueryDropDownItem { Text = "Books Published for the period", QueryType = BookAnalyticsQueryType.BooksPublishedBetweenDates });
                comboBookAnalyticsQuery.Items.Add(new QueryDropDownItem { Text = "Reviews by Book", QueryType = BookAnalyticsQueryType.ReviewsByBook });
                comboBookAnalyticsQuery.DisplayMember = "Text";
                comboBookAnalyticsQuery.ValueMember = "QueryType"; // Ensure QueryDropDownItem has QueryType property
                comboBookAnalyticsQuery.SelectedIndex = 0;
                comboBookAnalyticsQuery.SelectedIndexChanged += ComboBookAnalyticsQuery_SelectedIndexChanged;
            }
            if(btnRunBookAnalyticsQuery != null) btnRunBookAnalyticsQuery.Click += BtnRunBookAnalyticsQuery_Click;

            // Populate ComboBox for User Activity
            if (comboUserActivityQuery != null)
            {
                comboUserActivityQuery.Items.Clear();
                comboUserActivityQuery.Items.Add(new QueryDropDownItem { Text = "Select a report...", QueryType = UserActivityQueryType.SelectPrompt });
                comboUserActivityQuery.Items.Add(new QueryDropDownItem { Text = "Inactive Users by Role", QueryType = UserActivityQueryType.InactiveUsersByRole });
                comboUserActivityQuery.Items.Add(new QueryDropDownItem { Text = "Books Awaiting Assignment", QueryType = UserActivityQueryType.BooksAwaitingAssignment });
                comboUserActivityQuery.Items.Add(new QueryDropDownItem { Text = "Employee Workload", QueryType = UserActivityQueryType.EmployeeWorkload });
                comboUserActivityQuery.Items.Add(new QueryDropDownItem { Text = "Reviews by Critic", QueryType = UserActivityQueryType.ReviewsByCritic });
                comboUserActivityQuery.Items.Add(new QueryDropDownItem { Text = "Reviews by Critic for the period", QueryType = UserActivityQueryType.ReviewsByCriticInDateRange });
                comboUserActivityQuery.DisplayMember = "Text";
                comboUserActivityQuery.ValueMember = "QueryType";
                comboUserActivityQuery.SelectedIndex = 0;
                comboUserActivityQuery.SelectedIndexChanged += ComboUserActivityQuery_SelectedIndexChanged;
            }
            if(btnRunUserActivityQuery != null) btnRunUserActivityQuery.Click += BtnRunUserActivityQuery_Click;

            // Hide all parameter panels initially
            HideAllAnalyticsParameterPanels();

            // Populate parameter ComboBoxes
            if(comboAnalyticsAgeRestriction != null)
            {
                comboAnalyticsAgeRestriction.DataSource = Enum.GetValues(typeof(AgeRestriction))
                    .Cast<AgeRestriction>()
                    .Select(ar => new { Name = ar.ToString().Replace("_", "").Replace("plus", "+"), Value = ar })
                    .ToList();
                comboAnalyticsAgeRestriction.DisplayMember = "Name";
                comboAnalyticsAgeRestriction.ValueMember = "Value";
                if(comboAnalyticsAgeRestriction.Items.Count > 0) comboAnalyticsAgeRestriction.SelectedIndex = 0;
            }
            if (comboUserActivityRole != null)
            {
                comboUserActivityRole.Items.Clear();
                comboUserActivityRole.Items.Add("All Roles");
                comboUserActivityRole.Items.AddRange(new[] { "author", "editor", "critic", "designer" });
                comboUserActivityRole.SelectedIndex = 0;
            }
            PopulateAnalyticsBookSelectComboBox();
            PopulateAnalyticsCriticSelectComboBox();

            if (dtpAnalyticsStartDate != null) dtpAnalyticsStartDate.Format = DateTimePickerFormat.Short;
            if (dtpAnalyticsEndDate != null) dtpAnalyticsEndDate.Format = DateTimePickerFormat.Short;
            if (dtpUserActivityStartDate != null) dtpUserActivityStartDate.Format = DateTimePickerFormat.Short;
            if (dtpUserActivityEndDate != null) dtpUserActivityEndDate.Format = DateTimePickerFormat.Short;
        }

        private void HideAllAnalyticsParameterPanels()
        {
            if(panelAnalyticsParamDateRange != null) panelAnalyticsParamDateRange.Visible = false;
            if(panelAnalyticsParamAge != null) panelAnalyticsParamAge.Visible = false;
            if(panelAnalyticsParamBook != null) panelAnalyticsParamBook.Visible = false;

            if(panelUserActivityParamRole != null) panelUserActivityParamRole.Visible = false;
            if(panelUserActivityParamCritic != null) panelUserActivityParamCritic.Visible = false;
            if(panelUserActivityParamDateRange != null) panelUserActivityParamDateRange.Visible = false;
        }

        private void PopulateAnalyticsBookSelectComboBox()
        {
            if (comboAnalyticsBookSelect == null) return;
            try
            {
                var books = _bookService.GetAllBooks().Select(b => new { b.Id, b.Name }).ToList();
                comboAnalyticsBookSelect.DataSource = books;
                comboAnalyticsBookSelect.DisplayMember = "Name";
                comboAnalyticsBookSelect.ValueMember = "Id";
                if (books.Any()) comboAnalyticsBookSelect.SelectedIndex = 0;
            }
            catch (Exception ex) { Console.WriteLine($"Error populating books combobox: {ex.Message}"); }
        }

        private void PopulateAnalyticsCriticSelectComboBox()
        {
            if (comboAnalyticsCriticSelect == null) return;
            try
            {
                // Assuming GetUsers can fetch only critics and we need Id and FullName
                var critics = _userService.GetUsers(role: "critic")
                                          .Select(c => new { c.Id, FullName = c.FirstName + " " + c.LastName })
                                          .ToList();
                comboAnalyticsCriticSelect.DataSource = critics;
                comboAnalyticsCriticSelect.DisplayMember = "FullName";
                comboAnalyticsCriticSelect.ValueMember = "Id";
                if (critics.Any()) comboAnalyticsCriticSelect.SelectedIndex = 0;
            }
            catch (Exception ex) { Console.WriteLine($"Error populating critics combobox: {ex.Message}"); }
        }


        private void ComboBookAnalyticsQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllAnalyticsParameterPanels(); // Hide all first
            var selectedItem = comboBookAnalyticsQuery.SelectedItem as QueryDropDownItem;
            if (selectedItem == null || selectedItem.QueryType == null) return;
            BookAnalyticsQueryType queryType = (BookAnalyticsQueryType)selectedItem.QueryType;

            switch (queryType)
            {
                case BookAnalyticsQueryType.BooksPublishedBetweenDates:
                    if (panelAnalyticsParamDateRange != null) panelAnalyticsParamDateRange.Visible = true;
                    break;
                case BookAnalyticsQueryType.BooksByAgeRestriction:
                    if (panelAnalyticsParamAge != null) panelAnalyticsParamAge.Visible = true;
                    break;
                case BookAnalyticsQueryType.ReviewsByBook:
                    if (panelAnalyticsParamBook != null) panelAnalyticsParamBook.Visible = true; // Show book selection panel
                    break;
            }
        }

        private void ComboUserActivityQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllAnalyticsParameterPanels(); // Hide all first
            var selectedItem = comboUserActivityQuery.SelectedItem as QueryDropDownItem;
            if (selectedItem == null || selectedItem.QueryType == null) return;
            UserActivityQueryType queryType = (UserActivityQueryType)selectedItem.QueryType;
            
            switch (queryType)
            {
                case UserActivityQueryType.InactiveUsersByRole:
                    if (panelUserActivityParamRole != null) panelUserActivityParamRole.Visible = true;
                    break;
                case UserActivityQueryType.ReviewsByCritic:
                    if (panelUserActivityParamCritic != null) panelUserActivityParamCritic.Visible = true;
                    break;
                case UserActivityQueryType.ReviewsByCriticInDateRange:
                    if (panelUserActivityParamCritic != null) panelUserActivityParamCritic.Visible = true;
                    if (panelUserActivityParamDateRange != null) panelUserActivityParamDateRange.Visible = true;
                    break;

            }
        }

         private void BtnRunBookAnalyticsQuery_Click(object sender, EventArgs e)
        {
            if (!(comboBookAnalyticsQuery.SelectedItem is QueryDropDownItem selectedQueryItem) || selectedQueryItem.QueryType == null)
            {
                MessageBox.Show("Please select a report type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BookAnalyticsQueryType queryType = (BookAnalyticsQueryType)selectedQueryItem.QueryType;
            object result = null;
            string sql = "";

            try
            {
                using (var connection = DAL.DbContext.GetConnection())
                {
                    switch (queryType)
                    {
                        case BookAnalyticsQueryType.BooksByAgeRestriction:
                            if (comboAnalyticsAgeRestriction.SelectedValue == null) { MessageBox.Show("Please select an age restriction."); return; }
                            AgeRestriction age = (AgeRestriction)comboAnalyticsAgeRestriction.SelectedValue;
                            string ageString = age.ToString().TrimStart('_').Replace("plus", "+");
                            sql = @"SELECT b.id AS BookId, b.name AS BookTitle, 
                                           a.first_name || ' ' || a.last_name AS AuthorName, 
                                           b.state::text AS BookState, b.age_restrictions::text AS AgeRestrictions 
                                    FROM book b JOIN author a ON b.id_author = a.id 
                                    WHERE b.age_restrictions = @AgeParam::age_restriction ORDER BY b.name;";
                            result = connection.Query<SimpleBookReportItem>(sql, new { AgeParam = ageString }).ToList();
                            break;

                        case BookAnalyticsQueryType.BookCountByState:
                            sql = @"SELECT state::text AS BookState, COUNT(*) AS NumberOfBooks 
                                    FROM book GROUP BY state ORDER BY state;";
                            result = connection.Query<BookCountByStateItem>(sql).ToList();
                            break;

                        case BookAnalyticsQueryType.BooksPublishedBetweenDates:
                            DateTime startDate = dtpAnalyticsStartDate.Value.Date;
                            DateTime endDate = dtpAnalyticsEndDate.Value.Date;
                            if (startDate > endDate) { MessageBox.Show("Start date must be before end date."); return; }
                            sql = @"SELECT b.id AS BookId, b.name AS BookTitle, 
                                           a.first_name || ' ' || a.last_name AS AuthorName, b.publish_date AS PublishDate 
                                    FROM book b JOIN author a ON b.id_author = a.id 
                                    WHERE b.state = 'published' AND b.publish_date BETWEEN @StartDate AND @EndDate 
                                    ORDER BY b.publish_date DESC, b.name;";
                            result = connection.Query<SimpleBookReportItem>(sql, new { StartDate = startDate, EndDate = endDate }).ToList();
                            break;
                        case BookAnalyticsQueryType.ReviewsByBook:
                            if (comboAnalyticsBookSelect == null || comboAnalyticsBookSelect.SelectedValue == null) { MessageBox.Show("Please select a book."); return; }
                            int bookIdRev = (int)comboAnalyticsBookSelect.SelectedValue;
                            sql = @"SELECT r.id AS ReviewId, r.date_time as DateTime, c.first_name || ' ' || c.last_name AS CriticName, 
                                           r.grade_book AS GradeBook, r.grade_cover AS GradeCover, r.text AS ReviewTextRtf 
                                    FROM review r JOIN critic c ON r.id_critic = c.id 
                                    WHERE r.id_book = @BookIdParam ORDER BY r.date_time DESC;";
                            result = connection.Query<SimpleReviewReportItem>(sql, new { BookIdParam = bookIdRev }).ToList();
                            break;
                    }
                }
                dataGridBookAnalytics.DataSource = result;
                if (result == null || (result is System.Collections.IList list && list.Count == 0))
                {
                    MessageBox.Show("No data found for the selected criteria.", "Query Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing report: {ex.Message}", "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridBookAnalytics.DataSource = null;
            }
        }

        private void BtnRunUserActivityQuery_Click(object sender, EventArgs e)
        {
            if (!(comboUserActivityQuery.SelectedItem is QueryDropDownItem selectedQueryItem) || selectedQueryItem.QueryType == null)
            {
                MessageBox.Show("Please select a report type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserActivityQueryType queryType = (UserActivityQueryType)selectedQueryItem.QueryType;
            object result = null;
            string sql = "";

            try
            {
                using (var connection = DAL.DbContext.GetConnection())
                {
                    switch (queryType)
                    {
                        case UserActivityQueryType.InactiveUsersByRole:
                            if (panelUserActivityParamRole == null || comboUserActivityRole.SelectedItem == null) { /* error */ return; }
                            string selectedRole = comboUserActivityRole.SelectedItem.ToString();
                             // Запрос UNION ALL для всех ролей
                            sql = @"SELECT id, first_name as FirstName, last_name as LastName, email, 'author' AS Role FROM author WHERE status = FALSE
                                    UNION ALL
                                    SELECT id, first_name as FirstName, last_name as LastName, email, 'editor' AS Role FROM editor WHERE status = FALSE
                                    UNION ALL
                                    SELECT id, first_name as FirstName, last_name as LastName, email, 'designer' AS Role FROM designer WHERE status = FALSE
                                    UNION ALL
                                    SELECT id, first_name as FirstName, last_name as LastName, email, 'critic' AS Role FROM critic WHERE status = FALSE
                                    ORDER BY Role, LastName, FirstName;";
                            result = connection.Query<InactiveUserReportItem>(sql).ToList();
                            break;
                        case UserActivityQueryType.BooksAwaitingAssignment:
                            sql = @"SELECT b.id AS BookId, b.name AS BookTitle, auth.first_name || ' ' || auth.last_name AS AuthorName, 
                                           b.state::text AS CurrentState,
                                           CASE WHEN b.state = 'in_progress' AND b.id_editor IS NULL THEN 'Needs Editor'
                                                WHEN b.state = 'editing' AND b.id_designer IS NULL THEN 'Needs Designer'
                                                ELSE 'N/A' END AS AssignmentStatus,
                                           b.start_date AS StartDate
                                    FROM book b JOIN author auth ON b.id_author = auth.id
                                    WHERE (b.state = 'in_progress' AND b.id_editor IS NULL) OR (b.state = 'editing' AND b.id_designer IS NULL)
                                    ORDER BY b.start_date, b.name;";
                            result = connection.Query<BookAwaitingAssignmentItem>(sql).ToList();
                            break;
                        case UserActivityQueryType.EmployeeWorkload:
                            sql = @"SELECT e.id AS EmployeeId, e.first_name || ' ' || e.last_name AS EmployeeName, e.email AS EmployeeEmail, 'Editor' AS EmployeeRole, COUNT(b.id) AS ActiveBooksCount
                                    FROM editor e LEFT JOIN book b ON e.id = b.id_editor AND b.state IN ('editing', 'in_progress')
                                    WHERE e.status = TRUE GROUP BY e.id, e.first_name, e.last_name, e.email
                                    UNION ALL
                                    SELECT d.id AS EmployeeId, d.first_name || ' ' || d.last_name AS EmployeeName, d.email AS EmployeeEmail, 'Designer' AS EmployeeRole, COUNT(b.id) AS ActiveBooksCount
                                    FROM designer d LEFT JOIN book b ON d.id = b.id_designer AND b.state IN ('editing', 'ready_to_print') 
                                    WHERE d.status = TRUE GROUP BY d.id, d.first_name, d.last_name, d.email
                                    ORDER BY EmployeeRole, ActiveBooksCount DESC, EmployeeName;";
                            result = connection.Query<EmployeeWorkloadItem>(sql).ToList();
                            break;
                         case UserActivityQueryType.ReviewsByCritic:
                            if (comboAnalyticsCriticSelect == null || comboAnalyticsCriticSelect.SelectedValue == null) { MessageBox.Show("Please select a critic."); return; }
                            int criticIdRev = (int)comboAnalyticsCriticSelect.SelectedValue;
                            sql = @"SELECT r.id AS ReviewId, r.date_time as DateTime,
                                           c.first_name || ' ' || c.last_name AS CriticName,
                                           b.name AS BookName,
                                           r.grade_book AS GradeBook, r.grade_cover AS GradeCover, r.text AS ReviewTextRtf 
                                    FROM review r JOIN book b ON r.id_book = b.id
                                    JOIN critic c ON r.id_critic = c.id
                                    WHERE r.id_critic = @CriticIdParam
                                    ORDER BY r.date_time DESC;";
                            result = connection.Query<SimpleReviewReportItem>(sql, new { CriticIdParam = criticIdRev }).ToList();
                            break;
                         case UserActivityQueryType.ReviewsByCriticInDateRange: // NEW CASE
                            if (comboAnalyticsCriticSelect == null || comboAnalyticsCriticSelect.SelectedValue == null) { MessageBox.Show("Please select a critic."); return; }
                            if (dtpUserActivityStartDate == null || dtpUserActivityEndDate == null) // Check if date pickers exist
                            {
                                MessageBox.Show("Елементи керування діапазоном дат не знайдені.", "Помилка UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            int selectedCriticId = (int)comboAnalyticsCriticSelect.SelectedValue;
                            DateTime startDate = dtpUserActivityStartDate.Value.Date;
                            DateTime endDate = dtpUserActivityEndDate.Value.Date.AddDays(1).AddTicks(-1);
                            
                            if (startDate > endDate) { MessageBox.Show("Start date must be before end date."); return; }

                            sql = @"SELECT r.id AS ReviewId, r.date_time as DateTime,
                                           c.first_name || ' ' || c.last_name AS CriticName,
                                           b.name AS BookName,
                                           r.grade_book AS GradeBook, r.grade_cover AS GradeCover, r.text AS ReviewTextRtf
                                    FROM review r
                                    JOIN book b ON r.id_book = b.id
                                    JOIN critic c ON r.id_critic = c.id
                                    WHERE r.id_critic = @CriticIdParam
                                      AND r.date_time >= @StartDateParam
                                      AND r.date_time <= @EndDateParam
                                    ORDER BY r.date_time DESC;";
                            result = connection.Query<SimpleReviewReportItem>(sql, new
                            {
                                CriticIdParam = selectedCriticId,
                                StartDateParam = startDate,
                                EndDateParam = endDate
                            }).ToList();
                            break;

                    }
                }
                dataGridUserActivity.DataSource = result;
                 if (result == null || (result is System.Collections.IList list && list.Count == 0))
                {
                    MessageBox.Show("No data found for the selected criteria.", "Query Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing report: {ex.Message}", "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridUserActivity.DataSource = null;
            }
        }
        #endregion
    }
}