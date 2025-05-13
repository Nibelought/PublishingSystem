using System.ComponentModel;

namespace PublishingSystem.UI;

partial class AuthorDashboardForm
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
        dataGridViewBooks = new System.Windows.Forms.DataGridView();
        btnAddBook = new System.Windows.Forms.Button();
        btnEditBook = new System.Windows.Forms.Button();
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
        SuspendLayout();
        // 
        // dataGridViewBooks
        // 
        dataGridViewBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewBooks.Location = new System.Drawing.Point(0, 0);
        dataGridViewBooks.Name = "dataGridViewBooks";
        dataGridViewBooks.Size = new System.Drawing.Size(800, 450);
        dataGridViewBooks.TabIndex = 0;
        // 
        // btnAddBook
        // 
        btnAddBook.Enabled = false;
        btnAddBook.Location = new System.Drawing.Point(99, 88);
        btnAddBook.Name = "btnAddBook";
        btnAddBook.Size = new System.Drawing.Size(92, 26);
        btnAddBook.TabIndex = 1;
        btnAddBook.Text = "Add Book";
        btnAddBook.UseVisualStyleBackColor = true;
        // 
        // btnEditBook
        // 
        btnEditBook.Enabled = false;
        btnEditBook.Location = new System.Drawing.Point(206, 88);
        btnEditBook.Name = "btnEditBook";
        btnEditBook.Size = new System.Drawing.Size(92, 26);
        btnEditBook.TabIndex = 2;
        btnEditBook.Text = "Edit Book";
        btnEditBook.UseVisualStyleBackColor = true;
        // 
        // menuStrip1
        // 
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(800, 24);
        menuStrip1.TabIndex = 5;
        menuStrip1.Text = "menuStrip1";
        // 
        // AuthorDashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btnEditBook);
        Controls.Add(btnAddBook);
        Controls.Add(menuStrip1);
        Controls.Add(dataGridViewBooks);
        MainMenuStrip = menuStrip1;
        Text = "AuthorDashboardForm";
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DataGridView dataGridViewBooks;

    private System.Windows.Forms.MenuStrip menuStrip1;

    private System.Windows.Forms.Button btnEditBook;

    private System.Windows.Forms.Button btnAddBook;

    #endregion
}