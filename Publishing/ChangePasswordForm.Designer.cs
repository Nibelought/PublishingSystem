using System.ComponentModel;

namespace PublishingSystem.UI;

partial class ChangePasswordForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        txtCurrentPassword = new System.Windows.Forms.TextBox();
        txtConfirmPassword = new System.Windows.Forms.TextBox();
        txtNewPassword = new System.Windows.Forms.TextBox();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(30, 45);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(110, 20);
        label1.TabIndex = 0;
        label1.Text = "Current Password:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(30, 75);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(110, 18);
        label2.TabIndex = 1;
        label2.Text = "New Password:";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(30, 105);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(111, 19);
        label3.TabIndex = 2;
        label3.Text = "Confirm Password:";
        // 
        // txtCurrentPassword
        // 
        txtCurrentPassword.Location = new System.Drawing.Point(146, 42);
        txtCurrentPassword.Name = "txtCurrentPassword";
        txtCurrentPassword.Size = new System.Drawing.Size(132, 23);
        txtCurrentPassword.TabIndex = 3;
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Location = new System.Drawing.Point(146, 102);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Size = new System.Drawing.Size(132, 23);
        txtConfirmPassword.TabIndex = 4;
        // 
        // txtNewPassword
        // 
        txtNewPassword.Location = new System.Drawing.Point(146, 72);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.Size = new System.Drawing.Size(132, 23);
        txtNewPassword.TabIndex = 5;
        // 
        // btnSave
        // 
        btnSave.Location = new System.Drawing.Point(168, 144);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(91, 27);
        btnSave.TabIndex = 6;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.Location = new System.Drawing.Point(71, 144);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(91, 27);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ChangePasswordForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(314, 196);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtNewPassword);
        Controls.Add(txtConfirmPassword);
        Controls.Add(txtCurrentPassword);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Change Password";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    private System.Windows.Forms.TextBox txtCurrentPassword;
    private System.Windows.Forms.TextBox txtConfirmPassword;
    private System.Windows.Forms.TextBox txtNewPassword;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    #endregion
}