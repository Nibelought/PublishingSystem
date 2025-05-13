namespace PublishingSystem.UI
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // --- ОБЪЯВЛЕНИЯ ПОЛЕЙ ДОЛЖНЫ БЫТЬ ЗДЕСЬ, ВНУТРИ КЛАССА ---
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAddUser;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox comboAddRole;
        private System.Windows.Forms.ComboBox comboAddStatus;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnGeneratePassword;

        private System.Windows.Forms.TabPage tabViewUsers;
        private System.Windows.Forms.ComboBox comboRoleFilter;
        private System.Windows.Forms.ComboBox comboStatusFilter;
        private System.Windows.Forms.TextBox txtEmailFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;

        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.DataGridView dataGridBooks;
        private System.Windows.Forms.Button btnBooksRefresh;
        private System.Windows.Forms.Button btnBookEdit;
        private System.Windows.Forms.Button btnBookDelete;

        private System.Windows.Forms.TabPage tabReviews;
        private System.Windows.Forms.DataGridView dataGridReviews;
        private System.Windows.Forms.Button btnReviewsRefresh;
        private System.Windows.Forms.Button btnReviewDelete;
        
        // Если MenuStrip добавляется через дизайнер, он был бы объявлен здесь.
        // private System.Windows.Forms.MenuStrip menuStrip1; 


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
            // Инициализация компонентов, сгенерированная дизайнером
            this.components = new System.ComponentModel.Container(); // Если используется
            System.Windows.Forms.Label labelFirstName;
            System.Windows.Forms.Label labelLastName;
            System.Windows.Forms.Label labelEmail;
            System.Windows.Forms.Label labelPassword;
            System.Windows.Forms.Label labelRole;
            System.Windows.Forms.Label labelStatus;
            System.Windows.Forms.Label labelRoleFilter;
            System.Windows.Forms.Label labelStatusFilter;
            System.Windows.Forms.Label labelEmailFilter;

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAddUser = new System.Windows.Forms.TabPage();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.comboAddRole = new System.Windows.Forms.ComboBox();
            this.comboAddStatus = new System.Windows.Forms.ComboBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            
            this.tabViewUsers = new System.Windows.Forms.TabPage();
            this.comboRoleFilter = new System.Windows.Forms.ComboBox();
            this.comboStatusFilter = new System.Windows.Forms.ComboBox();
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

            // Инициализация Labels (пример, т.к. их не было в вашем designer.cs, но они нужны для полей ввода)
            labelFirstName = new System.Windows.Forms.Label();
            labelLastName = new System.Windows.Forms.Label();
            labelEmail = new System.Windows.Forms.Label();
            labelPassword = new System.Windows.Forms.Label();
            labelRole = new System.Windows.Forms.Label();
            labelStatus = new System.Windows.Forms.Label();
            labelRoleFilter = new System.Windows.Forms.Label();
            labelStatusFilter = new System.Windows.Forms.Label();
            labelEmailFilter = new System.Windows.Forms.Label();

            this.tabControl.SuspendLayout();
            this.tabAddUser.SuspendLayout();
            this.tabViewUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBooks)).BeginInit();
            this.tabReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReviews)).BeginInit();
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAddUser);
            this.tabControl.Controls.Add(this.tabViewUsers);
            this.tabControl.Controls.Add(this.tabBooks);
            this.tabControl.Controls.Add(this.tabReviews);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill; // Растягиваем на всю форму (кроме MenuStrip)
            this.tabControl.Location = new System.Drawing.Point(0, 24); // Предполагаем, что MenuStrip высотой 24px сверху
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 426); // Примерный размер
            this.tabControl.TabIndex = 0; // TabIndex для основного TabControl
            // 
            // tabAddUser
            // 
            this.tabAddUser.Controls.Add(labelFirstName);
            this.tabAddUser.Controls.Add(this.txtFirstName);
            this.tabAddUser.Controls.Add(labelLastName);
            this.tabAddUser.Controls.Add(this.txtLastName);
            this.tabAddUser.Controls.Add(labelEmail);
            this.tabAddUser.Controls.Add(this.txtEmail);
            this.tabAddUser.Controls.Add(labelPassword);
            this.tabAddUser.Controls.Add(this.txtPassword);
            this.tabAddUser.Controls.Add(this.btnGeneratePassword);
            this.tabAddUser.Controls.Add(labelRole);
            this.tabAddUser.Controls.Add(this.comboAddRole);
            this.tabAddUser.Controls.Add(labelStatus);
            this.tabAddUser.Controls.Add(this.comboAddStatus);
            this.tabAddUser.Controls.Add(this.btnAddUser);
            this.tabAddUser.Location = new System.Drawing.Point(4, 24);
            this.tabAddUser.Name = "tabAddUser";
            this.tabAddUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddUser.Size = new System.Drawing.Size(792, 398); // Авто-размер от tabControl
            this.tabAddUser.TabIndex = 0;
            this.tabAddUser.Text = "Manage Users"; // Более общее название
            this.tabAddUser.UseVisualStyleBackColor = true;
            //
            // Labels for tabAddUser (пример)
            //
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new System.Drawing.Point(20, 23);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Text = "First Name:";
            //
            this.txtFirstName.Location = new System.Drawing.Point(130, 20);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(180, 23);
            this.txtFirstName.TabIndex = 0;
            //
            labelLastName.AutoSize = true;
            labelLastName.Location = new System.Drawing.Point(20, 63);
            labelLastName.Name = "labelLastName";
            labelLastName.Text = "Last Name:";
            //
            this.txtLastName.Location = new System.Drawing.Point(130, 60);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(180, 23);
            this.txtLastName.TabIndex = 1;
            //
            labelEmail.AutoSize = true;
            labelEmail.Location = new System.Drawing.Point(20, 103);
            labelEmail.Name = "labelEmail";
            labelEmail.Text = "Email:";
            //
            this.txtEmail.Location = new System.Drawing.Point(130, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 23);
            this.txtEmail.TabIndex = 2;
            //
            labelPassword.AutoSize = true;
            labelPassword.Location = new System.Drawing.Point(20, 143);
            labelPassword.Name = "labelPassword";
            labelPassword.Text = "Password:";
            //
            this.txtPassword.Location = new System.Drawing.Point(130, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(180, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.PasswordChar = '*';
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(320, 139);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(75, 25);
            this.btnGeneratePassword.TabIndex = 4;
            this.btnGeneratePassword.Text = "Generate";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            //
            labelRole.AutoSize = true;
            labelRole.Location = new System.Drawing.Point(20, 183);
            labelRole.Name = "labelRole";
            labelRole.Text = "Role:";
            //
            this.comboAddRole.FormattingEnabled = true;
            this.comboAddRole.Location = new System.Drawing.Point(130, 180);
            this.comboAddRole.Name = "comboAddRole";
            this.comboAddRole.Size = new System.Drawing.Size(180, 23);
            this.comboAddRole.TabIndex = 5;
            //
            labelStatus.AutoSize = true;
            labelStatus.Location = new System.Drawing.Point(20, 223);
            labelStatus.Name = "labelStatus";
            labelStatus.Text = "Status:";
            //
            this.comboAddStatus.FormattingEnabled = true;
            this.comboAddStatus.Location = new System.Drawing.Point(130, 220);
            this.comboAddStatus.Name = "comboAddStatus";
            this.comboAddStatus.Size = new System.Drawing.Size(180, 23);
            this.comboAddStatus.TabIndex = 6;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(130, 260);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(100, 30);
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click); // Привязка обработчика
            // 
            // tabViewUsers
            // 
            this.tabViewUsers.Controls.Add(labelRoleFilter);
            this.tabViewUsers.Controls.Add(this.comboRoleFilter);
            this.tabViewUsers.Controls.Add(labelStatusFilter);
            this.tabViewUsers.Controls.Add(this.comboStatusFilter);
            this.tabViewUsers.Controls.Add(labelEmailFilter);
            this.tabViewUsers.Controls.Add(this.txtEmailFilter);
            this.tabViewUsers.Controls.Add(this.btnSearch);
            this.tabViewUsers.Controls.Add(this.dataGridUsers);
            this.tabViewUsers.Controls.Add(this.btnEditUser);
            this.tabViewUsers.Controls.Add(this.btnDeleteUser);
            this.tabViewUsers.Location = new System.Drawing.Point(4, 24);
            this.tabViewUsers.Name = "tabViewUsers";
            this.tabViewUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewUsers.Size = new System.Drawing.Size(792, 398);
            this.tabViewUsers.TabIndex = 1;
            this.tabViewUsers.Text = "View Users";
            this.tabViewUsers.UseVisualStyleBackColor = true;
            //
            // Labels for tabViewUsers (пример)
            //
            labelRoleFilter.AutoSize = true;
            labelRoleFilter.Location = new System.Drawing.Point(10, 20);
            labelRoleFilter.Name = "labelRoleFilter";
            labelRoleFilter.Text = "Role:";
            //
            this.comboRoleFilter.FormattingEnabled = true;
            this.comboRoleFilter.Location = new System.Drawing.Point(50, 17);
            this.comboRoleFilter.Name = "comboRoleFilter";
            this.comboRoleFilter.Size = new System.Drawing.Size(121, 23);
            this.comboRoleFilter.TabIndex = 0;
            //
            labelStatusFilter.AutoSize = true;
            labelStatusFilter.Location = new System.Drawing.Point(180, 20);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Text = "Status:";
            //
            this.comboStatusFilter.FormattingEnabled = true;
            this.comboStatusFilter.Location = new System.Drawing.Point(230, 17);
            this.comboStatusFilter.Name = "comboStatusFilter";
            this.comboStatusFilter.Size = new System.Drawing.Size(121, 23);
            this.comboStatusFilter.TabIndex = 1;
            //
            labelEmailFilter.AutoSize = true;
            labelEmailFilter.Location = new System.Drawing.Point(360, 20);
            labelEmailFilter.Name = "labelEmailFilter";
            labelEmailFilter.Text = "Email:";
            //
            this.txtEmailFilter.Location = new System.Drawing.Point(400, 17);
            this.txtEmailFilter.Name = "txtEmailFilter";
            this.txtEmailFilter.Size = new System.Drawing.Size(150, 23);
            this.txtEmailFilter.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(560, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click); // Привязка
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
            this.dataGridUsers.Location = new System.Drawing.Point(10, 50);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.ReadOnly = true;
            this.dataGridUsers.RowTemplate.Height = 25;
            this.dataGridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsers.Size = new System.Drawing.Size(770, 300);
            this.dataGridUsers.TabIndex = 4;
            // 
            // btnEditUser
            // 
            this.btnEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditUser.Location = new System.Drawing.Point(10, 360);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(100, 30);
            this.btnEditUser.TabIndex = 5;
            this.btnEditUser.Text = "Edit Selected";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click); // Привязка
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteUser.Location = new System.Drawing.Point(120, 360);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteUser.TabIndex = 6;
            this.btnDeleteUser.Text = "Delete Selected";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click); // Привязка
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.btnBookDelete);
            this.tabBooks.Controls.Add(this.btnBookEdit);
            this.tabBooks.Controls.Add(this.btnBooksRefresh);
            this.tabBooks.Controls.Add(this.dataGridBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 24);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(10); // Отступы
            this.tabBooks.Size = new System.Drawing.Size(792, 398);
            this.tabBooks.TabIndex = 2;
            this.tabBooks.Text = "Books";
            this.tabBooks.UseVisualStyleBackColor = true;
            // this.tabBooks.Click += new System.EventHandler(this.tabPage1_Click); // Удалите, если не нужен
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
            this.dataGridBooks.Size = new System.Drawing.Size(766, 330);
            this.dataGridBooks.TabIndex = 0;
            // 
            // btnBooksRefresh
            // 
            this.btnBooksRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBooksRefresh.Location = new System.Drawing.Point(13, 355);
            this.btnBooksRefresh.Name = "btnBooksRefresh";
            this.btnBooksRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnBooksRefresh.TabIndex = 1;
            this.btnBooksRefresh.Text = "Refresh";
            this.btnBooksRefresh.UseVisualStyleBackColor = true;
            // btnBooksRefresh.Click += ... // Привязка в AdminDashboardForm.cs
            // 
            // btnBookEdit
            // 
            this.btnBookEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBookEdit.Location = new System.Drawing.Point(94, 355);
            this.btnBookEdit.Name = "btnBookEdit";
            this.btnBookEdit.Size = new System.Drawing.Size(75, 30);
            this.btnBookEdit.TabIndex = 2;
            this.btnBookEdit.Text = "Edit";
            this.btnBookEdit.UseVisualStyleBackColor = true;
            // btnBookEdit.Click += ... // Привязка в AdminDashboardForm.cs
            // 
            // btnBookDelete
            // 
            this.btnBookDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBookDelete.Location = new System.Drawing.Point(175, 355);
            this.btnBookDelete.Name = "btnBookDelete";
            this.btnBookDelete.Size = new System.Drawing.Size(75, 30);
            this.btnBookDelete.TabIndex = 3;
            this.btnBookDelete.Text = "Delete";
            this.btnBookDelete.UseVisualStyleBackColor = true;
            // btnBookDelete.Click += ... // Привязка в AdminDashboardForm.cs
            // 
            // tabReviews
            // 
            this.tabReviews.Controls.Add(this.btnReviewDelete);
            this.tabReviews.Controls.Add(this.btnReviewsRefresh);
            this.tabReviews.Controls.Add(this.dataGridReviews);
            this.tabReviews.Location = new System.Drawing.Point(4, 24);
            this.tabReviews.Name = "tabReviews";
            this.tabReviews.Padding = new System.Windows.Forms.Padding(10);
            this.tabReviews.Size = new System.Drawing.Size(792, 398);
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
            this.dataGridReviews.Size = new System.Drawing.Size(766, 330);
            this.dataGridReviews.TabIndex = 0;
            // 
            // btnReviewsRefresh
            // 
            this.btnReviewsRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReviewsRefresh.Location = new System.Drawing.Point(13, 355);
            this.btnReviewsRefresh.Name = "btnReviewsRefresh";
            this.btnReviewsRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnReviewsRefresh.TabIndex = 1;
            this.btnReviewsRefresh.Text = "Refresh";
            this.btnReviewsRefresh.UseVisualStyleBackColor = true;
            // btnReviewsRefresh.Click += ... // Привязка в AdminDashboardForm.cs
            // 
            // btnReviewDelete
            // 
            this.btnReviewDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReviewDelete.Location = new System.Drawing.Point(94, 355);
            this.btnReviewDelete.Name = "btnReviewDelete";
            this.btnReviewDelete.Size = new System.Drawing.Size(75, 30);
            this.btnReviewDelete.TabIndex = 2;
            this.btnReviewDelete.Text = "Delete";
            this.btnReviewDelete.UseVisualStyleBackColor = true;
            // btnReviewDelete.Click += ... // Привязка в AdminDashboardForm.cs
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            // MenuStrip будет добавлен программно и займет верхнюю часть, поэтому tabControl ниже
            this.Controls.Add(this.tabControl); 
            this.Name = "AdminDashboardForm";
            this.Text = "Admin Dashboard";
            this.tabControl.ResumeLayout(false);
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