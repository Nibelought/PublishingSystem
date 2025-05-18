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
        splitContainerBooks = new System.Windows.Forms.SplitContainer();
        btnAssignToMe = new System.Windows.Forms.Button();
        dataGridViewAvailableBooks = new System.Windows.Forms.DataGridView();
        btnReleaseBook = new System.Windows.Forms.Button();
        btnChangeAgeRestriction = new System.Windows.Forms.Button();
        btnSetStatusEditing = new System.Windows.Forms.Button();
        dataGridViewMyBooks = new System.Windows.Forms.DataGridView();
        tlpAvailableBooks = new System.Windows.Forms.TableLayoutPanel();
        tlpMyBooks = new System.Windows.Forms.TableLayoutPanel();
        lblMyBooks = new System.Windows.Forms.Label();
        lblAvailableBooks = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)splitContainerBooks).BeginInit();
        splitContainerBooks.Panel1.SuspendLayout();
        splitContainerBooks.Panel2.SuspendLayout();
        splitContainerBooks.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableBooks).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyBooks).BeginInit();
        tlpAvailableBooks.SuspendLayout();
        tlpMyBooks.SuspendLayout();
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
        // splitContainerBooks
        // 
        splitContainerBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainerBooks.Location = new System.Drawing.Point(0, 24);
        splitContainerBooks.Name = "splitContainerBooks";
        // 
        // splitContainerBooks.Panel1
        // 
        splitContainerBooks.Panel1.Controls.Add(btnAssignToMe);
        splitContainerBooks.Panel1.Controls.Add(tlpAvailableBooks);
        // 
        // splitContainerBooks.Panel2
        // 
        splitContainerBooks.Panel2.Controls.Add(btnReleaseBook);
        splitContainerBooks.Panel2.Controls.Add(btnChangeAgeRestriction);
        splitContainerBooks.Panel2.Controls.Add(btnSetStatusEditing);
        splitContainerBooks.Panel2.Controls.Add(tlpMyBooks);
        splitContainerBooks.Size = new System.Drawing.Size(800, 426);
        splitContainerBooks.SplitterDistance = 346;
        splitContainerBooks.TabIndex = 1;
        // 
        // btnAssignToMe
        // 
        btnAssignToMe.Dock = System.Windows.Forms.DockStyle.Bottom;
        btnAssignToMe.Location = new System.Drawing.Point(0, 403);
        btnAssignToMe.Name = "btnAssignToMe";
        btnAssignToMe.Size = new System.Drawing.Size(346, 23);
        btnAssignToMe.TabIndex = 2;
        btnAssignToMe.Text = "Assign To me";
        btnAssignToMe.UseVisualStyleBackColor = true;
        // 
        // dataGridViewAvailableBooks
        // 
        dataGridViewAvailableBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewAvailableBooks.Location = new System.Drawing.Point(3, 20);
        dataGridViewAvailableBooks.Name = "dataGridViewAvailableBooks";
        dataGridViewAvailableBooks.Size = new System.Drawing.Size(340, 403);
        dataGridViewAvailableBooks.TabIndex = 1;
        // 
        // btnReleaseBook
        // 
        btnReleaseBook.Dock = System.Windows.Forms.DockStyle.Bottom;
        btnReleaseBook.Location = new System.Drawing.Point(0, 357);
        btnReleaseBook.Name = "btnReleaseBook";
        btnReleaseBook.Size = new System.Drawing.Size(450, 23);
        btnReleaseBook.TabIndex = 4;
        btnReleaseBook.Text = "Realese";
        btnReleaseBook.UseVisualStyleBackColor = true;
        // 
        // btnChangeAgeRestriction
        // 
        btnChangeAgeRestriction.Dock = System.Windows.Forms.DockStyle.Bottom;
        btnChangeAgeRestriction.Location = new System.Drawing.Point(0, 380);
        btnChangeAgeRestriction.Name = "btnChangeAgeRestriction";
        btnChangeAgeRestriction.Size = new System.Drawing.Size(450, 23);
        btnChangeAgeRestriction.TabIndex = 3;
        btnChangeAgeRestriction.Text = "Change Age Restriction";
        btnChangeAgeRestriction.UseVisualStyleBackColor = true;
        // 
        // btnSetStatusEditing
        // 
        btnSetStatusEditing.Dock = System.Windows.Forms.DockStyle.Bottom;
        btnSetStatusEditing.Location = new System.Drawing.Point(0, 403);
        btnSetStatusEditing.Name = "btnSetStatusEditing";
        btnSetStatusEditing.Size = new System.Drawing.Size(450, 23);
        btnSetStatusEditing.TabIndex = 2;
        btnSetStatusEditing.Text = "Set Editing";
        btnSetStatusEditing.UseVisualStyleBackColor = true;
        // 
        // dataGridViewMyBooks
        // 
        dataGridViewMyBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewMyBooks.Location = new System.Drawing.Point(3, 22);
        dataGridViewMyBooks.Name = "dataGridViewMyBooks";
        dataGridViewMyBooks.Size = new System.Drawing.Size(444, 401);
        dataGridViewMyBooks.TabIndex = 1;
        // 
        // tlpAvailableBooks
        // 
        tlpAvailableBooks.AutoSize = true;
        tlpAvailableBooks.ColumnCount = 1;
        tlpAvailableBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tlpAvailableBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tlpAvailableBooks.Controls.Add(lblAvailableBooks, 0, 0);
        tlpAvailableBooks.Controls.Add(dataGridViewAvailableBooks, 0, 1);
        tlpAvailableBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpAvailableBooks.Location = new System.Drawing.Point(0, 0);
        tlpAvailableBooks.Name = "tlpAvailableBooks";
        tlpAvailableBooks.RowCount = 2;
        tlpAvailableBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpAvailableBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpAvailableBooks.Size = new System.Drawing.Size(346, 426);
        tlpAvailableBooks.TabIndex = 6;
        // 
        // tlpMyBooks
        // 
        tlpMyBooks.ColumnCount = 1;
        tlpMyBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tlpMyBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tlpMyBooks.Controls.Add(dataGridViewMyBooks, 0, 1);
        tlpMyBooks.Controls.Add(lblMyBooks, 0, 0);
        tlpMyBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        tlpMyBooks.Location = new System.Drawing.Point(0, 0);
        tlpMyBooks.Name = "tlpMyBooks";
        tlpMyBooks.RowCount = 2;
        tlpMyBooks.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tlpMyBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tlpMyBooks.Size = new System.Drawing.Size(450, 426);
        tlpMyBooks.TabIndex = 5;
        // 
        // lblMyBooks
        // 
        lblMyBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        lblMyBooks.Location = new System.Drawing.Point(3, 0);
        lblMyBooks.Name = "lblMyBooks";
        lblMyBooks.Size = new System.Drawing.Size(444, 19);
        lblMyBooks.TabIndex = 6;
        lblMyBooks.Text = "My Assigned Books";
        // 
        // lblAvailableBooks
        // 
        lblAvailableBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        lblAvailableBooks.Location = new System.Drawing.Point(3, 0);
        lblAvailableBooks.Name = "lblAvailableBooks";
        lblAvailableBooks.Size = new System.Drawing.Size(340, 17);
        lblAvailableBooks.TabIndex = 7;
        lblAvailableBooks.Text = "Available Books for Editing";
        // 
        // EditorDashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(splitContainerBooks);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "EditorDashboardForm";
        splitContainerBooks.Panel1.ResumeLayout(false);
        splitContainerBooks.Panel1.PerformLayout();
        splitContainerBooks.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainerBooks).EndInit();
        splitContainerBooks.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableBooks).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyBooks).EndInit();
        tlpAvailableBooks.ResumeLayout(false);
        tlpMyBooks.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblMyBooks;
    private System.Windows.Forms.Label lblAvailableBooks;

    private System.Windows.Forms.TableLayoutPanel tlpMyBooks;

    private System.Windows.Forms.TableLayoutPanel tlpAvailableBooks;

    private System.Windows.Forms.Button btnReleaseBook;

    private System.Windows.Forms.Button btnChangeAgeRestriction;

    private System.Windows.Forms.Button btnSetStatusEditing;

    private System.Windows.Forms.Button btnAssignToMe;

    private System.Windows.Forms.DataGridView dataGridViewMyBooks;

    private System.Windows.Forms.DataGridView dataGridViewAvailableBooks;

    private System.Windows.Forms.SplitContainer splitContainerBooks;

    private System.Windows.Forms.MenuStrip menuStrip1;

    #endregion
}