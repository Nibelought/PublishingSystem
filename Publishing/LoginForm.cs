using System;
using System.Windows.Forms;
using PublishingSystem.BLL;
using PublishingSystem.Models;
using PublishingSystem.UI;

namespace Publishing
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            btnLogin.Click += BtnLogin_Click;
            lblError.Text = "Authorization";
            lblError.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            ResetMessage();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter both email and password.");
                return;
            }

            try
            {
                var userService = new UserService();
                User? user = userService.Authenticate(email, password);
                if (user == null)
                {
                    ShowError("Invalid login or password.");
                    return;
                }


                MessageBox.Show($"Welcome, {user.FirstName} {user.LastName} ({user.Role})", "Login Successful");

                Form dashboard = AdminConfig.IsAdmin(user.Email)
                    ? new AdminDashboardForm(user)
                    : new Form { Text = $"Dashboard: {user.Role.ToUpper()}" };

                this.Hide();
                dashboard.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        private void ResetMessage()
        {
            lblError.Text = "Authorization";
            lblError.ForeColor = System.Drawing.SystemColors.ControlText;
        }
    }
}
