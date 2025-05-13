using PublishingSystem.BLL;
using System;
using System.Windows.Forms;

namespace PublishingSystem.UI
{
    public partial class ChangePasswordForm : Form
    {
        private readonly int _userId;
        private readonly string _userRole; // Роль нужна для UserService
        private readonly UserService _userService;

        // Конструктор принимает ID и Роль пользователя
        public ChangePasswordForm(int userId, string userRole)
        {
            InitializeComponent();
            _userId = userId;
            _userRole = userRole;
            _userService = new UserService();
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _userService.ChangePassword(_userId, _userRole, currentPassword, newPassword);
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (UnauthorizedAccessException ex) // Неверный текущий пароль
            {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 txtCurrentPassword.Focus();
                 txtCurrentPassword.SelectAll();
            }
            catch (ArgumentException ex) // Неверный новый пароль (слабый и т.д.)
            {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtNewPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // --- Design Notes for ChangePasswordForm.Designer.cs ---
    // - Add 3 Labels: "Current Password:", "New Password:", "Confirm Password:"
    // - Add 3 TextBoxes: txtCurrentPassword, txtNewPassword, txtConfirmPassword (set PasswordChar = '*')
    // - Add 2 Buttons: btnSave, btnCancel
    // - Arrange controls vertically.
    // ------------------------------------------------------
}