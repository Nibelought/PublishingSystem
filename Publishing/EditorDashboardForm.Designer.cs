using System.ComponentModel;

namespace PublishingSystem.UI;

partial class EditorDashboardForm
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
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        dataGridViewBooksToEdit = new System.Windows.Forms.DataGridView();
        dataGridViewMyBooks = new System.Windows.Forms.DataGridView();
        btnAssignToMe = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooksToEdit).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyBooks).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(800, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(0, 24);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(btnAssignToMe);
        splitContainer1.Panel1.Controls.Add(label1);
        splitContainer1.Panel1.Controls.Add(dataGridViewBooksToEdit);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(label2);
        splitContainer1.Panel2.Controls.Add(dataGridViewMyBooks);
        splitContainer1.Size = new System.Drawing.Size(800, 426);
        splitContainer1.SplitterDistance = 346;
        splitContainer1.TabIndex = 1;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(91, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(156, 17);
        label1.TabIndex = 0;
        label1.Text = "Books Available for Editing";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(167, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(112, 19);
        label2.TabIndex = 0;
        label2.Text = "My Assigned Books";
        // 
        // dataGridViewBooksToEdit
        // 
        dataGridViewBooksToEdit.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewBooksToEdit.Location = new System.Drawing.Point(0, 0);
        dataGridViewBooksToEdit.Name = "dataGridViewBooksToEdit";
        dataGridViewBooksToEdit.Size = new System.Drawing.Size(346, 426);
        dataGridViewBooksToEdit.TabIndex = 1;
        // 
        // dataGridViewMyBooks
        // 
        dataGridViewMyBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewMyBooks.Location = new System.Drawing.Point(0, 0);
        dataGridViewMyBooks.Name = "dataGridViewMyBooks";
        dataGridViewMyBooks.Size = new System.Drawing.Size(450, 426);
        dataGridViewMyBooks.TabIndex = 1;
        // 
        // btnAssignToMe
        // 
        btnAssignToMe.Location = new System.Drawing.Point(91, 391);
        btnAssignToMe.Name = "btnAssignToMe";
        btnAssignToMe.Size = new System.Drawing.Size(153, 23);
        btnAssignToMe.TabIndex = 2;
        btnAssignToMe.Text = "Assign To me";
        btnAssignToMe.UseVisualStyleBackColor = true;
        // 
        // EditorDashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Text = "EditorDashboardForm";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooksToEdit).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyBooks).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnAssignToMe;

    private System.Windows.Forms.DataGridView dataGridViewMyBooks;

    private System.Windows.Forms.DataGridView dataGridViewBooksToEdit;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.SplitContainer splitContainer1;

    private System.Windows.Forms.MenuStrip menuStrip1;

    #endregion
}