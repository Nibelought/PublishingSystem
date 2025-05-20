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
        dataGridViewAvailableBooks = new System.Windows.Forms.DataGridView();
        dataGridViewMyAssignedBooks = new System.Windows.Forms.DataGridView();
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        btnAssignToMe = new System.Windows.Forms.Button();
        panelCoverUpload = new System.Windows.Forms.Panel();
        pictureBoxCoverPreview = new System.Windows.Forms.PictureBox();
        btnSaveCover = new System.Windows.Forms.Button();
        btnClearCoverSelection = new System.Windows.Forms.Button();
        lblCurrentCoverPath = new System.Windows.Forms.Label();
        btnBrowseCover = new System.Windows.Forms.Button();
        lblDragDropInfo = new System.Windows.Forms.Label();
        btnReleaseBookFromDesigner = new System.Windows.Forms.Button();
        tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
        lblAvailableBooksDesign = new System.Windows.Forms.Label();
        tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
        lblMyAssignedBooksDesign = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableBooks).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyAssignedBooks).BeginInit();
        panelCoverUpload.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxCoverPreview).BeginInit();
        tableLayoutPanelMain.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridViewAvailableBooks
        // 
        dataGridViewAvailableBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewAvailableBooks.Location = new System.Drawing.Point(3, 21);
        dataGridViewAvailableBooks.Name = "dataGridViewAvailableBooks";
        dataGridViewAvailableBooks.Size = new System.Drawing.Size(508, 484);
        dataGridViewAvailableBooks.TabIndex = 0;
        // 
        // dataGridViewMyAssignedBooks
        // 
        dataGridViewMyAssignedBooks.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridViewMyAssignedBooks.Location = new System.Drawing.Point(3, 19);
        dataGridViewMyAssignedBooks.Name = "dataGridViewMyAssignedBooks";
        dataGridViewMyAssignedBooks.Size = new System.Drawing.Size(654, 275);
        dataGridViewMyAssignedBooks.TabIndex = 1;
        // 
        // menuStrip1
        // 
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(1184, 24);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        // 
        // btnAssignToMe
        // 
        btnAssignToMe.Dock = System.Windows.Forms.DockStyle.Bottom;
        btnAssignToMe.Location = new System.Drawing.Point(0, 478);
        btnAssignToMe.Name = "btnAssignToMe";
        btnAssignToMe.Size = new System.Drawing.Size(514, 30);
        btnAssignToMe.TabIndex = 3;
        btnAssignToMe.Text = "Assign To Me";
        btnAssignToMe.UseVisualStyleBackColor = true;
        // 
        // panelCoverUpload
        // 
        panelCoverUpload.Controls.Add(pictureBoxCoverPreview);
        panelCoverUpload.Controls.Add(btnSaveCover);
        panelCoverUpload.Controls.Add(btnClearCoverSelection);
        panelCoverUpload.Controls.Add(lblCurrentCoverPath);
        panelCoverUpload.Controls.Add(btnBrowseCover);
        panelCoverUpload.Controls.Add(lblDragDropInfo);
        panelCoverUpload.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelCoverUpload.Location = new System.Drawing.Point(0, 297);
        panelCoverUpload.Name = "panelCoverUpload";
        panelCoverUpload.Size = new System.Drawing.Size(660, 211);
        panelCoverUpload.TabIndex = 5;
        // 
        // pictureBoxCoverPreview
        // 
        pictureBoxCoverPreview.Location = new System.Drawing.Point(243, 3);
        pictureBoxCoverPreview.Name = "pictureBoxCoverPreview";
        pictureBoxCoverPreview.Size = new System.Drawing.Size(414, 205);
        pictureBoxCoverPreview.TabIndex = 2;
        pictureBoxCoverPreview.TabStop = false;
        // 
        // btnSaveCover
        // 
        btnSaveCover.Location = new System.Drawing.Point(110, 177);
        btnSaveCover.Name = "btnSaveCover";
        btnSaveCover.Size = new System.Drawing.Size(128, 25);
        btnSaveCover.TabIndex = 5;
        btnSaveCover.Text = "Save";
        btnSaveCover.UseVisualStyleBackColor = true;
        // 
        // btnClearCoverSelection
        // 
        btnClearCoverSelection.Location = new System.Drawing.Point(2, 177);
        btnClearCoverSelection.Name = "btnClearCoverSelection";
        btnClearCoverSelection.Size = new System.Drawing.Size(108, 25);
        btnClearCoverSelection.TabIndex = 4;
        btnClearCoverSelection.Text = "Clear";
        btnClearCoverSelection.UseVisualStyleBackColor = true;
        // 
        // lblCurrentCoverPath
        // 
        lblCurrentCoverPath.Location = new System.Drawing.Point(3, 87);
        lblCurrentCoverPath.Name = "lblCurrentCoverPath";
        lblCurrentCoverPath.Size = new System.Drawing.Size(171, 16);
        lblCurrentCoverPath.TabIndex = 3;
        lblCurrentCoverPath.Text = "Current path";
        // 
        // btnBrowseCover
        // 
        btnBrowseCover.Location = new System.Drawing.Point(110, 1);
        btnBrowseCover.Name = "btnBrowseCover";
        btnBrowseCover.Size = new System.Drawing.Size(64, 29);
        btnBrowseCover.TabIndex = 1;
        btnBrowseCover.Text = "Browse...";
        btnBrowseCover.UseVisualStyleBackColor = false;
        // 
        // lblDragDropInfo
        // 
        lblDragDropInfo.Location = new System.Drawing.Point(2, 8);
        lblDragDropInfo.Name = "lblDragDropInfo";
        lblDragDropInfo.Size = new System.Drawing.Size(110, 27);
        lblDragDropInfo.TabIndex = 0;
        lblDragDropInfo.Text = "Drag & Drop image here or";
        lblDragDropInfo.UseMnemonic = false;
        // 
        // btnReleaseBookFromDesigner
        // 
        btnReleaseBookFromDesigner.Location = new System.Drawing.Point(458, 504);
        btnReleaseBookFromDesigner.Name = "btnReleaseBookFromDesigner";
        btnReleaseBookFromDesigner.Size = new System.Drawing.Size(70, 25);
        btnReleaseBookFromDesigner.TabIndex = 6;
        btnReleaseBookFromDesigner.Text = "Realese";
        btnReleaseBookFromDesigner.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 1;
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.Controls.Add(splitContainer1, 0, 1);
        tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 2;
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.283054F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.71695F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(1184, 537);
        tableLayoutPanelMain.TabIndex = 7;
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(3, 26);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(btnAssignToMe);
        splitContainer1.Panel1.Controls.Add(tableLayoutPanel2);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(tableLayoutPanel3);
        splitContainer1.Panel2.Controls.Add(panelCoverUpload);
        splitContainer1.Size = new System.Drawing.Size(1178, 508);
        splitContainer1.SplitterDistance = 514;
        splitContainer1.TabIndex = 8;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 1;
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel2.Controls.Add(lblAvailableBooksDesign, 0, 0);
        tableLayoutPanel2.Controls.Add(dataGridViewAvailableBooks, 0, 1);
        tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 2;
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel2.Size = new System.Drawing.Size(514, 508);
        tableLayoutPanel2.TabIndex = 0;
        // 
        // lblAvailableBooksDesign
        // 
        lblAvailableBooksDesign.Dock = System.Windows.Forms.DockStyle.Fill;
        lblAvailableBooksDesign.Location = new System.Drawing.Point(3, 0);
        lblAvailableBooksDesign.Name = "lblAvailableBooksDesign";
        lblAvailableBooksDesign.Size = new System.Drawing.Size(508, 18);
        lblAvailableBooksDesign.TabIndex = 0;
        lblAvailableBooksDesign.Text = "Avalible Books";
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.ColumnCount = 1;
        tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel3.Controls.Add(lblMyAssignedBooksDesign, 0, 0);
        tableLayoutPanel3.Controls.Add(dataGridViewMyAssignedBooks, 0, 1);
        tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 2;
        tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel3.Size = new System.Drawing.Size(660, 297);
        tableLayoutPanel3.TabIndex = 0;
        // 
        // lblMyAssignedBooksDesign
        // 
        lblMyAssignedBooksDesign.Dock = System.Windows.Forms.DockStyle.Fill;
        lblMyAssignedBooksDesign.Location = new System.Drawing.Point(3, 0);
        lblMyAssignedBooksDesign.Name = "lblMyAssignedBooksDesign";
        lblMyAssignedBooksDesign.Size = new System.Drawing.Size(654, 16);
        lblMyAssignedBooksDesign.TabIndex = 0;
        lblMyAssignedBooksDesign.Text = "My Assigned Books";
        // 
        // DesignerDashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1184, 561);
        Controls.Add(tableLayoutPanelMain);
        Controls.Add(btnReleaseBookFromDesigner);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Designer Dashboard";
        ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableBooks).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewMyAssignedBooks).EndInit();
        panelCoverUpload.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxCoverPreview).EndInit();
        tableLayoutPanelMain.ResumeLayout(false);
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel3.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblMyAssignedBooksDesign;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

    private System.Windows.Forms.Label lblAvailableBooksDesign;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

    private System.Windows.Forms.SplitContainer splitContainer1;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;

    private System.Windows.Forms.Button btnReleaseBookFromDesigner;

    private System.Windows.Forms.Button btnClearCoverSelection;
    private System.Windows.Forms.Button btnSaveCover;

    private System.Windows.Forms.Label lblCurrentCoverPath;

    private System.Windows.Forms.PictureBox pictureBoxCoverPreview;

    private System.Windows.Forms.Button btnBrowseCover;

    private System.Windows.Forms.Label lblDragDropInfo;

    private System.Windows.Forms.Panel panelCoverUpload;

    private System.Windows.Forms.Button btnAssignToMe;

    private System.Windows.Forms.MenuStrip menuStrip1;

    private System.Windows.Forms.DataGridView dataGridViewAvailableBooks;
    private System.Windows.Forms.DataGridView dataGridViewMyAssignedBooks;

    #endregion
}