using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO; // Required for Path, Directory, File
using System.Linq;
using System.Windows.Forms;
using Publishing; // For LoginForm

namespace PublishingSystem.UI
{
    public partial class DesignerDashboardForm : Form
    {
        private readonly User _currentUser;
        private readonly BookService _bookService;
        private readonly UserService _userService;

        private Book _selectedMyBookForCover = null; // Книга, выбранная для загрузки обложки
        private string _newCoverFilePath = null;     // Путь к новому файлу обложки (локальный)

        // Controls from Designer - ensure they are declared in Designer.cs
        // private System.Windows.Forms.DataGridView dataGridViewAvailableBooks;
        // private System.Windows.Forms.DataGridView dataGridViewMyAssignedBooks;
        // private System.Windows.Forms.Button btnAssignToMe;
        // private System.Windows.Forms.Panel panelCoverUpload;
        // private System.Windows.Forms.PictureBox pictureBoxCoverPreview;
        // private System.Windows.Forms.Label lblDragDropInfo;
        // private System.Windows.Forms.Button btnBrowseCover;
        // private System.Windows.Forms.Label lblCurrentCoverPath;
        // private System.Windows.Forms.Button btnSaveCover;
        // private System.Windows.Forms.Button btnRefreshLists;
        // private System.Windows.Forms.MenuStrip menuStrip1;


        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;
        private ToolStripMenuItem menuItemRefreshLists;


        public DesignerDashboardForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _bookService = new BookService();
            _userService = new UserService();

            InitializeUserMenu();
            SetupDataGridViews();
            SetupCoverUploadPanel(); // Includes Drag & Drop
            RefreshAllBookListsDesigner();

            // Wire events (ensure controls exist)
            if (this.btnAssignToMe != null) this.btnAssignToMe.Click += BtnAssignToMe_Click;
            if (this.btnBrowseCover != null) this.btnBrowseCover.Click += BtnBrowseCover_Click;
            if (this.btnSaveCover != null) this.btnSaveCover.Click += BtnSaveCover_Click;

            if (this.dataGridViewAvailableBooks != null) this.dataGridViewAvailableBooks.SelectionChanged += (s, e) => UpdateButtonStatesAndPanel();
            if (this.dataGridViewMyAssignedBooks != null) this.dataGridViewMyAssignedBooks.SelectionChanged += DataGridViewMyAssignedBooks_SelectionChanged;
            
            UpdateButtonStatesAndPanel();
        }

        private void InitializeUserMenu()
        {
            if (this.menuStrip1 == null)
            {
                this.menuStrip1 = new MenuStrip { Name = "menuStripDesigner", Dock = DockStyle.Top };
                // Add to tableLayoutPanelMain's first row in constructor if tableLayoutPanelMain exists
                // this.Controls.Add(this.menuStrip1); // Or add to tableLayoutPanelMain
                this.MainMenuStrip = this.menuStrip1;
            }

            this.menuItemUserActions = new ToolStripMenuItem();
            this.menuItemChangePassword = new ToolStripMenuItem();
            this.menuItemChangeProfile = new ToolStripMenuItem();
            this.menuItemRefreshLists = new ToolStripMenuItem();
            this.menuItemLogout = new ToolStripMenuItem();

            this.menuItemUserActions.DropDownItems.AddRange(new ToolStripItem[] {
                this.menuItemChangePassword, this.menuItemChangeProfile, this.menuItemRefreshLists,
                new ToolStripSeparator(), this.menuItemLogout});
            this.menuItemUserActions.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
            this.menuItemUserActions.Alignment = ToolStripItemAlignment.Right;
            this.menuItemUserActions.Name = "menuItemUserActionsDesigner";

            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemChangePassword.Name = "menuItemChangePasswordDesigner";

            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemChangeProfile.Name = "menuItemChangeProfileDesigner";

            this.menuItemRefreshLists.Text = "Refresh Lists (F5)";
            this.menuItemRefreshLists.ShortcutKeys = Keys.F5;
            this.menuItemRefreshLists.ShowShortcutKeys = true;
            this.menuItemRefreshLists.Click += (s, e) => RefreshAllBookListsDesigner();
            this.menuItemRefreshLists.Name = "menuItemRefreshListsDesigner";

            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemLogout.Name = "menuItemLogoutDesigner";
            
            if(this.menuStrip1.Items.OfType<ToolStripMenuItem>().All(item => item.Name != "menuItemUserActionsDesigner"))
            {
                 this.menuStrip1.Items.Add(this.menuItemUserActions);
            }
            this.menuStrip1.BringToFront();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                RefreshAllBookListsDesigner();
                return true; 
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

        private void SetupDataGridViews()
        {
            ConfigureBookDataGridView(dataGridViewAvailableBooks);
            ConfigureBookDataGridView(dataGridViewMyAssignedBooks);
            if (dataGridViewMyAssignedBooks != null && !dataGridViewMyAssignedBooks.Columns.Contains("CoverPath"))
            {
                dataGridViewMyAssignedBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "CoverPath", DataPropertyName = "CoverImagePath", HeaderText = "Cover Path", Width = 150 });
            }
        }

        private void ConfigureBookDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookTitle", DataPropertyName = "Name", HeaderText = "Title", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Author", DataPropertyName = "AuthorName", HeaderText = "Author", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Editor", DataPropertyName = "EditorName", HeaderText = "Editor", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "CurrentState", DataPropertyName = "StateDisplay", HeaderText = "Status", Width = 100 });
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
        }

        private void SetupCoverUploadPanel()
        {
            if (panelCoverUpload != null) panelCoverUpload.Visible = false;
            if (pictureBoxCoverPreview != null)
            {
                pictureBoxCoverPreview.AllowDrop = true;
                pictureBoxCoverPreview.DragEnter += PictureBoxCoverPreview_DragEnter;
                pictureBoxCoverPreview.DragDrop += PictureBoxCoverPreview_DragDrop;
                pictureBoxCoverPreview.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxCoverPreview.BorderStyle = BorderStyle.FixedSingle;
            }
             if (lblDragDropInfo != null) lblDragDropInfo.Text = "Drag & Drop image here or";

        }

        private void RefreshAllBookListsDesigner()
        {
            LoadAvailableBooksForDesigner();
            LoadMyAssignedDesigns();
            UpdateButtonStatesAndPanel();
        }

        private void LoadAvailableBooksForDesigner()
        {
            if (dataGridViewAvailableBooks == null) return;
            try
            {
                dataGridViewAvailableBooks.DataSource = _bookService.GetBooksNeedingDesigner();
            }
            catch (Exception ex) { MessageBox.Show($"Error loading available books: {ex.Message}", "Load Error"); }
        }

        private void LoadMyAssignedDesigns()
        {
            if (dataGridViewMyAssignedBooks == null) return;
            try
            {
                dataGridViewMyAssignedBooks.DataSource = _bookService.GetBooksByDesigner(_currentUser.Id);
            }
            catch (Exception ex) { MessageBox.Show($"Error loading your designs: {ex.Message}", "Load Error"); }
        }

        private void UpdateButtonStatesAndPanel()
        {
            if (btnAssignToMe != null && dataGridViewAvailableBooks != null)
                btnAssignToMe.Enabled = dataGridViewAvailableBooks.SelectedRows.Count == 1;

            if (dataGridViewMyAssignedBooks != null && panelCoverUpload != null)
            {
                bool myBookSelected = dataGridViewMyAssignedBooks.SelectedRows.Count == 1;
                panelCoverUpload.Visible = myBookSelected;

                if (myBookSelected)
                {
                    Book newlySelectedBook = (Book)dataGridViewMyAssignedBooks.SelectedRows[0].DataBoundItem;
                    if (_selectedMyBookForCover != newlySelectedBook) // Если выбор книги изменился
                    {
                        _selectedMyBookForCover = newlySelectedBook;
                        _newCoverFilePath = null; // Сбрасываем выбор файла при смене книги
                        LoadCoverPreview(_selectedMyBookForCover.CoverImagePath, false); // Загружаем существующую обложку (не локальный файл)
                    }
                    // Если та же книга осталась выбрана, _newCoverFilePath не трогаем
                }
                else // Никакая книга из "моих" не выбрана
                {
                    _selectedMyBookForCover = null;
                    _newCoverFilePath = null; // Сбрасываем выбор файла
                    LoadCoverPreview(null, false); // Очищаем превью
                    if(lblCurrentCoverPath != null) lblCurrentCoverPath.Text = "Current: Not set";
                }
            }
            else if (panelCoverUpload != null) // Если грида нет, скрываем панель
            {
                panelCoverUpload.Visible = false;
                _selectedMyBookForCover = null;
                _newCoverFilePath = null;
                LoadCoverPreview(null, false);
            }
            UpdateButtonSaveCoverState(); // Обновляем состояние кнопки Save
        }
        
        private void DataGridViewMyAssignedBooks_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStatesAndPanel();
        }

        private void BtnAssignToMe_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableBooks == null || dataGridViewAvailableBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewAvailableBooks.SelectedRows[0].DataBoundItem;
            try
            {
                _bookService.AssignDesigner(selectedBook.Id, _currentUser.Id); // This also sets state to ready_to_print
                MessageBox.Show($"Book '{selectedBook.Name}' assigned to you for design.", "Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAllBookListsDesigner();
            }
            catch (Exception ex) { MessageBox.Show($"Error assigning book: {ex.Message}", "Error"); }
        }

        private void PictureBoxCoverPreview_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && IsImageFile(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PictureBoxCoverPreview_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1 && IsImageFile(files[0]))
            {
                _newCoverFilePath = files[0];
                LoadCoverPreview(_newCoverFilePath, true); // true - это новый локальный файл
                // UpdateButtonSaveCoverState() вызовется в конце LoadCoverPreview
            }
        }

        private void BtnBrowseCover_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // ... (настройка openFileDialog) ...
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (IsImageFile(openFileDialog.FileName))
                    {
                        _newCoverFilePath = openFileDialog.FileName;
                        LoadCoverPreview(_newCoverFilePath, true); // true - это новый локальный файл
                        // UpdateButtonSaveCoverState() вызовется в конце LoadCoverPreview
                    }
                    else
                    {
                        MessageBox.Show("Selected file is not a valid image.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        
        private bool IsImageFile(string filePath)
        {
            try
            {
                string ext = Path.GetExtension(filePath)?.ToLowerInvariant();
                return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
            }
            catch { return false; }
        }

        private void LoadCoverPreview(string imagePath, bool isNewLocalFileSelection = false)
        {
            if (pictureBoxCoverPreview == null) return;

            // Сначала очищаем предыдущее изображение из PictureBox, но не _newCoverFilePath
            if (pictureBoxCoverPreview.Image != null)
            {
                pictureBoxCoverPreview.Image.Dispose();
                pictureBoxCoverPreview.Image = null;
            }

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    // Если это не новый локальный файл, то путь берем относительно директории приложения
                    string fullPath = isNewLocalFileSelection ? imagePath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);

                    if (File.Exists(fullPath))
                    {
                        using (var bmpTemp = new Bitmap(fullPath))
                        {
                            pictureBoxCoverPreview.Image = new Bitmap(bmpTemp);
                        }
                        // Если это был путь из БД (не новый локальный файл), то _newCoverFilePath должен быть null
                        if (!isNewLocalFileSelection)
                        {
                            // _newCoverFilePath = null; // Сброс, если это загрузка из БД
                            // Это нужно, чтобы после загрузки из БД, кнопка Save была неактивна, пока не выбран НОВЫЙ файл.
                            // Однако, если мы только что выбрали файл, isNewLocalFileSelection будет true, и эта строка не выполнится.
                        }
                    }
                    else
                    {
                         // Если файл не найден (особенно для пути из БД), просто оставляем PictureBox пустым.
                        if (!isNewLocalFileSelection) // Только если это путь из БД
                             Console.WriteLine($"Cover image not found at: {fullPath}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading cover preview for path '{imagePath}': {ex.Message}");
                    pictureBoxCoverPreview.Image = null;
                }
            }
            
            // Обновляем текст текущего пути, если он связан с выбранной книгой
            if (!isNewLocalFileSelection && lblCurrentCoverPath != null && _selectedMyBookForCover != null)
            {
                lblCurrentCoverPath.Text = $"Current: {_selectedMyBookForCover.CoverImagePath ?? "Not set"}";
            }
            else if (isNewLocalFileSelection && lblCurrentCoverPath != null) // Показываем путь к новому выбранному файлу
            {
                lblCurrentCoverPath.Text = $"New: {Path.GetFileName(imagePath)}";
            }

            // Активация кнопки Save должна зависеть от _newCoverFilePath и _selectedMyBookForCover
            UpdateButtonSaveCoverState();
        }

        // Переименуем ClearCoverPreview в нечто более конкретное или интегрируем в UpdateButtonStatesAndPanel
        private void ResetCoverSelectionState()
        {
            if (pictureBoxCoverPreview != null && pictureBoxCoverPreview.Image != null)
            {
                pictureBoxCoverPreview.Image.Dispose();
                pictureBoxCoverPreview.Image = null;
            }
            _newCoverFilePath = null;
            
            if(lblCurrentCoverPath != null)
            {
                if (_selectedMyBookForCover != null && !string.IsNullOrEmpty(_selectedMyBookForCover.CoverImagePath))
                {
                    lblCurrentCoverPath.Text = $"Current: {_selectedMyBookForCover.CoverImagePath}";
                    // Попробуем загрузить существующую обложку при сбросе, если она есть
                    LoadCoverPreview(_selectedMyBookForCover.CoverImagePath, false);
                }
                else
                {
                    lblCurrentCoverPath.Text = "Current: Not set";
                }
            }
            UpdateButtonSaveCoverState();
        }

        // Новый метод для управления состоянием кнопки btnSaveCover
        private void UpdateButtonSaveCoverState()
        {
            if (btnSaveCover != null)
            {
                btnSaveCover.Enabled = _selectedMyBookForCover != null && !string.IsNullOrEmpty(_newCoverFilePath) && File.Exists(_newCoverFilePath);
            }
        }
        
        private void BtnSaveCover_Click(object sender, EventArgs e)
        {
            if (_selectedMyBookForCover == null)
            {
                MessageBox.Show("No book selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(_newCoverFilePath) || !File.Exists(_newCoverFilePath))
            {
                MessageBox.Show("No new cover image selected or file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string coversDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookCovers"); // Changed folder name
                Directory.CreateDirectory(coversDirectory); // Create if it doesn't exist

                string fileExtension = Path.GetExtension(_newCoverFilePath);
                string uniqueFileName = $"book_{_selectedMyBookForCover.Id}_{Guid.NewGuid().ToString().Substring(0, 6)}{fileExtension}";
                string destinationFilePath = Path.Combine(coversDirectory, uniqueFileName);

                File.Copy(_newCoverFilePath, destinationFilePath, true); // Overwrite if exists

                string relativeDbPath = Path.Combine("BookCovers", uniqueFileName);
                _bookService.UpdateCoverPath(_selectedMyBookForCover.Id, relativeDbPath);

                MessageBox.Show("Cover image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _newCoverFilePath = null; // Reset after saving
                RefreshAllBookListsDesigner(); // To show updated path in grid and reload preview
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving cover: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateButtonStatesAndPanel();
        }
    }
}