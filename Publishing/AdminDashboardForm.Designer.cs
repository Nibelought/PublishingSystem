namespace PublishingSystem.UI
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // --- Control Fields ---
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain; // Main container
        private System.Windows.Forms.TabControl tabControlMain; // Renamed from tabControl for clarity
        
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            
            this.tabAddUser = new System.Windows.Forms.TabPage();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.labelRole = new System.Windows.Forms.Label();
            this.comboAddRole = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboAddStatus = new System.Windows.Forms.ComboBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            
            this.tabViewUsers = new System.Windows.Forms.TabPage();
            this.labelRoleFilter = new System.Windows.Forms.Label();
            this.comboRoleFilter = new System.Windows.Forms.ComboBox();
            this.labelStatusFilter = new System.Windows.Forms.Label();
            this.comboStatusFilter = new System.Windows.Forms.ComboBox();
            this.labelEmailFilter = new System.Windows.Forms.Label();
            this.txtEmailFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.dataGridBooks = new System.Windows.Forms.DataGridView();
            this.btnBooksRefresh = new System.Windows.Forms.Button();
            this.btnBookEdit = new System.Windows.Forms.Button();
            this.btnBookDelete = new System.Windows.Forms.Button();
            
            this.tabReviews = new System.Windows.Forms.TabPage();
            this.dataGridReviews = new System.Windows.Forms.DataGridView();
            this.btnReviewsRefresh = new System.Windows.Forms.Button();
            this.btnReviewDelete = new System.Windows.Forms.Button();
            
            this.tableLayoutPanelMain.SuspendLayout(); // Begin TableLayoutPanel
            this.tabControlMain.SuspendLayout();
            this.tabAddUser.SuspendLayout();
            this.tabViewUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).BeginInit();
            this.tabReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReviews)).BeginInit();
            this.SuspendLayout();
            
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tabControlMain, 0, 1); // TabControl in the second row
            // MenuStrip will be added programmatically to row 0 in AdminDashboardForm.cs
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F)); // Row for MenuStrip (adjust height as needed)
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // Row for TabControl
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabAddUser);
            this.tabControlMain.Controls.Add(this.tabViewUsers);
            this.tabControlMain.Controls.Add(this.tabBooks);
            this.tabControlMain.Controls.Add(this.tabReviews);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(3, 31); // Position within TableLayoutPanel
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(794, 416); // Size within TableLayoutPanel
            this.tabControlMain.TabIndex = 0; // TabIndex within its parent (TableLayoutPanel cell)
            // 
            // tabAddUser
            // 
            this.tabAddUser.Controls.Add(this.labelFirstName);
            this.tabAddUser.Controls.Add(this.txtFirstName);
            this.tabAddUser.Controls.Add(this.labelLastName);
            this.tabAddUser.Controls.Add(this.txtLastName);
            this.tabAddUser.Controls.Add(this.labelEmail);
            this.tabAddUser.Controls.Add(this.txtEmail);
            this.tabAddUser.Controls.Add(this.labelPassword);
            this.tabAddUser.Controls.Add(this.txtPassword);
            this.tabAddUser.Controls.Add(this.btnGeneratePassword);
            this.tabAddUser.Controls.Add(this.labelRole);
            this.tabAddUser.Controls.Add(this.comboAddRole);
            this.tabAddUser.Controls.Add(this.labelStatus);
            this.tabAddUser.Controls.Add(this.comboAddStatus);
            this.tabAddUser.Controls.Add(this.btnAddUser);
            this.tabAddUser.Location = new System.Drawing.Point(4, 24);
            this.tabAddUser.Name = "tabAddUser";
            this.tabAddUser.Padding = new System.Windows.Forms.Padding(10);
            this.tabAddUser.Size = new System.Drawing.Size(786, 388);
            this.tabAddUser.TabIndex = 0;
            this.tabAddUser.Text = "Manage Users";
            this.tabAddUser.UseVisualStyleBackColor = true;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(13, 16);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(67, 15);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(100, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 23);
            this.txtFirstName.TabIndex = 1;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(13, 45);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(66, 15);
            this.labelLastName.TabIndex = 2;
            this.labelLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(100, 42);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 23);
            this.txtLastName.TabIndex = 3;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(13, 74);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(39, 15);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 71);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(13, 104);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(60, 15);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(100, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 7;
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(306, 100);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(75, 25);
            this.btnGeneratePassword.TabIndex = 8;
            this.btnGeneratePassword.Text = "Generate";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(13, 133);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(33, 15);
            this.labelRole.TabIndex = 9;
            this.labelRole.Text = "Role:";
            // 
            // comboAddRole
            // 
            this.comboAddRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAddRole.FormattingEnabled = true;
            this.comboAddRole.Location = new System.Drawing.Point(100, 130);
            this.comboAddRole.Name = "comboAddRole";
            this.comboAddRole.Size = new System.Drawing.Size(200, 23);
            this.comboAddRole.TabIndex = 10;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 162);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(42, 15);
            this.labelStatus.TabIndex = 11;
            this.labelStatus.Text = "Status:";
            // 
            // comboAddStatus
            // 
            this.comboAddStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAddStatus.FormattingEnabled = true;
            this.comboAddStatus.Location = new System.Drawing.Point(100, 159);
            this.comboAddStatus.Name = "comboAddStatus";
            this.comboAddStatus.Size = new System.Drawing.Size(200, 23);
            this.comboAddStatus.TabIndex = 12;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(100, 198);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(100, 30);
            this.btnAddUser.TabIndex = 13;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tabViewUsers
            // 
            this.tabViewUsers.Controls.Add(this.labelRoleFilter);
            this.tabViewUsers.Controls.Add(this.comboRoleFilter);
            this.tabViewUsers.Controls.Add(this.labelStatusFilter);
            this.tabViewUsers.Controls.Add(this.comboStatusFilter);
            this.tabViewUsers.Controls.Add(this.labelEmailFilter);
            this.tabViewUsers.Controls.Add(this.txtEmailFilter);
            this.tabViewUsers.Controls.Add(this.btnSearch);
            this.tabViewUsers.Controls.Add(this.dataGridUsers);
            this.tabViewUsers.Controls.Add(this.btnEditUser);
            this.tabViewUsers.Controls.Add(this.btnDeleteUser);
            this.tabViewUsers.Location = new System.Drawing.Point(4, 24);
            this.tabViewUsers.Name = "tabViewUsers";
            this.tabViewUsers.Padding = new System.Windows.Forms.Padding(10);
            this.tabViewUsers.Size = new System.Drawing.Size(786, 388);
            this.tabViewUsers.TabIndex = 1;
            this.tabViewUsers.Text = "View Users";
            this.tabViewUsers.UseVisualStyleBackColor = true;
            // 
            // labelRoleFilter
            // 
            this.labelRoleFilter.AutoSize = true;
            this.labelRoleFilter.Location = new System.Drawing.Point(13, 16);
            this.labelRoleFilter.Name = "labelRoleFilter";
            this.labelRoleFilter.Size = new System.Drawing.Size(33, 15);
            this.labelRoleFilter.TabIndex = 0;
            this.labelRoleFilter.Text = "Role:";
            // 
            // comboRoleFilter
            // 
            this.comboRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRoleFilter.FormattingEnabled = true;
            this.comboRoleFilter.Location = new System.Drawing.Point(52, 13);
            this.comboRoleFilter.Name = "comboRoleFilter";
            this.comboRoleFilter.Size = new System.Drawing.Size(121, 23);
            this.comboRoleFilter.TabIndex = 1;
            // 
            // labelStatusFilter
            // 
            this.labelStatusFilter.AutoSize = true;
            this.labelStatusFilter.Location = new System.Drawing.Point(188, 16);
            this.labelStatusFilter.Name = "labelStatusFilter";
            this.labelStatusFilter.Size = new System.Drawing.Size(42, 15);
            this.labelStatusFilter.TabIndex = 2;
            this.labelStatusFilter.Text = "Status:";
            // 
            // comboStatusFilter
            // 
            this.comboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatusFilter.FormattingEnabled = true;
            this.comboStatusFilter.Location = new System.Drawing.Point(236, 13);
            this.comboStatusFilter.Name = "comboStatusFilter";
            this.comboStatusFilter.Size = new System.Drawing.Size(121, 23);
            this.comboStatusFilter.TabIndex = 3;
            // 
            // labelEmailFilter
            // 
            this.labelEmailFilter.AutoSize = true;
            this.labelEmailFilter.Location = new System.Drawing.Point(372, 16);
            this.labelEmailFilter.Name = "labelEmailFilter";
            this.labelEmailFilter.Size = new System.Drawing.Size(39, 15);
            this.labelEmailFilter.TabIndex = 4;
            this.labelEmailFilter.Text = "Email:";
            // 
            // txtEmailFilter
            // 
            this.txtEmailFilter.Location = new System.Drawing.Point(417, 13);
            this.txtEmailFilter.Name = "txtEmailFilter";
            this.txtEmailFilter.Size = new System.Drawing.Size(150, 23);
            this.txtEmailFilter.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(582, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.AllowUserToAddRows = false;
            this.dataGridUsers.AllowUserToDeleteRows = false;
            this.dataGridUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Location = new System.Drawing.Point(13, 49);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.ReadOnly = true;
            this.dataGridUsers.RowTemplate.Height = 25;
            this.dataGridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsers.Size = new System.Drawing.Size(760, 284);
            this.dataGridUsers.TabIndex = 7;
            // 
            // btnEditUser
            // 
            this.btnEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditUser.Location = new System.Drawing.Point(13, 345);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(100, 30);
            this.btnEditUser.TabIndex = 8;
            this.btnEditUser.Text = "Edit Selected";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteUser.Location = new System.Drawing.Point(123, 345);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Delete Selected";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.btnBookDelete);
            this.tabBooks.Controls.Add(this.btnBookEdit);
            this.tabBooks.Controls.Add(this.btnBooksRefresh);
            this.tabBooks.Controls.Add(this.dataGridBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 24);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(10);
            this.tabBooks.Size = new System.Drawing.Size(786, 388);
            this.tabBooks.TabIndex = 2;
            this.tabBooks.Text = "Books";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // dataGridBooks
            // 
            this.dataGridBooks.AllowUserToAddRows = false;
            this.dataGridBooks.AllowUserToDeleteRows = false;
            this.dataGridBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBooks.Location = new System.Drawing.Point(13, 13);
            this.dataGridBooks.Name = "dataGridBooks";
            this.dataGridBooks.ReadOnly = true;
            this.dataGridBooks.RowTemplate.Height = 25;
            this.dataGridBooks.Size = new System.Drawing.Size(760, 323);
            this.dataGridBooks.TabIndex = 0;
            // 
            // btnBooksRefresh
            // 
            this.btnBooksRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBooksRefresh.Location = new System.Drawing.Point(13, 345);
            this.btnBooksRefresh.Name = "btnBooksRefresh";
            this.btnBooksRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnBooksRefresh.TabIndex = 1;
            this.btnBooksRefresh.Text = "Refresh";
            this.btnBooksRefresh.UseVisualStyleBackColor = true;
            // 
            // btnBookEdit
            // 
            this.btnBookEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBookEdit.Location = new System.Drawing.Point(94, 345);
            this.btnBookEdit.Name = "btnBookEdit";
            this.btnBookEdit.Size = new System.Drawing.Size(75, 30);
            this.btnBookEdit.TabIndex = 2;
            this.btnBookEdit.Text = "Edit";
            this.btnBookEdit.UseVisualStyleBackColor = true;
            // 
            // btnBookDelete
            // 
            this.btnBookDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBookDelete.Location = new System.Drawing.Point(175, 345);
            this.btnBookDelete.Name = "btnBookDelete";
            this.btnBookDelete.Size = new System.Drawing.Size(75, 30);
            this.btnBookDelete.TabIndex = 3;
            this.btnBookDelete.Text = "Delete";
            this.btnBookDelete.UseVisualStyleBackColor = true;
            // 
            // tabReviews
            // 
            this.tabReviews.Controls.Add(this.btnReviewDelete);
            this.tabReviews.Controls.Add(this.btnReviewsRefresh);
            this.tabReviews.Controls.Add(this.dataGridReviews);
            this.tabReviews.Location = new System.Drawing.Point(4, 24);
            this.tabReviews.Name = "tabReviews";
            this.tabReviews.Padding = new System.Windows.Forms.Padding(10);
            this.tabReviews.Size = new System.Drawing.Size(786, 388);
            this.tabReviews.TabIndex = 3;
            this.tabReviews.Text = "Reviews";
            this.tabReviews.UseVisualStyleBackColor = true;
            // 
            // dataGridReviews
            // 
            this.dataGridReviews.AllowUserToAddRows = false;
            this.dataGridReviews.AllowUserToDeleteRows = false;
            this.dataGridReviews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReviews.Location = new System.Drawing.Point(13, 13);
            this.dataGridReviews.Name = "dataGridReviews";
            this.dataGridReviews.ReadOnly = true;
            this.dataGridReviews.RowTemplate.Height = 25;
            this.dataGridReviews.Size = new System.Drawing.Size(760, 323);
            this.dataGridReviews.TabIndex = 0;
            // 
            // btnReviewsRefresh
            // 
            this.btnReviewsRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReviewsRefresh.Location = new System.Drawing.Point(13, 345);
            this.btnReviewsRefresh.Name = "btnReviewsRefresh";
            this.btnReviewsRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnReviewsRefresh.TabIndex = 1;
            this.btnReviewsRefresh.Text = "Refresh";
            this.btnReviewsRefresh.UseVisualStyleBackColor = true;
            // 
            // btnReviewDelete
            // 
            this.btnReviewDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReviewDelete.Location = new System.Drawing.Point(94, 345);
            this.btnReviewDelete.Name = "btnReviewDelete";
            this.btnReviewDelete.Size = new System.Drawing.Size(75, 30);
            this.btnReviewDelete.TabIndex = 2;
            this.btnReviewDelete.Text = "Delete";
            this.btnReviewDelete.UseVisualStyleBackColor = true;
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelMain); // Add TableLayoutPanel to form
            this.Name = "AdminDashboardForm";
            this.Text = "Admin Dashboard";
            this.tableLayoutPanelMain.ResumeLayout(false); // End TableLayoutPanel
            this.tabControlMain.ResumeLayout(false);
            this.tabAddUser.ResumeLayout(false);
            this.tabAddUser.PerformLayout();
            this.tabViewUsers.ResumeLayout(false);
            this.tabViewUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.tabBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).EndInit();
            this.tabReviews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReviews)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}