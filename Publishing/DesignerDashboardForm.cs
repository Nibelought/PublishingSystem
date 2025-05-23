using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO; // Required for Path, Directory, File
using System.Linq;
using System.Windows.Forms;
using Publishing; // For LoginForm
using PublishingSystem.UI.Helpers; // For dgv sort

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
        // private System.Windows.Forms.Button btnClearCoverSelection; // Added this
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

            if (this.dataGridViewAvailableBooks != null)
            {
                this.dataGridViewAvailableBooks.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }
            if (this.dataGridViewMyAssignedBooks != null)
            {
                this.dataGridViewMyAssignedBooks.ColumnHeaderMouseClick += (sender, e) =>
                    DataGridViewSortHelper.HandleColumnHeaderMouseClick(sender as DataGridView, e);
            }

            // Wire events (ensure controls exist)
            if (this.btnAssignToMe != null) this.btnAssignToMe.Click += BtnAssignToMe_Click;
            if (this.btnBrowseCover != null) this.btnBrowseCover.Click += BtnBrowseCover_Click;
            if (this.btnSaveCover != null) this.btnSaveCover.Click += BtnSaveCover_Click;
            if (this.btnClearCoverSelection != null) this.btnClearCoverSelection.Click += BtnClearCoverSelection_Click; // Ensure this button exists

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

            if (this.menuStrip1.Items.OfType<ToolStripMenuItem>().All(item => item.Name != "menuItemUserActionsDesigner"))
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
            // UpdateButtonStatesAndPanel will be called implicitly by DGV selection change
            // or explicitly if selection doesn't change but data does.
            // For safety, can call it here, but it might cause a flicker if LoadMyAssignedDesigns clears selection.
            // A better approach is to preserve selection if possible or let selection changed events handle it.
            // For now, we'll let the selection change event handle it.
            // If no rows after refresh, selection changed won't fire, so manual call is good.
            if (dataGridViewMyAssignedBooks != null && dataGridViewMyAssignedBooks.Rows.Count == 0)
            {
                 _selectedMyBookForCover = null; // Ensure it's cleared if list is empty
                 _newCoverFilePath = null;
                 UpdateButtonStatesAndPanel();
            }
        }

        private void LoadAvailableBooksForDesigner()
        {
            if (dataGridViewAvailableBooks == null) return;
            try
            {
                var currentSelection = dataGridViewAvailableBooks.SelectedRows.Count > 0 ? dataGridViewAvailableBooks.SelectedRows[0].DataBoundItem as Book : null;
                int? currentSelectionId = currentSelection?.Id;

                dataGridViewAvailableBooks.DataSource = null; // Force refresh
                dataGridViewAvailableBooks.DataSource = _bookService.GetBooksNeedingDesigner();

                if (currentSelectionId.HasValue)
                {
                    foreach (DataGridViewRow row in dataGridViewAvailableBooks.Rows)
                    {
                        if (row.DataBoundItem is Book book && book.Id == currentSelectionId.Value)
                        {
                            row.Selected = true;
                            dataGridViewAvailableBooks.CurrentCell = row.Cells[0]; // Or first visible cell
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading available books: {ex.Message}", "Load Error"); }
        }

        private void LoadMyAssignedDesigns()
        {
            if (dataGridViewMyAssignedBooks == null) return;
            try
            {
                var currentSelection = _selectedMyBookForCover; // Use the existing _selectedMyBookForCover
                int? currentSelectionId = currentSelection?.Id;

                dataGridViewMyAssignedBooks.DataSource = null; // Force refresh
                dataGridViewMyAssignedBooks.DataSource = _bookService.GetBooksByDesigner(_currentUser.Id);

                if (currentSelectionId.HasValue)
                {
                    bool found = false;
                    foreach (DataGridViewRow row in dataGridViewMyAssignedBooks.Rows)
                    {
                        if (row.DataBoundItem is Book book && book.Id == currentSelectionId.Value)
                        {
                            row.Selected = true;
                            dataGridViewMyAssignedBooks.CurrentCell = row.Cells[0]; // Or first visible cell
                            _selectedMyBookForCover = book; // Re-assign if found
                            found = true;
                            break;
                        }
                    }
                    if (!found) // If previously selected book is no longer in the list
                    {
                        _selectedMyBookForCover = null;
                        _newCoverFilePath = null; // Important: Reset this
                        // UpdateButtonStatesAndPanel will be called by selection change if a new row is selected,
                        // or needs to be called if no row is selected.
                        if (dataGridViewMyAssignedBooks.SelectedRows.Count == 0)
                        {
                             UpdateButtonStatesAndPanel(); // Explicit call if selection is lost and not regained
                        }
                    }
                } else if (dataGridViewMyAssignedBooks.Rows.Count == 0) {
                     _selectedMyBookForCover = null; // Ensure it's cleared if list is empty
                     _newCoverFilePath = null;
                     UpdateButtonStatesAndPanel();
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading your designs: {ex.Message}", "Load Error"); }
        }

        private void UpdateButtonStatesAndPanel()
        {
            if (btnAssignToMe != null && dataGridViewAvailableBooks != null)
                btnAssignToMe.Enabled = dataGridViewAvailableBooks.SelectedRows.Count == 1;

            bool myBookSelected = _selectedMyBookForCover != null; // Use the field directly

            if (panelCoverUpload != null)
            {
                panelCoverUpload.Visible = myBookSelected;
            }

            // Handle cover preview and path label
            if (myBookSelected)
            {
                // If _newCoverFilePath is set, it means user has selected a new local file.
                // Otherwise, load from the book's existing path.
                if (!string.IsNullOrEmpty(_newCoverFilePath))
                {
                    LoadCoverPreview(_newCoverFilePath, true); // It's a new local file
                }
                else
                {
                    LoadCoverPreview(_selectedMyBookForCover.CoverImagePath, false); // It's from DB
                }
            }
            else // No book selected in "My Assigned Books"
            {
                if (pictureBoxCoverPreview != null && pictureBoxCoverPreview.Image != null)
                {
                    pictureBoxCoverPreview.Image.Dispose();
                    pictureBoxCoverPreview.Image = null;
                }
                if (lblCurrentCoverPath != null) lblCurrentCoverPath.Text = "Current: Not set";
            }
            UpdateButtonSaveCoverState();
        }

        private void DataGridViewMyAssignedBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMyAssignedBooks == null || dataGridViewMyAssignedBooks.SelectedRows.Count == 0)
            {
                if (_selectedMyBookForCover != null) // If there was a selection before
                {
                    _selectedMyBookForCover = null;
                    _newCoverFilePath = null; // Critical: reset new file path if selection is lost
                    UpdateButtonStatesAndPanel();
                }
                return;
            }

            Book newlySelectedBook = (Book)dataGridViewMyAssignedBooks.SelectedRows[0].DataBoundItem;
            if (_selectedMyBookForCover != newlySelectedBook)
            {
                _selectedMyBookForCover = newlySelectedBook;
                _newCoverFilePath = null; // Critical: reset new file path on book change
                UpdateButtonStatesAndPanel();
            }
            // If the same book is re-selected (e.g., after a refresh), _newCoverFilePath remains,
            // and UpdateButtonStatesAndPanel will handle the preview correctly.
        }


        private void BtnAssignToMe_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableBooks == null || dataGridViewAvailableBooks.SelectedRows.Count != 1) return;
            var selectedBook = (Book)dataGridViewAvailableBooks.SelectedRows[0].DataBoundItem;
            try
            {
                _bookService.AssignDesigner(selectedBook.Id, _currentUser.Id);
                MessageBox.Show($"Book '{selectedBook.Name}' assigned to you for design.", "Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAllBookListsDesigner();
            }
            catch (Exception ex) { MessageBox.Show($"Error assigning book: {ex.Message}", "Error"); }
        }

        private void PictureBoxCoverPreview_DragEnter(object sender, DragEventArgs e)
        {
            if (_selectedMyBookForCover == null) // Don't allow drop if no book selected
            {
                e.Effect = DragDropEffects.None;
                return;
            }
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
            if (_selectedMyBookForCover == null) return; // Should not happen if DragEnter is correct

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1 && IsImageFile(files[0]))
            {
                _newCoverFilePath = files[0];
                LoadCoverPreview(_newCoverFilePath, true); // true - это новый локальный файл
            }
        }

        private void BtnBrowseCover_Click(object sender, EventArgs e)
        {
            if (_selectedMyBookForCover == null) // Don't allow browse if no book selected
            {
                MessageBox.Show("Please select a book from 'My Assigned Books' first.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG;*.GIF)|*.BMP;*.JPG;*.JPEG;*.PNG;*.GIF";
                openFileDialog.Title = "Select Cover Image";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (IsImageFile(openFileDialog.FileName))
                    {
                        _newCoverFilePath = openFileDialog.FileName;
                        LoadCoverPreview(_newCoverFilePath, true); // true - это новый локальный файл
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

        private void LoadCoverPreview(string imagePath, bool isNewLocalFileSelection)
        {
            if (pictureBoxCoverPreview == null) return;

            // Clear previous image from PictureBox
            if (pictureBoxCoverPreview.Image != null)
            {
                pictureBoxCoverPreview.Image.Dispose();
                pictureBoxCoverPreview.Image = null;
            }

            string displayPathName = "Not set";
            bool fileExists = false;

            if (!string.IsNullOrEmpty(imagePath))
            {
                string fullPath;
                if (isNewLocalFileSelection)
                {
                    fullPath = imagePath; // This is already a full local path
                    displayPathName = Path.GetFileName(imagePath);
                }
                else // Path is from DB (relative)
                {
                    // If imagePath itself is a placeholder like "missing" or "not_found.jpg"
                    // treat it as such and don't try to combine with BaseDirectory.
                    // For now, assume imagePath from DB is always a relative path to an actual file or null.
                    if (Path.IsPathRooted(imagePath)) // Should not happen for DB paths, but as a safeguard
                    {
                        fullPath = imagePath;
                    }
                    else
                    {
                        fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
                    }
                    displayPathName = Path.GetFileName(imagePath); // Show relative part from DB
                }


                if (File.Exists(fullPath))
                {
                    fileExists = true;
                    try
                    {
                        using (var bmpTemp = new Bitmap(fullPath))
                        {
                            pictureBoxCoverPreview.Image = new Bitmap(bmpTemp);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading cover preview for path '{fullPath}': {ex.Message}");
                        // PictureBox remains empty
                        fileExists = false; // Mark as not existing if load fails
                    }
                }
                else
                {
                    // File does not exist at fullPath
                    Console.WriteLine($"Cover image not found at: {fullPath}");
                }
            }

            // Update lblCurrentCoverPath
            if (lblCurrentCoverPath != null)
            {
                if (isNewLocalFileSelection) // Always show "New:" if a new local file is pending
                {
                    lblCurrentCoverPath.Text = $"New: {displayPathName}";
                }
                else // Showing existing cover from DB
                {
                    if (string.IsNullOrEmpty(_selectedMyBookForCover?.CoverImagePath)) // Check the book's actual property
                    {
                        lblCurrentCoverPath.Text = "Current: Not set";
                    }
                    else if (!fileExists)
                    {
                        lblCurrentCoverPath.Text = $"Current: {displayPathName} (Not Found)";
                    }
                    else
                    {
                        lblCurrentCoverPath.Text = $"Current: {displayPathName}";
                    }
                }
            }
            UpdateButtonSaveCoverState();
        }


        private void ResetCoverSelectionState()
        {
            _newCoverFilePath = null; // Crucial to reset the path to the NEW file

            // Reload the existing cover of the currently selected book (if any)
            // or clear the preview if no book or no cover.
            if (_selectedMyBookForCover != null)
            {
                LoadCoverPreview(_selectedMyBookForCover.CoverImagePath, false);
            }
            else
            {
                if (pictureBoxCoverPreview != null && pictureBoxCoverPreview.Image != null)
                {
                    pictureBoxCoverPreview.Image.Dispose();
                    pictureBoxCoverPreview.Image = null;
                }
                if (lblCurrentCoverPath != null) lblCurrentCoverPath.Text = "Current: Not set";
            }
            UpdateButtonSaveCoverState();
        }

        private void BtnClearCoverSelection_Click(object sender, EventArgs e)
        {
            ResetCoverSelectionState();
        }

        private void UpdateButtonSaveCoverState()
        {
            if (btnSaveCover != null)
            {
                // Save button is enabled if:
                // 1. A book is selected in "My Assigned Books" (_selectedMyBookForCover is not null)
                // 2. A new local file has been chosen (_newCoverFilePath is not null and exists)
                btnSaveCover.Enabled = _selectedMyBookForCover != null &&
                                       !string.IsNullOrEmpty(_newCoverFilePath) &&
                                       File.Exists(_newCoverFilePath);
            }
        }

        private void BtnSaveCover_Click(object sender, EventArgs e)
        {
            if (_selectedMyBookForCover == null)
            {
                MessageBox.Show("No book selected from 'My Assigned Books'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(_newCoverFilePath) || !File.Exists(_newCoverFilePath))
            {
                MessageBox.Show("No new cover image selected, or the selected file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string coversDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookCovers");
                Directory.CreateDirectory(coversDirectory);

                string fileExtension = Path.GetExtension(_newCoverFilePath);
                // Sanitize book name for filename (optional, but good practice)
                string sanitizedBookName = string.Join("_", _selectedMyBookForCover.Name.Split(Path.GetInvalidFileNameChars()));

                string uniqueFileName = $"book_{_selectedMyBookForCover.Id}_{sanitizedBookName}_{Guid.NewGuid().ToString().Substring(0, 6)}{fileExtension}";
                string destinationFilePath = Path.Combine(coversDirectory, uniqueFileName);

                File.Copy(_newCoverFilePath, destinationFilePath, true);

                string relativeDbPath = Path.Combine("BookCovers", uniqueFileName);
                _bookService.UpdateCoverPath(_selectedMyBookForCover.Id, relativeDbPath);

                MessageBox.Show("Cover image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update the book object in the DataGridView's data source
                _selectedMyBookForCover.CoverImagePath = relativeDbPath; // Update in-memory object

                _newCoverFilePath = null; // Reset after saving, so preview now shows the saved DB path

                // Refreshing the list might cause selection loss if not handled carefully.
                // Instead, directly update the UI for the current selection.
                // RefreshAllBookListsDesigner(); // This might be too heavy and could lose selection context

                // After saving, we want the preview to reflect the newly saved DB path, not the local file path
                LoadCoverPreview(_selectedMyBookForCover.CoverImagePath, false); // false, as it's now from "DB"
                UpdateButtonSaveCoverState(); // Save button should become disabled

                // Optional: Find the row in DGV and refresh it if DataSource doesn't auto-update
                if (dataGridViewMyAssignedBooks.DataSource is IList<Book> bookList)
                {
                    int index = bookList.IndexOf(_selectedMyBookForCover);
                    if (index >= 0)
                    {
                        // This forces a refresh of the row if binding is set up correctly
                        var bs = dataGridViewMyAssignedBooks.DataSource as BindingSource;
                        if (bs != null) bs.ResetItem(index);
                        else dataGridViewMyAssignedBooks.Refresh(); // Fallback
                    }
                } else {
                    // Fallback if not directly updatable, less ideal
                     RefreshAllBookListsDesigner();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving cover: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Don't reset _newCoverFilePath here, user might want to try saving again
                UpdateButtonSaveCoverState(); // Ensure save button state is correct
            }
        }
    }
}