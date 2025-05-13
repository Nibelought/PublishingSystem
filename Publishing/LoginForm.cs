using System;
using System.Windows.Forms;
using PublishingSystem.BLL;
using PublishingSystem.Models;
using PublishingSystem.UI; // Нужно для доступа к формам дашбордов

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
                User? user = userService.Authenticate(email, password); // Authenticate теперь проверяет IsActive
                if (user == null)
                {
                    // Либо неверные данные, либо пользователь неактивен
                    ShowError("Invalid login/password or inactive account.");
                    return;
                }

                // --- Логика выбора дашборда ---
                Form dashboard;
                if (AdminConfig.IsAdmin(user.Email))
                {
                     dashboard = new AdminDashboardForm(user);
                }
                else
                {
                    switch (user.Role.ToLower()) // Приводим к нижнему регистру для надежности
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
                             // Неизвестная роль - можно показать сообщение или пустую форму
                             MessageBox.Show($"Unknown user role: {user.Role}. Cannot open dashboard.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             return; // Не продолжаем
                    }
                }
                // --- Конец логики выбора дашборда ---


                this.Hide();
                // Подписываемся на закрытие дашборда, чтобы закрыть и форму логина
                 dashboard.Closed += (s, args) => this.Close();
                 dashboard.Show(); // Используем Show() вместо ShowDialog()

            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
        }

        // ... (ShowError, ResetMessage без изменений) ...
        private void ShowError(string message) { /* ... */ }
        private void ResetMessage() { /* ... */ }
    }
}