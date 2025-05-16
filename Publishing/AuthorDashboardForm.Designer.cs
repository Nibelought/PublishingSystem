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
        btnEditBook = new System.Windows.Forms.Button();
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        panelAddBook = new System.Windows.Forms.Panel();
        lblEstimatedEndDate = new System.Windows.Forms.Label();
        lblAgeRestriction = new System.Windows.Forms.Label();
        lblBookName = new System.Windows.Forms.Label();
        btnCancelAddBook = new System.Windows.Forms.Button();
        btnSaveNewBook = new System.Windows.Forms.Button();
        comboAgeRestrictionAdd = new System.Windows.Forms.ComboBox();
        dtpEstimatedEndDate = new System.Windows.Forms.DateTimePicker();
        txtBookName = new System.Windows.Forms.TextBox();
        btnShowAddBookPanel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
        panelAddBook.SuspendLayout();
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
        // btnEditBook
        // 
        btnEditBook.Enabled = false;
        btnEditBook.Location = new System.Drawing.Point(12, 364);
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
        // panelAddBook
        // 
        panelAddBook.Controls.Add(lblEstimatedEndDate);
        panelAddBook.Controls.Add(lblAgeRestriction);
        panelAddBook.Controls.Add(lblBookName);
        panelAddBook.Controls.Add(btnCancelAddBook);
        panelAddBook.Controls.Add(btnSaveNewBook);
        panelAddBook.Controls.Add(comboAgeRestrictionAdd);
        panelAddBook.Controls.Add(dtpEstimatedEndDate);
        panelAddBook.Controls.Add(txtBookName);
        panelAddBook.Dock = System.Windows.Forms.DockStyle.Right;
        panelAddBook.Location = new System.Drawing.Point(556, 24);
        panelAddBook.Name = "panelAddBook";
        panelAddBook.Size = new System.Drawing.Size(244, 426);
        panelAddBook.TabIndex = 6;
        // 
        // lblEstimatedEndDate
        // 
        lblEstimatedEndDate.Location = new System.Drawing.Point(28, 75);
        lblEstimatedEndDate.Name = "lblEstimatedEndDate";
        lblEstimatedEndDate.Size = new System.Drawing.Size(147, 15);
        lblEstimatedEndDate.TabIndex = 9;
        lblEstimatedEndDate.Text = "Estimated end date";
        // 
        // lblAgeRestriction
        // 
        lblAgeRestriction.Location = new System.Drawing.Point(92, 125);
        lblAgeRestriction.Name = "lblAgeRestriction";
        lblAgeRestriction.Size = new System.Drawing.Size(92, 17);
        lblAgeRestriction.TabIndex = 8;
        lblAgeRestriction.Text = "Age Restriction";
        // 
        // lblBookName
        // 
        lblBookName.Location = new System.Drawing.Point(28, 21);
        lblBookName.Name = "lblBookName";
        lblBookName.Size = new System.Drawing.Size(74, 17);
        lblBookName.TabIndex = 7;
        lblBookName.Text = "Book Name";
        // 
        // btnCancelAddBook
        // 
        btnCancelAddBook.Location = new System.Drawing.Point(13, 388);
        btnCancelAddBook.Name = "btnCancelAddBook";
        btnCancelAddBook.Size = new System.Drawing.Size(107, 23);
        btnCancelAddBook.TabIndex = 6;
        btnCancelAddBook.Text = "Cancel Add Book";
        btnCancelAddBook.UseVisualStyleBackColor = true;
        // 
        // btnSaveNewBook
        // 
        btnSaveNewBook.Location = new System.Drawing.Point(126, 388);
        btnSaveNewBook.Name = "btnSaveNewBook";
        btnSaveNewBook.Size = new System.Drawing.Size(106, 26);
        btnSaveNewBook.TabIndex = 5;
        btnSaveNewBook.Text = "Save New Book";
        btnSaveNewBook.UseVisualStyleBackColor = true;
        // 
        // comboAgeRestrictionAdd
        // 
        comboAgeRestrictionAdd.FormattingEnabled = true;
        comboAgeRestrictionAdd.Location = new System.Drawing.Point(28, 122);
        comboAgeRestrictionAdd.Name = "comboAgeRestrictionAdd";
        comboAgeRestrictionAdd.Size = new System.Drawing.Size(58, 23);
        comboAgeRestrictionAdd.TabIndex = 4;
        // 
        // dtpEstimatedEndDate
        // 
        dtpEstimatedEndDate.Location = new System.Drawing.Point(28, 93);
        dtpEstimatedEndDate.Name = "dtpEstimatedEndDate";
        dtpEstimatedEndDate.Size = new System.Drawing.Size(147, 23);
        dtpEstimatedEndDate.TabIndex = 3;
        // 
        // txtBookName
        // 
        txtBookName.Location = new System.Drawing.Point(28, 41);
        txtBookName.Name = "txtBookName";
        txtBookName.Size = new System.Drawing.Size(190, 23);
        txtBookName.TabIndex = 2;
        // 
        // btnShowAddBookPanel
        // 
        btnShowAddBookPanel.Location = new System.Drawing.Point(12, 396);
        btnShowAddBookPanel.Name = "btnShowAddBookPanel";
        btnShowAddBookPanel.Size = new System.Drawing.Size(92, 42);
        btnShowAddBookPanel.TabIndex = 7;
        btnShowAddBookPanel.Text = "Show Add Book Panel";
        btnShowAddBookPanel.UseVisualStyleBackColor = true;
        // 
        // AuthorDashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btnShowAddBookPanel);
        Controls.Add(panelAddBook);
        Controls.Add(btnEditBook);
        Controls.Add(menuStrip1);
        Controls.Add(dataGridViewBooks);
        MainMenuStrip = menuStrip1;
        Text = "AuthorDashboardForm";
        ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
        panelAddBook.ResumeLayout(false);
        panelAddBook.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnShowAddBookPanel;

    private System.Windows.Forms.Label lblEstimatedEndDate;

    private System.Windows.Forms.Label lblBookName;
    private System.Windows.Forms.Label lblAgeRestriction;

    private System.Windows.Forms.Button btnSaveNewBook;

    private System.Windows.Forms.Button btnCancelAddBook;

    private System.Windows.Forms.ComboBox comboAgeRestrictionAdd;

    private System.Windows.Forms.DateTimePicker dtpEstimatedEndDate;

    private System.Windows.Forms.TextBox txtBookName;

    private System.Windows.Forms.Panel panelAddBook;

    private System.Windows.Forms.DataGridView dataGridViewBooks;

    private System.Windows.Forms.MenuStrip menuStrip1;

    private System.Windows.Forms.Button btnEditBook;

    #endregion
}