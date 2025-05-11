using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Publishing;
using PublishingSystem.BLL;
using PublishingSystem.Models;

namespace PublishingSystem.UI
{
    public partial class AdminDashboardForm : Form
    {
        private readonly User _admin;
        private readonly UserService _userService;

        public AdminDashboardForm(User admin)
        {
            InitializeComponent();
            _admin = admin;
            _userService = new UserService();
            lblWelcome.Text = $"Welcome, {_admin.FirstName} {_admin.LastName} (Admin)";

            // Populate ComboBoxes with string representations of roles
            comboRoleFilter.Items.AddRange(new[] { "author", "editor", "critic", "designer" });
            comboAddRole.Items.AddRange(new[] { "author", "editor", "critic", "designer" });

            // Populate ComboBoxes with StatusType enum values
            // They will display their string representation by default
            comboAddStatus.DataSource = Enum.GetValues(typeof(StatusType));
            comboStatusFilter.DataSource = Enum.GetValues(typeof(StatusType));

            // Set default selections
            comboRoleFilter.SelectedIndex = -1; // No role filter by default
            comboStatusFilter.SelectedIndex = -1; // No status filter by default (null selection)
            comboAddRole.SelectedIndex = 0; // Default to first role for adding
            comboAddStatus.SelectedIndex = 0; // Default to 'active' for adding

            LoadUsers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            string role = comboRoleFilter.SelectedItem?.ToString();
            // Get selected StatusType? (nullable) from ComboBox
            StatusType? status = (StatusType?)comboStatusFilter.SelectedItem;
            string email = txtEmailFilter.Text.Trim();

            var users = _userService.GetUsers(role, status, email);
            dataGridUsers.DataSource = users;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (comboAddRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role for the new user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboAddStatus.SelectedItem == null) // Should not happen if DataSource is set and has items
            {
                MessageBox.Show("Please select a status for the new user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("First name, last name, email, and password are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var confirm = MessageBox.Show("Подтвердите правильность введённых данных", "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var userToCreate = new User
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text, // Pass plain text password, UserService will hash it
                    Role = comboAddRole.SelectedItem.ToString(),
                    Status = (StatusType)comboAddStatus.SelectedItem // Get StatusType from ComboBox
                };

                int newUserId = _userService.CreateUser(userToCreate);
                AuditService.LogAdminAction(_admin.Email, $"Created user with role {userToCreate.Role}", newUserId);
                MessageBox.Show("Пользователь успешно добавлен.");
                ClearForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single user to edit.");
                return;
            }

            var selectedUser = (User)dataGridUsers.SelectedRows[0].DataBoundItem;

            // Prompt for new values
            string newFirstName = Prompt("Edit First Name:", selectedUser.FirstName);
            string newLastName = Prompt("Edit Last Name:", selectedUser.LastName);

            // For status, it's better to use a ComboBox or specific input dialog
            // For simplicity with Prompt, we parse string to enum
            string currentStatusStr = selectedUser.Status.ToString();
            string newStatusStr = Prompt($"Edit Status (e.g., {string.Join("/", Enum.GetNames(typeof(StatusType)))}):", currentStatusStr);

            if (newFirstName == null || newLastName == null || newStatusStr == null) // User cancelled an input
            {
                MessageBox.Show("Edit cancelled or invalid input provided.");
                return;
            }
            
            StatusType newStatus;
            if (!Enum.TryParse<StatusType>(newStatusStr, true, out newStatus) || !Enum.IsDefined(typeof(StatusType), newStatus) )
            {
                MessageBox.Show($"Invalid status value: '{newStatusStr}'. Please use one of: {string.Join(", ", Enum.GetNames(typeof(StatusType)))}.");
                return;
            }

            // Update the user object
            selectedUser.FirstName = newFirstName;
            selectedUser.LastName = newLastName;
            selectedUser.Status = newStatus;

            try
            {
                _userService.UpdateUser(selectedUser); // Password is not updated by this method
                AuditService.LogAdminAction(_admin.Email, $"Updated user {selectedUser.Email}", selectedUser.Id);
                MessageBox.Show("User updated successfully.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single user to delete.");
                return;
            }

            var selectedUser = (User)dataGridUsers.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show($"Are you sure you want to delete user {selectedUser.Email}?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _userService.DeleteUser(selectedUser);
                AuditService.LogAdminAction(_admin.Email, $"Deleted user {selectedUser.Email}", selectedUser.Id);
                MessageBox.Show("User deleted successfully.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Prompt(string message, string defaultValue)
        {
            // Using Microsoft.VisualBasic.Interaction.InputBox for simplicity as in original code
            // Consider creating a custom dialog for better control and UI consistency
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Edit Field", defaultValue);
        }


        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            comboAddRole.SelectedIndex = 0; // Reset to default
            comboAddStatus.SelectedIndex = 0; // Reset to default (e.g., 'active')
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Consider showing LoginForm after logout instead of just closing
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}