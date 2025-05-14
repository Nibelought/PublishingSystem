using System.ComponentModel;

namespace PublishingSystem.UI;

partial class CriticDashboardForm
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
        comboBooks = new System.Windows.Forms.ComboBox();
        richTextBoxReview = new System.Windows.Forms.RichTextBox();
        btnBold = new System.Windows.Forms.Button();
        btnItalic = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        numericGradeBook = new System.Windows.Forms.NumericUpDown();
        numericGradeCover = new System.Windows.Forms.NumericUpDown();
        btnSubmitReview = new System.Windows.Forms.Button();
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)numericGradeBook).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericGradeCover).BeginInit();
        SuspendLayout();
        // 
        // comboBooks
        // 
        comboBooks.FormattingEnabled = true;
        comboBooks.Location = new System.Drawing.Point(12, 58);
        comboBooks.Name = "comboBooks";
        comboBooks.Size = new System.Drawing.Size(217, 23);
        comboBooks.TabIndex = 0;
        // 
        // richTextBoxReview
        // 
        richTextBoxReview.Location = new System.Drawing.Point(12, 184);
        richTextBoxReview.Name = "richTextBoxReview";
        richTextBoxReview.Size = new System.Drawing.Size(217, 149);
        richTextBoxReview.TabIndex = 1;
        richTextBoxReview.Text = "";
        // 
        // btnBold
        // 
        btnBold.Location = new System.Drawing.Point(12, 153);
        btnBold.Name = "btnBold";
        btnBold.Size = new System.Drawing.Size(61, 25);
        btnBold.TabIndex = 2;
        btnBold.Text = "Bold";
        btnBold.UseVisualStyleBackColor = true;
        // 
        // btnItalic
        // 
        btnItalic.Location = new System.Drawing.Point(79, 154);
        btnItalic.Name = "btnItalic";
        btnItalic.Size = new System.Drawing.Size(56, 24);
        btnItalic.TabIndex = 3;
        btnItalic.Text = "Italic";
        btnItalic.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 91);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(82, 18);
        label1.TabIndex = 4;
        label1.Text = "Book Grade:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 127);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(84, 15);
        label2.TabIndex = 5;
        label2.Text = "Cover Grade:";
        // 
        // numericGradeBook
        // 
        numericGradeBook.Location = new System.Drawing.Point(100, 89);
        numericGradeBook.Name = "numericGradeBook";
        numericGradeBook.Size = new System.Drawing.Size(40, 23);
        numericGradeBook.TabIndex = 6;
        // 
        // numericGradeCover
        // 
        numericGradeCover.Location = new System.Drawing.Point(100, 125);
        numericGradeCover.Name = "numericGradeCover";
        numericGradeCover.Size = new System.Drawing.Size(40, 23);
        numericGradeCover.TabIndex = 7;
        // 
        // btnSubmitReview
        // 
        btnSubmitReview.Location = new System.Drawing.Point(121, 339);
        btnSubmitReview.Name = "btnSubmitReview";
        btnSubmitReview.Size = new System.Drawing.Size(108, 24);
        btnSubmitReview.TabIndex = 8;
        btnSubmitReview.Text = "Submit";
        btnSubmitReview.UseVisualStyleBackColor = true;
        // 
        // menuStrip1
        // 
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(241, 24);
        menuStrip1.TabIndex = 9;
        menuStrip1.Text = "menuStrip1";
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
        // 
        // CriticDashboardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(241, 379);
        Controls.Add(btnSubmitReview);
        Controls.Add(numericGradeCover);
        Controls.Add(numericGradeBook);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnItalic);
        Controls.Add(btnBold);
        Controls.Add(richTextBoxReview);
        Controls.Add(comboBooks);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "CriticDashboardForm";
        ((System.ComponentModel.ISupportInitialize)numericGradeBook).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericGradeCover).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    private System.Windows.Forms.MenuStrip menuStrip1;

    private System.Windows.Forms.Button btnSubmitReview;

    private System.Windows.Forms.NumericUpDown numericGradeBook;
    private System.Windows.Forms.NumericUpDown numericGradeCover;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button btnBold;
    private System.Windows.Forms.Button btnItalic;

    private System.Windows.Forms.ComboBox comboBooks;
    private System.Windows.Forms.RichTextBox richTextBoxReview;

    #endregion
}