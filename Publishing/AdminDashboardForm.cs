using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

            comboRoleFilter.Items.AddRange(new[] { "author", "editor", "critic", "designer" });
            comboAddRole.Items.AddRange(new[] { "author", "editor", "critic", "designer" });
            comboAddStatus.Items.AddRange(new[] { "active", "inactive" });
            comboStatusFilter.Items.AddRange(new[] { "active", "inactive" });

            comboRoleFilter.SelectedIndex = -1;
            comboStatusFilter.SelectedIndex = -1;
            LoadUsers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            string role = comboRoleFilter.SelectedItem?.ToString();
            string status = comboStatusFilter.SelectedItem?.ToString();
            string email = txtEmailFilter.Text.Trim();

            var users = _userService.GetUsers(role, status, email);
            dataGridUsers.DataSource = users;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Подтвердите правильность введённых данных", "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var dto = new User
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text),
                    Role = comboAddRole.SelectedItem.ToString(),
                    Status = comboAddStatus.SelectedItem.ToString()
                };

                int newUserId = _userService.CreateUser(dto);
                AuditService.LogAdminAction(_admin.Email, $"Created user with role {dto.Role}", newUserId);
                MessageBox.Show("Пользователь успешно добавлен.");
                ClearForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
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

            string newFirstName = Prompt("Edit First Name:", selectedUser.FirstName);
            string newLastName = Prompt("Edit Last Name:", selectedUser.LastName);
            string newStatus = Prompt("Edit Status (active/inactive):", selectedUser.Status);

            selectedUser.FirstName = newFirstName;
            selectedUser.LastName = newLastName;
            selectedUser.Status = newStatus;

            _userService.UpdateUser(selectedUser);
            MessageBox.Show("User updated successfully.");
            LoadUsers();
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

            _userService.DeleteUser(selectedUser);
            MessageBox.Show("User deleted successfully.");
            LoadUsers();
        }

        private string Prompt(string message, string defaultValue)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Edit Field", defaultValue);
        }


        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            comboAddRole.SelectedIndex = -1;
            comboAddStatus.SelectedIndex = -1;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
