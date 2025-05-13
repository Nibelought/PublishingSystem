using PublishingSystem.BLL;
using PublishingSystem.Models; // Для User
using System;
using System.Windows.Forms;

namespace PublishingSystem.UI
{
    public partial class ChangeProfileForm : Form
    {
        private readonly User _currentUser;
        private readonly UserService _userService;

        // Свойства для возврата новых значений
        public string NewFirstName { get; private set; }
        public string NewLastName { get; private set; }


        public ChangeProfileForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _userService = new UserService();
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;

            // Заполнить текущими значениями
            txtFirstName.Text = _currentUser.FirstName;
            txtLastName.Text = _currentUser.LastName;
            NewFirstName = _currentUser.FirstName; // Инициализация на случай отмены
            NewLastName = _currentUser.LastName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("First name and last name are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                 _userService.UpdateProfile(_currentUser.Id, _currentUser.Role, firstName, lastName);

                 // Сохраняем новые значения для передачи назад
                 NewFirstName = firstName;
                 NewLastName = lastName;

                 MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 this.DialogResult = DialogResult.OK; // Сигнализируем об успехе
                 this.Close();
            }
            catch (ArgumentException ex)
            {
                 MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    // --- Design Notes for ChangeProfileForm.Designer.cs ---
    // - Add 2 Labels: "First Name:", "Last Name:"
    // - Add 2 TextBoxes: txtFirstName, txtLastName
    // - Add 2 Buttons: btnSave, btnCancel
    // - Arrange controls.
    // ------------------------------------------------------
}