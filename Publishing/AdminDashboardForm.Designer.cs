namespace PublishingSystem.UI
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // --- Control Fields ---
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TabControl tabControlMain;
        
        private System.Windows.Forms.TabPage tabAddUser;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox comboAddRole;
        private System.Windows.Forms.ComboBox comboAddStatus;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelStatus;

        private System.Windows.Forms.TabPage tabViewUsers;
        private System.Windows.Forms.ComboBox comboRoleFilter;
        private System.Windows.Forms.ComboBox comboStatusFilter;
        private System.Windows.Forms.TextBox txtEmailFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Label labelRoleFilter;
        private System.Windows.Forms.Label labelStatusFilter;
        private System.Windows.Forms.Label labelEmailFilter;

        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.DataGridView dataGridBooks;
        private System.Windows.Forms.Button btnBooksRefresh;
        private System.Windows.Forms.Button btnBookEdit;
        private System.Windows.Forms.Button btnBookDelete;

        private System.Windows.Forms.TabPage tabReviews;
        private System.Windows.Forms.DataGridView dataGridReviews;
        private System.Windows.Forms.Button btnReviewsRefresh;
        private System.Windows.Forms.Button btnReviewDelete;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabAddUser = new System.Windows.Forms.TabPage();
            labelFirstName = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            labelLastName = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            labelEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            labelPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            btnGeneratePassword = new System.Windows.Forms.Button();
            labelRole = new System.Windows.Forms.Label();
            comboAddRole = new System.Windows.Forms.ComboBox();
            labelStatus = new System.Windows.Forms.Label();
            comboAddStatus = new System.Windows.Forms.ComboBox();
            btnAddUser = new System.Windows.Forms.Button();
            tabViewUsers = new System.Windows.Forms.TabPage();
            labelRoleFilter = new System.Windows.Forms.Label();
            comboRoleFilter = new System.Windows.Forms.ComboBox();
            labelStatusFilter = new System.Windows.Forms.Label();
            comboStatusFilter = new System.Windows.Forms.ComboBox();
            labelEmailFilter = new System.Windows.Forms.Label();
            txtEmailFilter = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            dataGridUsers = new System.Windows.Forms.DataGridView();
            btnEditUser = new System.Windows.Forms.Button();
            btnDeleteUser = new System.Windows.Forms.Button();
            tabBooks = new System.Windows.Forms.TabPage();
            btnDeepAnalytics = new System.Windows.Forms.Button();
            btnBookDelete = new System.Windows.Forms.Button();
            btnBookEdit = new System.Windows.Forms.Button();
            btnBooksRefresh = new System.Windows.Forms.Button();
            dataGridBooks = new System.Windows.Forms.DataGridView();
            tabReviews = new System.Windows.Forms.TabPage();
            btnReviewDelete = new System.Windows.Forms.Button();
            btnReviewsRefresh = new System.Windows.Forms.Button();
            dataGridReviews = new System.Windows.Forms.DataGridView();
            tabBookAnalytics = new System.Windows.Forms.TabPage();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            lblAnalyticsQuerySelect = new System.Windows.Forms.Label();
            comboBookAnalyticsQuery = new System.Windows.Forms.ComboBox();
            btnRunBookAnalyticsQuery = new System.Windows.Forms.Button();
            panelAnalyticsParamBook = new System.Windows.Forms.Panel();
            comboAnalyticsBookSelect = new System.Windows.Forms.ComboBox();
            lblSelectBook = new System.Windows.Forms.Label();
            panelAnalyticsParamDateRange = new System.Windows.Forms.Panel();
            lblEndDate = new System.Windows.Forms.Label();
            lblStartDate = new System.Windows.Forms.Label();
            dtpAnalyticsEndDate = new System.Windows.Forms.DateTimePicker();
            dtpAnalyticsStartDate = new System.Windows.Forms.DateTimePicker();
            panelAnalyticsParamAge = new System.Windows.Forms.Panel();
            lblAgeRestrictions = new System.Windows.Forms.Label();
            comboAnalyticsAgeRestriction = new System.Windows.Forms.ComboBox();
            dataGridBookAnalytics = new System.Windows.Forms.DataGridView();
            tabUserActivity = new System.Windows.Forms.TabPage();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            lblUserActivityQuerySelect = new System.Windows.Forms.Label();
            comboUserActivityQuery = new System.Windows.Forms.ComboBox();
            btnRunUserActivityQuery = new System.Windows.Forms.Button();
            panelUserActivityParamCritic = new System.Windows.Forms.Panel();
            comboAnalyticsCriticSelect = new System.Windows.Forms.ComboBox();
            lblSelectCritic = new System.Windows.Forms.Label();
            panelUserActivityParamRole = new System.Windows.Forms.Panel();
            comboUserActivityRole = new System.Windows.Forms.ComboBox();
            dataGridUserActivity = new System.Windows.Forms.DataGridView();
            tableLayoutPanelMain.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabAddUser.SuspendLayout();
            tabViewUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).BeginInit();
            tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridBooks).BeginInit();
            tabReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridReviews).BeginInit();
            tabBookAnalytics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelAnalyticsParamBook.SuspendLayout();
            panelAnalyticsParamDateRange.SuspendLayout();
            panelAnalyticsParamAge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridBookAnalytics).BeginInit();
            tabUserActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panelUserActivityParamCritic.SuspendLayout();
            panelUserActivityParamRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUserActivity).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(tabControlMain, 0, 1);
            tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMain.Size = new System.Drawing.Size(800, 450);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabAddUser);
            tabControlMain.Controls.Add(tabViewUsers);
            tabControlMain.Controls.Add(tabBooks);
            tabControlMain.Controls.Add(tabReviews);
            tabControlMain.Controls.Add(tabBookAnalytics);
            tabControlMain.Controls.Add(tabUserActivity);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Location = new System.Drawing.Point(3, 37);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(794, 410);
            tabControlMain.TabIndex = 0;
            // 
            // tabAddUser
            // 
            tabAddUser.Controls.Add(labelFirstName);
            tabAddUser.Controls.Add(txtFirstName);
            tabAddUser.Controls.Add(labelLastName);
            tabAddUser.Controls.Add(txtLastName);
            tabAddUser.Controls.Add(labelEmail);
            tabAddUser.Controls.Add(txtEmail);
            tabAddUser.Controls.Add(labelPassword);
            tabAddUser.Controls.Add(txtPassword);
            tabAddUser.Controls.Add(btnGeneratePassword);
            tabAddUser.Controls.Add(labelRole);
            tabAddUser.Controls.Add(comboAddRole);
            tabAddUser.Controls.Add(labelStatus);
            tabAddUser.Controls.Add(comboAddStatus);
            tabAddUser.Controls.Add(btnAddUser);
            tabAddUser.Location = new System.Drawing.Point(4, 24);
            tabAddUser.Name = "tabAddUser";
            tabAddUser.Padding = new System.Windows.Forms.Padding(10);
            tabAddUser.Size = new System.Drawing.Size(786, 382);
            tabAddUser.TabIndex = 0;
            tabAddUser.Text = "Manage Users";
            tabAddUser.UseVisualStyleBackColor = true;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new System.Drawing.Point(13, 16);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new System.Drawing.Size(67, 15);
            labelFirstName.TabIndex = 0;
            labelFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(100, 13);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(200, 23);
            txtFirstName.TabIndex = 1;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new System.Drawing.Point(13, 45);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new System.Drawing.Size(66, 15);
            labelLastName.TabIndex = 2;
            labelLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(100, 42);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(200, 23);
            txtLastName.TabIndex = 3;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new System.Drawing.Point(13, 74);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(39, 15);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(100, 71);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(200, 23);
            txtEmail.TabIndex = 5;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new System.Drawing.Point(13, 104);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(60, 15);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(100, 101);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(200, 23);
            txtPassword.TabIndex = 7;
            // 
            // btnGeneratePassword
            // 
            btnGeneratePassword.Location = new System.Drawing.Point(306, 100);
            btnGeneratePassword.Name = "btnGeneratePassword";
            btnGeneratePassword.Size = new System.Drawing.Size(75, 25);
            btnGeneratePassword.TabIndex = 8;
            btnGeneratePassword.Text = "Generate";
            btnGeneratePassword.UseVisualStyleBackColor = true;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new System.Drawing.Point(13, 133);
            labelRole.Name = "labelRole";
            labelRole.Size = new System.Drawing.Size(33, 15);
            labelRole.TabIndex = 9;
            labelRole.Text = "Role:";
            // 
            // comboAddRole
            // 
            comboAddRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAddRole.FormattingEnabled = true;
            comboAddRole.Location = new System.Drawing.Point(100, 130);
            comboAddRole.Name = "comboAddRole";
            comboAddRole.Size = new System.Drawing.Size(200, 23);
            comboAddRole.TabIndex = 10;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new System.Drawing.Point(13, 162);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(42, 15);
            labelStatus.TabIndex = 11;
            labelStatus.Text = "Status:";
            // 
            // comboAddStatus
            // 
            comboAddStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAddStatus.FormattingEnabled = true;
            comboAddStatus.Location = new System.Drawing.Point(100, 159);
            comboAddStatus.Name = "comboAddStatus";
            comboAddStatus.Size = new System.Drawing.Size(200, 23);
            comboAddStatus.TabIndex = 12;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new System.Drawing.Point(100, 198);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new System.Drawing.Size(100, 30);
            btnAddUser.TabIndex = 13;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // tabViewUsers
            // 
            tabViewUsers.Controls.Add(labelRoleFilter);
            tabViewUsers.Controls.Add(comboRoleFilter);
            tabViewUsers.Controls.Add(labelStatusFilter);
            tabViewUsers.Controls.Add(comboStatusFilter);
            tabViewUsers.Controls.Add(labelEmailFilter);
            tabViewUsers.Controls.Add(txtEmailFilter);
            tabViewUsers.Controls.Add(btnSearch);
            tabViewUsers.Controls.Add(dataGridUsers);
            tabViewUsers.Controls.Add(btnEditUser);
            tabViewUsers.Controls.Add(btnDeleteUser);
            tabViewUsers.Location = new System.Drawing.Point(4, 24);
            tabViewUsers.Name = "tabViewUsers";
            tabViewUsers.Padding = new System.Windows.Forms.Padding(10);
            tabViewUsers.Size = new System.Drawing.Size(786, 378);
            tabViewUsers.TabIndex = 1;
            tabViewUsers.Text = "View Users";
            tabViewUsers.UseVisualStyleBackColor = true;
            // 
            // labelRoleFilter
            // 
            labelRoleFilter.AutoSize = true;
            labelRoleFilter.Location = new System.Drawing.Point(13, 16);
            labelRoleFilter.Name = "labelRoleFilter";
            labelRoleFilter.Size = new System.Drawing.Size(33, 15);
            labelRoleFilter.TabIndex = 0;
            labelRoleFilter.Text = "Role:";
            // 
            // comboRoleFilter
            // 
            comboRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboRoleFilter.FormattingEnabled = true;
            comboRoleFilter.Location = new System.Drawing.Point(52, 13);
            comboRoleFilter.Name = "comboRoleFilter";
            comboRoleFilter.Size = new System.Drawing.Size(121, 23);
            comboRoleFilter.TabIndex = 1;
            // 
            // labelStatusFilter
            // 
            labelStatusFilter.AutoSize = true;
            labelStatusFilter.Location = new System.Drawing.Point(188, 16);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new System.Drawing.Size(42, 15);
            labelStatusFilter.TabIndex = 2;
            labelStatusFilter.Text = "Status:";
            // 
            // comboStatusFilter
            // 
            comboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboStatusFilter.FormattingEnabled = true;
            comboStatusFilter.Location = new System.Drawing.Point(236, 13);
            comboStatusFilter.Name = "comboStatusFilter";
            comboStatusFilter.Size = new System.Drawing.Size(121, 23);
            comboStatusFilter.TabIndex = 3;
            // 
            // labelEmailFilter
            // 
            labelEmailFilter.AutoSize = true;
            labelEmailFilter.Location = new System.Drawing.Point(372, 16);
            labelEmailFilter.Name = "labelEmailFilter";
            labelEmailFilter.Size = new System.Drawing.Size(39, 15);
            labelEmailFilter.TabIndex = 4;
            labelEmailFilter.Text = "Email:";
            // 
            // txtEmailFilter
            // 
            txtEmailFilter.Location = new System.Drawing.Point(417, 13);
            txtEmailFilter.Name = "txtEmailFilter";
            txtEmailFilter.Size = new System.Drawing.Size(150, 23);
            txtEmailFilter.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(582, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(75, 25);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridUsers
            // 
            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.AllowUserToDeleteRows = false;
            dataGridUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            dataGridUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsers.Location = new System.Drawing.Point(13, 49);
            dataGridUsers.Name = "dataGridUsers";
            dataGridUsers.ReadOnly = true;
            dataGridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridUsers.Size = new System.Drawing.Size(760, 274);
            dataGridUsers.TabIndex = 7;
            // 
            // btnEditUser
            // 
            btnEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnEditUser.Location = new System.Drawing.Point(13, 335);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new System.Drawing.Size(100, 30);
            btnEditUser.TabIndex = 8;
            btnEditUser.Text = "Edit Selected";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnDeleteUser.Location = new System.Drawing.Point(123, 335);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new System.Drawing.Size(110, 30);
            btnDeleteUser.TabIndex = 9;
            btnDeleteUser.Text = "Delete Selected";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // tabBooks
            // 
            tabBooks.Controls.Add(btnDeepAnalytics);
            tabBooks.Controls.Add(btnBookDelete);
            tabBooks.Controls.Add(btnBookEdit);
            tabBooks.Controls.Add(btnBooksRefresh);
            tabBooks.Controls.Add(dataGridBooks);
            tabBooks.Location = new System.Drawing.Point(4, 24);
            tabBooks.Name = "tabBooks";
            tabBooks.Padding = new System.Windows.Forms.Padding(10);
            tabBooks.Size = new System.Drawing.Size(786, 378);
            tabBooks.TabIndex = 2;
            tabBooks.Text = "Books";
            tabBooks.UseVisualStyleBackColor = true;
            // 
            // btnDeepAnalytics
            // 
            btnDeepAnalytics.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnDeepAnalytics.Enabled = false;
            btnDeepAnalytics.Location = new System.Drawing.Point(256, 331);
            btnDeepAnalytics.Name = "btnDeepAnalytics";
            btnDeepAnalytics.Size = new System.Drawing.Size(75, 39);
            btnDeepAnalytics.TabIndex = 4;
            btnDeepAnalytics.Text = "Deep Analytics";
            btnDeepAnalytics.UseVisualStyleBackColor = true;
            // 
            // btnBookDelete
            // 
            btnBookDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnBookDelete.Location = new System.Drawing.Point(175, 335);
            btnBookDelete.Name = "btnBookDelete";
            btnBookDelete.Size = new System.Drawing.Size(75, 30);
            btnBookDelete.TabIndex = 3;
            btnBookDelete.Text = "Delete";
            btnBookDelete.UseVisualStyleBackColor = true;
            // 
            // btnBookEdit
            // 
            btnBookEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnBookEdit.Location = new System.Drawing.Point(94, 335);
            btnBookEdit.Name = "btnBookEdit";
            btnBookEdit.Size = new System.Drawing.Size(75, 30);
            btnBookEdit.TabIndex = 2;
            btnBookEdit.Text = "Edit";
            btnBookEdit.UseVisualStyleBackColor = true;
            // 
            // btnBooksRefresh
            // 
            btnBooksRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnBooksRefresh.Location = new System.Drawing.Point(13, 335);
            btnBooksRefresh.Name = "btnBooksRefresh";
            btnBooksRefresh.Size = new System.Drawing.Size(75, 30);
            btnBooksRefresh.TabIndex = 1;
            btnBooksRefresh.Text = "Refresh";
            btnBooksRefresh.UseVisualStyleBackColor = true;
            // 
            // dataGridBooks
            // 
            dataGridBooks.AllowUserToAddRows = false;
            dataGridBooks.AllowUserToDeleteRows = false;
            dataGridBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            dataGridBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBooks.Location = new System.Drawing.Point(13, 13);
            dataGridBooks.Name = "dataGridBooks";
            dataGridBooks.ReadOnly = true;
            dataGridBooks.Size = new System.Drawing.Size(760, 313);
            dataGridBooks.TabIndex = 0;
            // 
            // tabReviews
            // 
            tabReviews.Controls.Add(btnReviewDelete);
            tabReviews.Controls.Add(btnReviewsRefresh);
            tabReviews.Controls.Add(dataGridReviews);
            tabReviews.Location = new System.Drawing.Point(4, 24);
            tabReviews.Name = "tabReviews";
            tabReviews.Padding = new System.Windows.Forms.Padding(10);
            tabReviews.Size = new System.Drawing.Size(786, 378);
            tabReviews.TabIndex = 3;
            tabReviews.Text = "Reviews";
            tabReviews.UseVisualStyleBackColor = true;
            // 
            // btnReviewDelete
            // 
            btnReviewDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnReviewDelete.Location = new System.Drawing.Point(94, 335);
            btnReviewDelete.Name = "btnReviewDelete";
            btnReviewDelete.Size = new System.Drawing.Size(75, 30);
            btnReviewDelete.TabIndex = 2;
            btnReviewDelete.Text = "Delete";
            btnReviewDelete.UseVisualStyleBackColor = true;
            // 
            // btnReviewsRefresh
            // 
            btnReviewsRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            btnReviewsRefresh.Location = new System.Drawing.Point(13, 335);
            btnReviewsRefresh.Name = "btnReviewsRefresh";
            btnReviewsRefresh.Size = new System.Drawing.Size(75, 30);
            btnReviewsRefresh.TabIndex = 1;
            btnReviewsRefresh.Text = "Refresh";
            btnReviewsRefresh.UseVisualStyleBackColor = true;
            // 
            // dataGridReviews
            // 
            dataGridReviews.AllowUserToAddRows = false;
            dataGridReviews.AllowUserToDeleteRows = false;
            dataGridReviews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            dataGridReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridReviews.Location = new System.Drawing.Point(13, 13);
            dataGridReviews.Name = "dataGridReviews";
            dataGridReviews.ReadOnly = true;
            dataGridReviews.Size = new System.Drawing.Size(760, 313);
            dataGridReviews.TabIndex = 0;
            // 
            // tabBookAnalytics
            // 
            tabBookAnalytics.Controls.Add(splitContainer1);
            tabBookAnalytics.Location = new System.Drawing.Point(4, 24);
            tabBookAnalytics.Name = "tabBookAnalytics";
            tabBookAnalytics.Padding = new System.Windows.Forms.Padding(3);
            tabBookAnalytics.Size = new System.Drawing.Size(786, 378);
            tabBookAnalytics.TabIndex = 4;
            tabBookAnalytics.Text = "Book Analytics";
            tabBookAnalytics.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblAnalyticsQuerySelect);
            splitContainer1.Panel1.Controls.Add(comboBookAnalyticsQuery);
            splitContainer1.Panel1.Controls.Add(btnRunBookAnalyticsQuery);
            splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelAnalyticsParamBook);
            splitContainer1.Panel2.Controls.Add(panelAnalyticsParamDateRange);
            splitContainer1.Panel2.Controls.Add(panelAnalyticsParamAge);
            splitContainer1.Panel2.Controls.Add(dataGridBookAnalytics);
            splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            splitContainer1.Size = new System.Drawing.Size(780, 372);
            splitContainer1.SplitterDistance = 27;
            splitContainer1.TabIndex = 6;
            // 
            // lblAnalyticsQuerySelect
            // 
            lblAnalyticsQuerySelect.Location = new System.Drawing.Point(3, 1);
            lblAnalyticsQuerySelect.Name = "lblAnalyticsQuerySelect";
            lblAnalyticsQuerySelect.Size = new System.Drawing.Size(79, 18);
            lblAnalyticsQuerySelect.TabIndex = 0;
            lblAnalyticsQuerySelect.Text = "Select Report:";
            // 
            // comboBookAnalyticsQuery
            // 
            comboBookAnalyticsQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBookAnalyticsQuery.FormattingEnabled = true;
            comboBookAnalyticsQuery.Location = new System.Drawing.Point(88, 1);
            comboBookAnalyticsQuery.Name = "comboBookAnalyticsQuery";
            comboBookAnalyticsQuery.Size = new System.Drawing.Size(224, 23);
            comboBookAnalyticsQuery.TabIndex = 1;
            // 
            // btnRunBookAnalyticsQuery
            // 
            btnRunBookAnalyticsQuery.Location = new System.Drawing.Point(318, 0);
            btnRunBookAnalyticsQuery.Name = "btnRunBookAnalyticsQuery";
            btnRunBookAnalyticsQuery.Size = new System.Drawing.Size(79, 24);
            btnRunBookAnalyticsQuery.TabIndex = 2;
            btnRunBookAnalyticsQuery.Text = "Run Report";
            btnRunBookAnalyticsQuery.UseVisualStyleBackColor = true;
            // 
            // panelAnalyticsParamBook
            // 
            panelAnalyticsParamBook.Controls.Add(comboAnalyticsBookSelect);
            panelAnalyticsParamBook.Controls.Add(lblSelectBook);
            panelAnalyticsParamBook.Location = new System.Drawing.Point(528, 3);
            panelAnalyticsParamBook.Name = "panelAnalyticsParamBook";
            panelAnalyticsParamBook.Size = new System.Drawing.Size(249, 39);
            panelAnalyticsParamBook.TabIndex = 6;
            panelAnalyticsParamBook.Visible = false;
            // 
            // comboAnalyticsBookSelect
            // 
            comboAnalyticsBookSelect.DisplayMember = "Name";
            comboAnalyticsBookSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAnalyticsBookSelect.FormattingEnabled = true;
            comboAnalyticsBookSelect.Location = new System.Drawing.Point(88, 8);
            comboAnalyticsBookSelect.Name = "comboAnalyticsBookSelect";
            comboAnalyticsBookSelect.Size = new System.Drawing.Size(155, 23);
            comboAnalyticsBookSelect.TabIndex = 1;
            comboAnalyticsBookSelect.ValueMember = "Id";
            // 
            // lblSelectBook
            // 
            lblSelectBook.Location = new System.Drawing.Point(11, 11);
            lblSelectBook.Name = "lblSelectBook";
            lblSelectBook.Size = new System.Drawing.Size(71, 15);
            lblSelectBook.TabIndex = 0;
            lblSelectBook.Text = "Select Book:";
            // 
            // panelAnalyticsParamDateRange
            // 
            panelAnalyticsParamDateRange.Controls.Add(lblEndDate);
            panelAnalyticsParamDateRange.Controls.Add(lblStartDate);
            panelAnalyticsParamDateRange.Controls.Add(dtpAnalyticsEndDate);
            panelAnalyticsParamDateRange.Controls.Add(dtpAnalyticsStartDate);
            panelAnalyticsParamDateRange.Location = new System.Drawing.Point(571, 48);
            panelAnalyticsParamDateRange.Name = "panelAnalyticsParamDateRange";
            panelAnalyticsParamDateRange.Size = new System.Drawing.Size(206, 60);
            panelAnalyticsParamDateRange.TabIndex = 4;
            panelAnalyticsParamDateRange.Visible = false;
            // 
            // lblEndDate
            // 
            lblEndDate.Location = new System.Drawing.Point(5, 36);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new System.Drawing.Size(62, 19);
            lblEndDate.TabIndex = 3;
            lblEndDate.Text = "End Date:";
            // 
            // lblStartDate
            // 
            lblStartDate.Location = new System.Drawing.Point(5, 7);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(62, 19);
            lblStartDate.TabIndex = 2;
            lblStartDate.Text = "Start Date:";
            // 
            // dtpAnalyticsEndDate
            // 
            dtpAnalyticsEndDate.Location = new System.Drawing.Point(73, 32);
            dtpAnalyticsEndDate.Name = "dtpAnalyticsEndDate";
            dtpAnalyticsEndDate.Size = new System.Drawing.Size(127, 23);
            dtpAnalyticsEndDate.TabIndex = 1;
            // 
            // dtpAnalyticsStartDate
            // 
            dtpAnalyticsStartDate.Location = new System.Drawing.Point(73, 3);
            dtpAnalyticsStartDate.Name = "dtpAnalyticsStartDate";
            dtpAnalyticsStartDate.Size = new System.Drawing.Size(127, 23);
            dtpAnalyticsStartDate.TabIndex = 0;
            // 
            // panelAnalyticsParamAge
            // 
            panelAnalyticsParamAge.Controls.Add(lblAgeRestrictions);
            panelAnalyticsParamAge.Controls.Add(comboAnalyticsAgeRestriction);
            panelAnalyticsParamAge.Location = new System.Drawing.Point(594, 114);
            panelAnalyticsParamAge.Name = "panelAnalyticsParamAge";
            panelAnalyticsParamAge.Size = new System.Drawing.Size(183, 33);
            panelAnalyticsParamAge.TabIndex = 5;
            panelAnalyticsParamAge.Visible = false;
            // 
            // lblAgeRestrictions
            // 
            lblAgeRestrictions.Location = new System.Drawing.Point(5, 10);
            lblAgeRestrictions.Name = "lblAgeRestrictions";
            lblAgeRestrictions.Size = new System.Drawing.Size(90, 16);
            lblAgeRestrictions.TabIndex = 1;
            lblAgeRestrictions.Text = "Age Restriction:";
            // 
            // comboAnalyticsAgeRestriction
            // 
            comboAnalyticsAgeRestriction.FormattingEnabled = true;
            comboAnalyticsAgeRestriction.Location = new System.Drawing.Point(101, 7);
            comboAnalyticsAgeRestriction.Name = "comboAnalyticsAgeRestriction";
            comboAnalyticsAgeRestriction.Size = new System.Drawing.Size(76, 23);
            comboAnalyticsAgeRestriction.TabIndex = 0;
            // 
            // dataGridBookAnalytics
            // 
            dataGridBookAnalytics.AllowUserToAddRows = false;
            dataGridBookAnalytics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridBookAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridBookAnalytics.Location = new System.Drawing.Point(0, 0);
            dataGridBookAnalytics.Name = "dataGridBookAnalytics";
            dataGridBookAnalytics.ReadOnly = true;
            dataGridBookAnalytics.Size = new System.Drawing.Size(780, 341);
            dataGridBookAnalytics.TabIndex = 3;
            // 
            // tabUserActivity
            // 
            tabUserActivity.Controls.Add(splitContainer2);
            tabUserActivity.Location = new System.Drawing.Point(4, 24);
            tabUserActivity.Name = "tabUserActivity";
            tabUserActivity.Padding = new System.Windows.Forms.Padding(3);
            tabUserActivity.Size = new System.Drawing.Size(786, 378);
            tabUserActivity.TabIndex = 5;
            tabUserActivity.Text = "User Activity & Assignments";
            tabUserActivity.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(lblUserActivityQuerySelect);
            splitContainer2.Panel1.Controls.Add(comboUserActivityQuery);
            splitContainer2.Panel1.Controls.Add(btnRunUserActivityQuery);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panelUserActivityParamCritic);
            splitContainer2.Panel2.Controls.Add(panelUserActivityParamRole);
            splitContainer2.Panel2.Controls.Add(dataGridUserActivity);
            splitContainer2.Size = new System.Drawing.Size(780, 372);
            splitContainer2.SplitterDistance = 27;
            splitContainer2.TabIndex = 4;
            // 
            // lblUserActivityQuerySelect
            // 
            lblUserActivityQuerySelect.Location = new System.Drawing.Point(3, 6);
            lblUserActivityQuerySelect.Name = "lblUserActivityQuerySelect";
            lblUserActivityQuerySelect.Size = new System.Drawing.Size(79, 18);
            lblUserActivityQuerySelect.TabIndex = 0;
            lblUserActivityQuerySelect.Text = "Select Report:";
            // 
            // comboUserActivityQuery
            // 
            comboUserActivityQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboUserActivityQuery.FormattingEnabled = true;
            comboUserActivityQuery.Location = new System.Drawing.Point(88, 3);
            comboUserActivityQuery.Name = "comboUserActivityQuery";
            comboUserActivityQuery.Size = new System.Drawing.Size(102, 23);
            comboUserActivityQuery.TabIndex = 1;
            // 
            // btnRunUserActivityQuery
            // 
            btnRunUserActivityQuery.Location = new System.Drawing.Point(196, 3);
            btnRunUserActivityQuery.Name = "btnRunUserActivityQuery";
            btnRunUserActivityQuery.Size = new System.Drawing.Size(94, 23);
            btnRunUserActivityQuery.TabIndex = 2;
            btnRunUserActivityQuery.Text = "Run Report";
            btnRunUserActivityQuery.UseVisualStyleBackColor = true;
            // 
            // panelUserActivityParamCritic
            // 
            panelUserActivityParamCritic.Controls.Add(comboAnalyticsCriticSelect);
            panelUserActivityParamCritic.Controls.Add(lblSelectCritic);
            panelUserActivityParamCritic.Location = new System.Drawing.Point(528, 3);
            panelUserActivityParamCritic.Name = "panelUserActivityParamCritic";
            panelUserActivityParamCritic.Size = new System.Drawing.Size(249, 39);
            panelUserActivityParamCritic.TabIndex = 7;
            panelUserActivityParamCritic.Visible = false;
            // 
            // comboAnalyticsCriticSelect
            // 
            comboAnalyticsCriticSelect.DisplayMember = "FullName";
            comboAnalyticsCriticSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAnalyticsCriticSelect.FormattingEnabled = true;
            comboAnalyticsCriticSelect.Location = new System.Drawing.Point(88, 8);
            comboAnalyticsCriticSelect.Name = "comboAnalyticsCriticSelect";
            comboAnalyticsCriticSelect.Size = new System.Drawing.Size(155, 23);
            comboAnalyticsCriticSelect.TabIndex = 1;
            comboAnalyticsCriticSelect.ValueMember = "Id";
            // 
            // lblSelectCritic
            // 
            lblSelectCritic.Location = new System.Drawing.Point(11, 11);
            lblSelectCritic.Name = "lblSelectCritic";
            lblSelectCritic.Size = new System.Drawing.Size(79, 20);
            lblSelectCritic.TabIndex = 0;
            lblSelectCritic.Text = "Select Critic:";
            // 
            // panelUserActivityParamRole
            // 
            panelUserActivityParamRole.Controls.Add(comboUserActivityRole);
            panelUserActivityParamRole.Location = new System.Drawing.Point(669, 48);
            panelUserActivityParamRole.Name = "panelUserActivityParamRole";
            panelUserActivityParamRole.Size = new System.Drawing.Size(108, 29);
            panelUserActivityParamRole.TabIndex = 5;
            // 
            // comboUserActivityRole
            // 
            comboUserActivityRole.FormattingEnabled = true;
            comboUserActivityRole.Location = new System.Drawing.Point(3, 3);
            comboUserActivityRole.Name = "comboUserActivityRole";
            comboUserActivityRole.Size = new System.Drawing.Size(102, 23);
            comboUserActivityRole.TabIndex = 0;
            // 
            // dataGridUserActivity
            // 
            dataGridUserActivity.AllowUserToAddRows = false;
            dataGridUserActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridUserActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridUserActivity.Location = new System.Drawing.Point(0, 0);
            dataGridUserActivity.Name = "dataGridUserActivity";
            dataGridUserActivity.ReadOnly = true;
            dataGridUserActivity.Size = new System.Drawing.Size(780, 341);
            dataGridUserActivity.TabIndex = 3;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(tableLayoutPanelMain);
            Text = "Admin Dashboard";
            tableLayoutPanelMain.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabAddUser.ResumeLayout(false);
            tabAddUser.PerformLayout();
            tabViewUsers.ResumeLayout(false);
            tabViewUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).EndInit();
            tabBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridBooks).EndInit();
            tabReviews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridReviews).EndInit();
            tabBookAnalytics.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelAnalyticsParamBook.ResumeLayout(false);
            panelAnalyticsParamDateRange.ResumeLayout(false);
            panelAnalyticsParamAge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridBookAnalytics).EndInit();
            tabUserActivity.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panelUserActivityParamCritic.ResumeLayout(false);
            panelUserActivityParamRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridUserActivity).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelUserActivityParamCritic;
        private System.Windows.Forms.ComboBox comboAnalyticsCriticSelect;
        private System.Windows.Forms.Label lblSelectCritic;

        private System.Windows.Forms.ComboBox comboAnalyticsBookSelect;

        private System.Windows.Forms.Label lblSelectBook;

        private System.Windows.Forms.Panel panelAnalyticsParamBook;

        private System.Windows.Forms.Label lblAgeRestrictions;

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;

        private System.Windows.Forms.Button btnDeepAnalytics;

        private System.Windows.Forms.ComboBox comboUserActivityRole;

        private System.Windows.Forms.Panel panelUserActivityParamRole;

        private System.Windows.Forms.Button btnRunUserActivityQuery;
        private System.Windows.Forms.DataGridView dataGridUserActivity;
        private System.Windows.Forms.SplitContainer splitContainer2;

        private System.Windows.Forms.ComboBox comboUserActivityQuery;

        private System.Windows.Forms.Label lblUserActivityQuerySelect;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private System.Windows.Forms.Panel panelAnalyticsParamAge;
        private System.Windows.Forms.ComboBox comboAnalyticsAgeRestriction;

        private System.Windows.Forms.DateTimePicker dtpAnalyticsEndDate;

        private System.Windows.Forms.DateTimePicker dtpAnalyticsStartDate;

        private System.Windows.Forms.Panel panelAnalyticsParamDateRange;

        private System.Windows.Forms.DataGridView dataGridBookAnalytics;

        private System.Windows.Forms.Label lblAnalyticsQuerySelect;
        private System.Windows.Forms.ComboBox comboBookAnalyticsQuery;
        private System.Windows.Forms.Button btnRunBookAnalyticsQuery;

        private System.Windows.Forms.TabPage tabBookAnalytics;
        private System.Windows.Forms.TabPage tabUserActivity;

        #endregion
    }
}