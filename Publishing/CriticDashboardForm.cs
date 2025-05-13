using PublishingSystem.BLL;
using PublishingSystem.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Publishing; // Для LoginForm

namespace PublishingSystem.UI
{
    public partial class CriticDashboardForm : Form
    {
        private readonly User _currentUser;
        private readonly BookService _bookService;
        private readonly ReviewService _reviewService;
        private readonly UserService _userService;

        // menuStrip1, comboBooks, richTextBoxReview, btnBold, btnItalic, numericGradeBook, numericGradeCover, btnSubmitReview
        // должны быть из Designer.cs

        private ToolStripMenuItem menuItemUserActions;
        private ToolStripMenuItem menuItemChangePassword;
        private ToolStripMenuItem menuItemChangeProfile;
        private ToolStripMenuItem menuItemLogout;

        public CriticDashboardForm(User currentUser)
        {
            InitializeComponent(); // Инициализирует контролы из Designer.cs
            _currentUser = currentUser;
            _bookService = new BookService();
            _reviewService = new ReviewService();
            _userService = new UserService();

            InitializeUserMenu(); // Настраивает this.menuStrip1
            LoadBooksForReview();
            SetupControls();

            if(this.btnSubmitReview != null) btnSubmitReview.Click += BtnSubmitReview_Click;
            if(this.btnBold != null) btnBold.Click += (s, e) => ToggleFontStyle(FontStyle.Bold);
            if(this.btnItalic != null) btnItalic.Click += (s, e) => ToggleFontStyle(FontStyle.Italic);
        }

        private void InitializeUserMenu()
        {
            if (this.menuStrip1 == null) // Запасной вариант
            {
                 this.menuStrip1 = new MenuStrip { Name = "menuStripCriticProgrammatic", Dock = DockStyle.Top };
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
            this.menuItemUserActions.Name = "menuItemUserActionsCritic";


            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += MenuItemChangePassword_Click;
            this.menuItemChangePassword.Name = "menuItemChangePasswordCritic";

            this.menuItemChangeProfile.Text = "Change Name/Surname";
            this.menuItemChangeProfile.Click += MenuItemChangeProfile_Click;
            this.menuItemChangeProfile.Name = "menuItemChangeProfileCritic";

            this.menuItemLogout.Text = "Logout";
            this.menuItemLogout.Click += MenuItemLogout_Click;
            this.menuItemLogout.Name = "menuItemLogoutCritic";

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

        private void SetupControls()
        {
            if(this.numericGradeBook != null)
            {
                numericGradeBook.Minimum = 0; numericGradeBook.Maximum = 10;
                numericGradeBook.DecimalPlaces = 1; numericGradeBook.Increment = 0.5m;
            }
            if(this.numericGradeCover != null)
            {
                numericGradeCover.Minimum = 0; numericGradeCover.Maximum = 10;
                numericGradeCover.DecimalPlaces = 1; numericGradeCover.Increment = 0.5m;
            }
        }

        private void LoadBooksForReview()
        {
            if (this.comboBooks == null) return;
            try
            {
                var books = _bookService.GetBooksForReview();
                comboBooks.DataSource = books;
                comboBooks.DisplayMember = "Name";
                comboBooks.ValueMember = "Id";
                comboBooks.SelectedIndex = books.Any() ? 0 : -1;
            }
            catch (Exception ex) { MessageBox.Show($"Error loading books: {ex.Message}", "Error"); }
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (this.richTextBoxReview == null || richTextBoxReview.SelectionFont == null) return;
            Font currentFont = richTextBoxReview.SelectionFont;
            FontStyle newStyle = richTextBoxReview.SelectionFont.Style ^ style;
            richTextBoxReview.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            richTextBoxReview.Focus();
        }

        private void BtnSubmitReview_Click(object sender, EventArgs e)
        {
            if (this.comboBooks == null || this.richTextBoxReview == null || this.numericGradeBook == null || this.numericGradeCover == null) return;

            if (comboBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select a book.", "Validation Error"); return;
            }
            if (string.IsNullOrWhiteSpace(richTextBoxReview.Text))
            {
                MessageBox.Show("Review text cannot be empty.", "Validation Error"); return;
            }
            try
            {
                var review = new Review
                {
                    IdBook = (int)comboBooks.SelectedValue,
                    IdCritic = _currentUser.Id,
                    RtfText = richTextBoxReview.Rtf,
                    GradeBook = numericGradeBook.Value,
                    GradeCover = numericGradeCover.Value
                };
                _reviewService.AddReview(review);
                MessageBox.Show("Review submitted successfully!", "Success");
                richTextBoxReview.Clear();
                numericGradeBook.Value = 0;
                numericGradeCover.Value = 0;
                if (comboBooks.Items.Count > 0) comboBooks.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show($"Error submitting review: {ex.Message}", "Error"); }
        }
    }
}