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
                User? user = userService.Authenticate(email, password); // Authenticate now checks IsActive
                if (user == null)
                {
                    // Or incorrect data, or user inactive
                    ShowError("Invalid login/password or inactive account.");
                    return;
                }

                // --- Logic choice dashboard ---
                Form dashboard;
                if (AdminConfig.IsAdmin(user.Email))
                {
                     dashboard = new AdminDashboardForm(user);
                }
                else
                {
                    switch (user.Role.ToLower()) // Convert to lower case for reliability
                    {
                        case "author":
                            dashboard = new AuthorDashboardForm(user);
                            break;
                        case "editor":
                             dashboard = new EditorDashboardForm(user);
                             break;
                        case "designer":
                             dashboard = new DesignerDashboardForm(user);
                             break;
                        case "critic":
                             dashboard = new CriticDashboardForm(user);
                             break;
                        default:
                             // Unknown role - can show message or blank form
                             MessageBox.Show($"Unknown user role: {user.Role}. Cannot open dashboard.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             return; // Not continue
                    }
                }
                // --- End of logic choice dashboard ---


                this.Hide();
                // subscribe on closing dashboard, for close and login form
                 dashboard.Closed += (s, args) => this.Close();
                 dashboard.Show(); // Use Show() instead of ShowDialog()

            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        // ... (ShowError, ResetMessage w/o change) ...
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        private void ResetMessage()
        {
            lblError.Text = "Authorization"; // Default text
            lblError.ForeColor = System.Drawing.SystemColors.ControlText; // Default color
        }
    }
}