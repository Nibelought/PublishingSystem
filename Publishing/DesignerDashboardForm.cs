using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Publishing; // Для LoginForm

namespace PublishingSystem.UI
{
    public partial class DesignerDashboardForm : Form
    {
        private readonly User _currentUser;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        // dataGridViewBooksToDesign, dataGridViewMyDesigns, btnAssignDesignToMe, btnUploadCover, menuStrip1
        // должны быть из Designer.cs

        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;


        public DesignerDashboardForm(User currentUser)
        {
            InitializeComponent(); // Инициализирует контролы из Designer.cs
            _currentUser = currentUser;
            _bookService = new BookService();
            _userService = new UserService();

            InitializeUserMenu(); // Настраивает this.menuStrip1
            SetupDataGridViewBooksToDesign();
            SetupDataGridViewMyDesigns();
            LoadBooksToDesign();
            LoadMyDesigns();

            if(this.btnAssignDesignToMe != null) btnAssignDesignToMe.Click += BtnAssignDesignToMe_Click;
            if(this.btnUploadCover != null) btnUploadCover.Click += BtnUploadCover_Click;
            if(this.dataGridViewBooksToDesign != null) dataGridViewBooksToDesign.SelectionChanged += (s, e) => UpdateButtonStates();
            if(this.dataGridViewMyDesigns != null) dataGridViewMyDesigns.SelectionChanged += (s, e) => UpdateButtonStates();
            
            UpdateButtonStates();
        }

        private void InitializeUserMenu()
        {
             if (this.menuStrip1 == null) // Запасной вариант
             {
                this.menuStrip1 = new MenuStrip { Name = "menuStripDesignerProgrammatic", Dock = DockStyle.Top };
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
            this.menuItemUserActions.Name = "menuItemUserActionsDesigner";


            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemChangePassword.Name = "menuItemChangePasswordDesigner";


            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemChangeProfile.Name = "menuItemChangeProfileDesigner";

            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemLogout.Name = "menuItemLogoutDesigner";

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
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "AuthorName", DataPropertyName = "AuthorName", HeaderText = "Author", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "EditorName", DataPropertyName = "EditorName", HeaderText = "Editor", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "State", DataPropertyName = "StateDisplay", HeaderText = "Status", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "CoverImagePath", DataPropertyName = "CoverImagePath", HeaderText = "Cover Path", Width = 150 });
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            // dgv.Dock = DockStyle.Fill; // Dock в дизайнере
        }
        private void SetupDataGridViewBooksToDesign()
        {
            SetupBaseDataGridView(this.dataGridViewBooksToDesign);
        }

        private void SetupDataGridViewMyDesigns()
        {
             SetupBaseDataGridView(this.dataGridViewMyDesigns);
        }

        private void LoadBooksToDesign()
        {
            if (this.dataGridViewBooksToDesign == null) return;
            try
            {
                dataGridViewBooksToDesign.DataSource = _bookService.GetBooksNeedingDesigner();
            }
            catch (Exception ex) { MessageBox.Show($"Error loading books for design: {ex.Message}", "Error"); }
        }

        private void LoadMyDesigns()
        {
            if (this.dataGridViewMyDesigns == null) return;
            try
            {
                dataGridViewMyDesigns.DataSource = _bookService.GetBooksByDesigner(_currentUser.Id);
            }
            catch (Exception ex) { MessageBox.Show($"Error loading your designs: {ex.Message}", "Error");}
        }

        private void UpdateButtonStates()
        {
            if(this.btnAssignDesignToMe != null && this.dataGridViewBooksToDesign != null)
                btnAssignDesignToMe.Enabled = dataGridViewBooksToDesign.SelectedRows.Count == 1;
            if(this.btnUploadCover != null && this.dataGridViewMyDesigns != null)
                btnUploadCover.Enabled = dataGridViewMyDesigns.SelectedRows.Count == 1;
        }

        private void BtnAssignDesignToMe_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewBooksToDesign == null || dataGridViewBooksToDesign.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewBooksToDesign.SelectedRows[0].DataBoundItem;
            try
            {
                _bookService.AssignDesigner(selectedBook.Id, _currentUser.Id);
                MessageBox.Show($"Book '{selectedBook.Name}' assigned to you for design.", "Success");
                LoadBooksToDesign();
                LoadMyDesigns();
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Operation Error"); }
            catch (Exception ex) { MessageBox.Show($"Error assigning book: {ex.Message}", "Error"); }
            UpdateButtonStates();
        }

        private void BtnUploadCover_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewMyDesigns == null || dataGridViewMyDesigns.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one of your assigned books.", "Selection Required"); return;
            }
            var selectedBook = (Book)dataGridViewMyDesigns.SelectedRows[0].DataBoundItem;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourceFilePath = openFileDialog.FileName;
                        string coversDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Covers");
                        Directory.CreateDirectory(coversDirectory);
                        string fileExtension = Path.GetExtension(sourceFilePath);
                        string uniqueFileName = $"book_{selectedBook.Id}_cover_{Guid.NewGuid().ToString().Substring(0, 8)}{fileExtension}";
                        string destinationFilePath = Path.Combine(coversDirectory, uniqueFileName);
                        File.Copy(sourceFilePath, destinationFilePath, true);
                        string relativePath = Path.Combine("Covers", uniqueFileName);
                        _bookService.UpdateCoverPath(selectedBook.Id, relativePath);
                        MessageBox.Show("Cover image uploaded successfully!", "Success");
                        LoadMyDesigns();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error uploading cover: {ex.Message}", "Upload Error"); }
                }
            }
            UpdateButtonStates();
        }
    }
}