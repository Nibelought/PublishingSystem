using PublishingSystem.BLL;
using PublishingSystem.Models; // For User
using System;
using System.Windows.Forms;

namespace PublishingSystem.UI
{
    public partial class ChangeProfileForm : Form
    {
        private readonly User _currentUser;
        private readonly UserService _userService;

        // Property for new value
        public string NewFirstName { get; private set; }
        public string NewLastName { get; private set; }


        public ChangeProfileForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _userService = new UserService();
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            if (this.btnSave != null) // Проверка, что кнопка создана дизайнером
            {
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            }
            else
            {
                MessageBox.Show("ERROR: btnSave is null in ChangePasswordForm constructor!");
            }

            if (this.btnCancel != null)
            {
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            }

            // Fill with current value
            txtFirstName.Text = _currentUser.FirstName;
            txtLastName.Text = _currentUser.LastName;
            NewFirstName = _currentUser.FirstName; // Initialize in case of cancel
            NewLastName = _currentUser.LastName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            MessageBox.Show($"Click go!");


            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("First name and last name are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                 _userService.UpdateProfile(_currentUser.Id, _currentUser.Role, firstName, lastName);

                 // Save new values for passing back
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
}