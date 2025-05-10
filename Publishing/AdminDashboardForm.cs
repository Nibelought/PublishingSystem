using System;
using System.Windows.Forms;
using PublishingSystem.Models;

namespace PublishingSystem.UI
{
    public partial class AdminDashboardForm : Form
    {
        private readonly User _admin;

        public AdminDashboardForm(User admin)
        {
            InitializeComponent();
            _admin = admin;
            lblWelcome.Text = $"Welcome, {_admin.FirstName} {_admin.LastName} (Admin)";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // вернёт к LoginForm
        }
    }
}