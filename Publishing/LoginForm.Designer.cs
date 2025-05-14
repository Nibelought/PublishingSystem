using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Publishing
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtEmail = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            btnLogin = new System.Windows.Forms.Button();
            lblError = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(110, 60);
            txtEmail.MaxLength = 255;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(140, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtPassword.Location = new System.Drawing.Point(110, 100);
            txtPassword.MaxLength = 255;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(140, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnLogin.Location = new System.Drawing.Point(143, 161);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new System.Drawing.Point(142, 25);
            lblError.Name = "lblError";
            lblError.Size = new System.Drawing.Size(79, 15);
            lblError.TabIndex = 3;
            lblError.Text = "Authorization";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(344, 221);
            Controls.Add(lblError);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblError;
    }
}