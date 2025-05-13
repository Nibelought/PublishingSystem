using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using Publishing; // Для LoginForm

namespace PublishingSystem.UI
{
    public partial class EditorDashboardForm : Form
    {
        private readonly User _currentUser;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        // dataGridViewBooksToEdit, dataGridViewMyBooks, btnAssignToMe, menuStrip1
        // должны быть объявлены и инициализированы в EditorDashboardForm.Designer.cs

        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;

        public EditorDashboardForm(User currentUser)
        {
            InitializeComponent(); // Инициализирует контролы из Designer.cs
            _currentUser = currentUser;
            _bookService = new BookService();
            _userService = new UserService();

            InitializeUserMenu(); // Настраивает this.menuStrip1
            SetupDataGridViewBooksToEdit();
            SetupDataGridViewMyBooks();
            LoadBooksToEdit();
            LoadMyBooks();

            if (this.btnAssignToMe != null) btnAssignToMe.Click += BtnAssignToMe_Click;
            if (this.dataGridViewBooksToEdit != null) dataGridViewBooksToEdit.SelectionChanged += (s, e) => UpdateButtonState();
            
            UpdateButtonState();
        }

        private void InitializeUserMenu()
        {
            if (this.menuStrip1 == null) // Запасной вариант, если menuStrip1 не из дизайнера
            {
                this.menuStrip1 = new MenuStrip { Name = "menuStripEditorProgrammatic", Dock = DockStyle.Top };
                this.Controls.Add(this.menuStrip1);
                this.MainMenuStrip = this.menuStrip1;
            }

            this.menuItemUserActions = new ToolStripMenuItem();
            this.menuItemChangePassword = new ToolStripMenuItem();
            this.menuItemChangeProfile = new ToolStripMenuItem();
            this.menuItemLogout = new ToolStripMenuItem();

            this.menuItemUserActions.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuItemChangePassword, this.menuItemChangeProfile, new ToolStripSeparator(), this.menuItemLogout});
            this.menuItemUserActions.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
            this.menuItemUserActions.Alignment = ToolStripItemAlignment.Right;
             this.menuItemUserActions.Name = "menuItemUserActionsEditor";


            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemChangePassword.Name = "menuItemChangePasswordEditor";

            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemChangeProfile.Name = "menuItemChangeProfileEditor";

            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemLogout.Name = "menuItemLogoutEditor";

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
                    if(menuItemUserActions != null) menuItemUserActions.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
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
        
        private void SetupBaseDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "AuthorName", DataPropertyName = "AuthorName", HeaderText = "Author", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "State", DataPropertyName = "StateDisplay", HeaderText = "Status", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstimatedEndDate", DataPropertyName = "EstimatedEndDate", HeaderText = "Est. End Date", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            // dgv.Dock = DockStyle.Fill; // Dock устанавливается в дизайнере SplitContainer
        }

        private void SetupDataGridViewBooksToEdit()
        {
            SetupBaseDataGridView(this.dataGridViewBooksToEdit);
        }

        private void SetupDataGridViewMyBooks()
        {
            SetupBaseDataGridView(this.dataGridViewMyBooks);
            if (this.dataGridViewMyBooks != null)
            {
                 dataGridViewMyBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "DesignerName", DataPropertyName = "DesignerName", HeaderText = "Designer", Width = 150 });
            }
        }

        private void LoadBooksToEdit()
        {
            if (this.dataGridViewBooksToEdit == null) return;
            try
            {
                dataGridViewBooksToEdit.DataSource = _bookService.GetBooksNeedingEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books for editing: {ex.Message}", "Error");
            }
        }

        private void LoadMyBooks()
        {
            if (this.dataGridViewMyBooks == null) return;
            try
            {
                dataGridViewMyBooks.DataSource = _bookService.GetBooksByEditor(_currentUser.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading your assigned books: {ex.Message}", "Error");
            }
        }
        private void UpdateButtonState()
        {
            if (this.btnAssignToMe != null && this.dataGridViewBooksToEdit != null)
            {
                btnAssignToMe.Enabled = dataGridViewBooksToEdit.SelectedRows.Count == 1;
            }
        }

        private void BtnAssignToMe_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewBooksToEdit == null || dataGridViewBooksToEdit.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewBooksToEdit.SelectedRows[0].DataBoundItem;
            try
            {
                _bookService.AssignEditor(selectedBook.Id, _currentUser.Id);
                MessageBox.Show($"Book '{selectedBook.Name}' assigned to you.", "Success");
                LoadBooksToEdit();
                LoadMyBooks();
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Operation Error"); }
            catch (Exception ex) { MessageBox.Show($"Error assigning book: {ex.Message}", "Error"); }
            UpdateButtonState();
        }
    }
}