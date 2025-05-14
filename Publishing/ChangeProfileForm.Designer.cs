using System.ComponentModel;

namespace PublishingSystem.UI;

partial class ChangeProfileForm
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
        btnCancel = new System.Windows.Forms.Button();
        btnSave = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        txtFirstName = new System.Windows.Forms.TextBox();
        txtLastName = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // btnCancel
        // 
        btnCancel.Location = new System.Drawing.Point(70, 91);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(81, 25);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // btnSave
        // 
        btnSave.Location = new System.Drawing.Point(157, 91);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(89, 25);
        btnSave.TabIndex = 1;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(30, 24);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(111, 25);
        label1.TabIndex = 2;
        label1.Text = "First Name:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(30, 49);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(111, 25);
        label2.TabIndex = 3;
        label2.Text = "Last Name:";
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new System.Drawing.Point(102, 21);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new System.Drawing.Size(134, 23);
        txtFirstName.TabIndex = 4;
        // 
        // txtLastName
        // 
        txtLastName.Location = new System.Drawing.Point(102, 46);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new System.Drawing.Size(134, 23);
        txtLastName.TabIndex = 5;
        // 
        // ChangeProfileForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(284, 162);
        Controls.Add(txtLastName);
        Controls.Add(txtFirstName);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ChangeProfileForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.TextBox txtLastName;

    #endregion
}