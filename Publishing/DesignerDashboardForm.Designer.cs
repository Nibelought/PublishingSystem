using System.ComponentModel;

namespace PublishingSystem.UI;

partial class DesignerDashboardForm
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
        dataGridViewBooksToDesign = new System.Windows.Forms.DataGridView();
        dataGridViewMyDesigns = new System.Windows.Forms.DataGridView();
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        btnAssignDesignToMe = new System.Windows.Forms.Button();
        btnUploadCover = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooksToDesign).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyDesigns).BeginInit();
        SuspendLayout();
        // 
        // dataGridViewBooksToDesign
        // 
        dataGridViewBooksToDesign.Dock = System.Windows.Forms.DockStyle.Left;
        dataGridViewBooksToDesign.Location = new System.Drawing.Point(0, 24);
        dataGridViewBooksToDesign.Name = "dataGridViewBooksToDesign";
        dataGridViewBooksToDesign.Size = new System.Drawing.Size(408, 426);
        dataGridViewBooksToDesign.TabIndex = 0;
        // 
        // dataGridViewMyDesigns
        // 
        dataGridViewMyDesigns.Dock = System.Windows.Forms.DockStyle.Right;
        dataGridViewMyDesigns.Location = new System.Drawing.Point(408, 24);
        dataGridViewMyDesigns.Name = "dataGridViewMyDesigns";
        dataGridViewMyDesigns.Size = new System.Drawing.Size(392, 426);
        dataGridViewMyDesigns.TabIndex = 1;
        // 
        // menuStrip1
        // 
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(800, 24);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        // 
        // btnAssignDesignToMe
        // 
        btnAssignDesignToMe.Location = new System.Drawing.Point(267, 185);
        btnAssignDesignToMe.Name = "btnAssignDesignToMe";
        btnAssignDesignToMe.Size = new System.Drawing.Size(90, 30);
        btnAssignDesignToMe.TabIndex = 3;
        btnAssignDesignToMe.Text = "Assign To Me";
        btnAssignDesignToMe.UseVisualStyleBackColor = true;
        // 
        // btnUploadCover
        // 
        btnUploadCover.Location = new System.Drawing.Point(266, 230);
        btnUploadCover.Name = "btnUploadCover";
        btnUploadCover.Size = new System.Drawing.Size(60, 26);
        btnUploadCover.TabIndex = 4;
        btnUploadCover.Text = "Upload";
        btnUploadCover.UseVisualStyleBackColor = true;
        // 
        // DesignerDashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btnUploadCover);
        Controls.Add(btnAssignDesignToMe);
        Controls.Add(dataGridViewMyDesigns);
        Controls.Add(dataGridViewBooksToDesign);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "DesignerDashboardForm";
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooksToDesign).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyDesigns).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnAssignDesignToMe;
    private System.Windows.Forms.Button btnUploadCover;

    private System.Windows.Forms.MenuStrip menuStrip1;

    private System.Windows.Forms.DataGridView dataGridViewBooksToDesign;
    private System.Windows.Forms.DataGridView dataGridViewMyDesigns;

    #endregion
}