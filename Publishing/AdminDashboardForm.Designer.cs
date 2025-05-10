namespace PublishingSystem.UI
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private TabControl tabControl;
        private TabPage tabAddUser;
        private TabPage tabViewUsers;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private ComboBox comboAddRole;
        private ComboBox comboAddStatus;
        private Button btnAddUser;
        private ComboBox comboRoleFilter;
        private ComboBox comboStatusFilter;
        private TextBox txtEmailFilter;
        private Button btnSearch;
        private DataGridView dataGridUsers;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnLogout;

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            tabControl = new TabControl();
            tabAddUser = new TabPage();
            tabViewUsers = new TabPage();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            comboAddRole = new ComboBox();
            comboAddStatus = new ComboBox();
            btnAddUser = new Button();
            comboRoleFilter = new ComboBox();
            comboStatusFilter = new ComboBox();
            txtEmailFilter = new TextBox();
            btnSearch = new Button();
            dataGridUsers = new DataGridView();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            btnLogout = new Button();

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new System.Drawing.Point(10, 10);
            lblWelcome.Size = new System.Drawing.Size(200, 15);
            lblWelcome.Text = "Welcome, Admin";

            // tabControl
            tabControl.Location = new System.Drawing.Point(10, 35);
            tabControl.Size = new System.Drawing.Size(780, 400);
            tabControl.TabPages.Add(tabAddUser);
            tabControl.TabPages.Add(tabViewUsers);

            // tabAddUser
            tabAddUser.Text = "Add User";
            tabAddUser.Controls.AddRange(new Control[] {
                new Label() { Text = "First Name", Location = new System.Drawing.Point(20, 20) }, txtFirstName,
                new Label() { Text = "Last Name", Location = new System.Drawing.Point(20, 60) }, txtLastName,
                new Label() { Text = "Email", Location = new System.Drawing.Point(20, 100) }, txtEmail,
                new Label() { Text = "Password", Location = new System.Drawing.Point(20, 140) }, txtPassword,
                new Label() { Text = "Role", Location = new System.Drawing.Point(20, 180) }, comboAddRole,
                new Label() { Text = "Status", Location = new System.Drawing.Point(20, 220) }, comboAddStatus,
                btnAddUser
            });
            txtFirstName.Location = new System.Drawing.Point(120, 20);
            txtLastName.Location = new System.Drawing.Point(120, 60);
            txtEmail.Location = new System.Drawing.Point(120, 100);
            txtPassword.Location = new System.Drawing.Point(120, 140);
            comboAddRole.Location = new System.Drawing.Point(120, 180);
            comboAddStatus.Location = new System.Drawing.Point(120, 220);
            btnAddUser.Text = "Add";
            btnAddUser.Location = new System.Drawing.Point(120, 260);
            btnAddUser.Click += btnAddUser_Click;

            // tabViewUsers
            tabViewUsers.Text = "Users";
            tabViewUsers.Controls.AddRange(new Control[] {
                new Label() { Text = "Role", Location = new System.Drawing.Point(20, 20) }, comboRoleFilter,
                new Label() { Text = "Status", Location = new System.Drawing.Point(250, 20) }, comboStatusFilter,
                new Label() { Text = "Email", Location = new System.Drawing.Point(480, 20) }, txtEmailFilter,
                btnSearch,
                dataGridUsers,
                btnEditUser,
                btnDeleteUser
            });
            comboRoleFilter.Location = new System.Drawing.Point(70, 17);
            comboStatusFilter.Location = new System.Drawing.Point(310, 17);
            txtEmailFilter.Location = new System.Drawing.Point(530, 17);
            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(680, 15);
            btnSearch.Click += btnSearch_Click;
            dataGridUsers.Location = new System.Drawing.Point(20, 60);
            dataGridUsers.Size = new System.Drawing.Size(730, 260);
            dataGridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridUsers.ReadOnly = true;
            dataGridUsers.AllowUserToAddRows = false;
            btnEditUser.Text = "Edit Selected";
            btnEditUser.Location = new System.Drawing.Point(20, 330);
            btnEditUser.Click += btnEditUser_Click;
            btnDeleteUser.Text = "Delete Selected";
            btnDeleteUser.Location = new System.Drawing.Point(150, 330);
            btnDeleteUser.Click += btnDeleteUser_Click;

            // btnLogout
            btnLogout.Text = "Logout";
            btnLogout.Location = new System.Drawing.Point(690, 10);
            btnLogout.Click += btnLogout_Click;

            // AdminDashboardForm
            this.Text = "Admin Dashboard";
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.AddRange(new Control[] {
                lblWelcome, tabControl, btnLogout
            });
        }
    }
}
