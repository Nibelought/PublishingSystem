namespace PublishingSystem.UI
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnLogout = new Button();
            SuspendLayout();
            //
            // lblWelcome
            //
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(250, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            //
            // btnLogout
            //
            btnLogout.Location = new Point(20, 60);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += new EventHandler(this.btnLogout_Click);
            //
            // AdminDashboardForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 150);
            Controls.Add(lblWelcome);
            Controls.Add(btnLogout);
            Name = "AdminDashboardForm";
            Text = "Admin Panel";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
