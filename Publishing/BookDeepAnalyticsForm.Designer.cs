using System.ComponentModel;

namespace PublishingSystem.UI;

partial class BookDeepAnalyticsForm
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
        lblTitleHeader = new System.Windows.Forms.Label();
        lblStateHeader = new System.Windows.Forms.Label();
        lblAuthorHeader = new System.Windows.Forms.Label();
        lblEditorHeader = new System.Windows.Forms.Label();
        lblDesignerHeader = new System.Windows.Forms.Label();
        lblDesignerValue = new System.Windows.Forms.Label();
        lblEditorValue = new System.Windows.Forms.Label();
        lblAuthorValue = new System.Windows.Forms.Label();
        lblStateValue = new System.Windows.Forms.Label();
        lblTitleValue = new System.Windows.Forms.Label();
        lblCoverPathHeader = new System.Windows.Forms.Label();
        lblAgeRestrictionHeader = new System.Windows.Forms.Label();
        lblPublishDateHeader = new System.Windows.Forms.Label();
        lblEstEndDateHeader = new System.Windows.Forms.Label();
        lblStartDateHeader = new System.Windows.Forms.Label();
        lblCoverPathValue = new System.Windows.Forms.Label();
        lblAgeRestrictionValue = new System.Windows.Forms.Label();
        lblPublishDateValue = new System.Windows.Forms.Label();
        lblEstEndDateValue = new System.Windows.Forms.Label();
        lblStartDateValue = new System.Windows.Forms.Label();
        grpThisBookRatings = new System.Windows.Forms.GroupBox();
        lblThisBookTotalReviewsValue = new System.Windows.Forms.Label();
        lblAvgBookGradeThisText = new System.Windows.Forms.Label();
        lblThisBookAvgCoverGradeValue = new System.Windows.Forms.Label();
        lblAvgCoverGradeThisText = new System.Windows.Forms.Label();
        lblThisBookAvgBookGradeValue = new System.Windows.Forms.Label();
        lblTotalReviewsThisText = new System.Windows.Forms.Label();
        grpAuthorOverall = new System.Windows.Forms.GroupBox();
        lblAvgBookGradeAuthorText = new System.Windows.Forms.Label();
        lblTotalReviewedBooksAuthorValue = new System.Windows.Forms.Label();
        lblTotalReviewedBooksAuthorText = new System.Windows.Forms.Label();
        lblAvgBookGradeAuthorValue = new System.Windows.Forms.Label();
        grpDesignerOverall = new System.Windows.Forms.GroupBox();
        lblAvgCoverGradeDesignerText = new System.Windows.Forms.Label();
        lblDesignerTotalReviewedCoversValue = new System.Windows.Forms.Label();
        lblTotalReviewedCoversDesignerText = new System.Windows.Forms.Label();
        lblDesignerOverallAvgCoverGradeValue = new System.Windows.Forms.Label();
        grpThisBookRatings.SuspendLayout();
        grpAuthorOverall.SuspendLayout();
        grpDesignerOverall.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitleHeader
        // 
        lblTitleHeader.Location = new System.Drawing.Point(7, 9);
        lblTitleHeader.Name = "lblTitleHeader";
        lblTitleHeader.Size = new System.Drawing.Size(57, 22);
        lblTitleHeader.TabIndex = 0;
        lblTitleHeader.Text = "Title:";
        // 
        // lblStateHeader
        // 
        lblStateHeader.Location = new System.Drawing.Point(7, 31);
        lblStateHeader.Name = "lblStateHeader";
        lblStateHeader.Size = new System.Drawing.Size(57, 22);
        lblStateHeader.TabIndex = 1;
        lblStateHeader.Text = "State:";
        // 
        // lblAuthorHeader
        // 
        lblAuthorHeader.Location = new System.Drawing.Point(7, 53);
        lblAuthorHeader.Name = "lblAuthorHeader";
        lblAuthorHeader.Size = new System.Drawing.Size(57, 22);
        lblAuthorHeader.TabIndex = 2;
        lblAuthorHeader.Text = "Author:";
        // 
        // lblEditorHeader
        // 
        lblEditorHeader.Location = new System.Drawing.Point(7, 75);
        lblEditorHeader.Name = "lblEditorHeader";
        lblEditorHeader.Size = new System.Drawing.Size(57, 22);
        lblEditorHeader.TabIndex = 3;
        lblEditorHeader.Text = "Editor:";
        // 
        // lblDesignerHeader
        // 
        lblDesignerHeader.Location = new System.Drawing.Point(7, 97);
        lblDesignerHeader.Name = "lblDesignerHeader";
        lblDesignerHeader.Size = new System.Drawing.Size(57, 22);
        lblDesignerHeader.TabIndex = 4;
        lblDesignerHeader.Text = "Designer:";
        // 
        // lblDesignerValue
        // 
        lblDesignerValue.Location = new System.Drawing.Point(70, 97);
        lblDesignerValue.Name = "lblDesignerValue";
        lblDesignerValue.Size = new System.Drawing.Size(123, 22);
        lblDesignerValue.TabIndex = 9;
        lblDesignerValue.Text = "label6";
        // 
        // lblEditorValue
        // 
        lblEditorValue.Location = new System.Drawing.Point(70, 75);
        lblEditorValue.Name = "lblEditorValue";
        lblEditorValue.Size = new System.Drawing.Size(123, 22);
        lblEditorValue.TabIndex = 8;
        lblEditorValue.Text = "label7";
        // 
        // lblAuthorValue
        // 
        lblAuthorValue.Location = new System.Drawing.Point(70, 53);
        lblAuthorValue.Name = "lblAuthorValue";
        lblAuthorValue.Size = new System.Drawing.Size(123, 22);
        lblAuthorValue.TabIndex = 7;
        lblAuthorValue.Text = "label8";
        // 
        // lblStateValue
        // 
        lblStateValue.Location = new System.Drawing.Point(70, 31);
        lblStateValue.Name = "lblStateValue";
        lblStateValue.Size = new System.Drawing.Size(123, 22);
        lblStateValue.TabIndex = 6;
        lblStateValue.Text = "label9";
        // 
        // lblTitleValue
        // 
        lblTitleValue.Location = new System.Drawing.Point(70, 9);
        lblTitleValue.Name = "lblTitleValue";
        lblTitleValue.Size = new System.Drawing.Size(123, 22);
        lblTitleValue.TabIndex = 5;
        lblTitleValue.Text = "label10";
        // 
        // lblCoverPathHeader
        // 
        lblCoverPathHeader.Location = new System.Drawing.Point(236, 97);
        lblCoverPathHeader.Name = "lblCoverPathHeader";
        lblCoverPathHeader.Size = new System.Drawing.Size(91, 22);
        lblCoverPathHeader.TabIndex = 14;
        lblCoverPathHeader.Text = "Cover Path:";
        // 
        // lblAgeRestrictionHeader
        // 
        lblAgeRestrictionHeader.Location = new System.Drawing.Point(236, 75);
        lblAgeRestrictionHeader.Name = "lblAgeRestrictionHeader";
        lblAgeRestrictionHeader.Size = new System.Drawing.Size(91, 22);
        lblAgeRestrictionHeader.TabIndex = 13;
        lblAgeRestrictionHeader.Text = "Age Restriction:";
        // 
        // lblPublishDateHeader
        // 
        lblPublishDateHeader.Location = new System.Drawing.Point(236, 53);
        lblPublishDateHeader.Name = "lblPublishDateHeader";
        lblPublishDateHeader.Size = new System.Drawing.Size(91, 22);
        lblPublishDateHeader.TabIndex = 12;
        lblPublishDateHeader.Text = "Publish Date:";
        // 
        // lblEstEndDateHeader
        // 
        lblEstEndDateHeader.Location = new System.Drawing.Point(236, 31);
        lblEstEndDateHeader.Name = "lblEstEndDateHeader";
        lblEstEndDateHeader.Size = new System.Drawing.Size(91, 22);
        lblEstEndDateHeader.TabIndex = 11;
        lblEstEndDateHeader.Text = "End Date:";
        // 
        // lblStartDateHeader
        // 
        lblStartDateHeader.Location = new System.Drawing.Point(236, 9);
        lblStartDateHeader.Name = "lblStartDateHeader";
        lblStartDateHeader.Size = new System.Drawing.Size(91, 22);
        lblStartDateHeader.TabIndex = 10;
        lblStartDateHeader.Text = "Start Date:";
        // 
        // lblCoverPathValue
        // 
        lblCoverPathValue.Location = new System.Drawing.Point(324, 97);
        lblCoverPathValue.Name = "lblCoverPathValue";
        lblCoverPathValue.Size = new System.Drawing.Size(80, 22);
        lblCoverPathValue.TabIndex = 19;
        lblCoverPathValue.Text = "label16";
        // 
        // lblAgeRestrictionValue
        // 
        lblAgeRestrictionValue.Location = new System.Drawing.Point(324, 75);
        lblAgeRestrictionValue.Name = "lblAgeRestrictionValue";
        lblAgeRestrictionValue.Size = new System.Drawing.Size(80, 22);
        lblAgeRestrictionValue.TabIndex = 18;
        lblAgeRestrictionValue.Text = "label17";
        // 
        // lblPublishDateValue
        // 
        lblPublishDateValue.Location = new System.Drawing.Point(324, 53);
        lblPublishDateValue.Name = "lblPublishDateValue";
        lblPublishDateValue.Size = new System.Drawing.Size(80, 22);
        lblPublishDateValue.TabIndex = 17;
        lblPublishDateValue.Text = "label18";
        // 
        // lblEstEndDateValue
        // 
        lblEstEndDateValue.Location = new System.Drawing.Point(324, 31);
        lblEstEndDateValue.Name = "lblEstEndDateValue";
        lblEstEndDateValue.Size = new System.Drawing.Size(80, 22);
        lblEstEndDateValue.TabIndex = 16;
        lblEstEndDateValue.Text = "label19";
        // 
        // lblStartDateValue
        // 
        lblStartDateValue.Location = new System.Drawing.Point(324, 9);
        lblStartDateValue.Name = "lblStartDateValue";
        lblStartDateValue.Size = new System.Drawing.Size(80, 22);
        lblStartDateValue.TabIndex = 15;
        lblStartDateValue.Text = "label20";
        // 
        // grpThisBookRatings
        // 
        grpThisBookRatings.Controls.Add(lblThisBookTotalReviewsValue);
        grpThisBookRatings.Controls.Add(lblAvgBookGradeThisText);
        grpThisBookRatings.Controls.Add(lblThisBookAvgCoverGradeValue);
        grpThisBookRatings.Controls.Add(lblAvgCoverGradeThisText);
        grpThisBookRatings.Controls.Add(lblThisBookAvgBookGradeValue);
        grpThisBookRatings.Controls.Add(lblTotalReviewsThisText);
        grpThisBookRatings.Location = new System.Drawing.Point(236, 122);
        grpThisBookRatings.Name = "grpThisBookRatings";
        grpThisBookRatings.Size = new System.Drawing.Size(154, 86);
        grpThisBookRatings.TabIndex = 20;
        grpThisBookRatings.TabStop = false;
        grpThisBookRatings.Text = "Current Book Ratings";
        // 
        // lblThisBookTotalReviewsValue
        // 
        lblThisBookTotalReviewsValue.Location = new System.Drawing.Point(105, 63);
        lblThisBookTotalReviewsValue.Name = "lblThisBookTotalReviewsValue";
        lblThisBookTotalReviewsValue.Size = new System.Drawing.Size(44, 20);
        lblThisBookTotalReviewsValue.TabIndex = 26;
        lblThisBookTotalReviewsValue.Text = "label16";
        // 
        // lblAvgBookGradeThisText
        // 
        lblAvgBookGradeThisText.Location = new System.Drawing.Point(6, 19);
        lblAvgBookGradeThisText.Name = "lblAvgBookGradeThisText";
        lblAvgBookGradeThisText.Size = new System.Drawing.Size(102, 22);
        lblAvgBookGradeThisText.TabIndex = 21;
        lblAvgBookGradeThisText.Text = "Avg. Book Grade:";
        // 
        // lblThisBookAvgCoverGradeValue
        // 
        lblThisBookAvgCoverGradeValue.Location = new System.Drawing.Point(105, 41);
        lblThisBookAvgCoverGradeValue.Name = "lblThisBookAvgCoverGradeValue";
        lblThisBookAvgCoverGradeValue.Size = new System.Drawing.Size(44, 22);
        lblThisBookAvgCoverGradeValue.TabIndex = 25;
        lblThisBookAvgCoverGradeValue.Text = "label17";
        // 
        // lblAvgCoverGradeThisText
        // 
        lblAvgCoverGradeThisText.Location = new System.Drawing.Point(6, 41);
        lblAvgCoverGradeThisText.Name = "lblAvgCoverGradeThisText";
        lblAvgCoverGradeThisText.Size = new System.Drawing.Size(102, 22);
        lblAvgCoverGradeThisText.TabIndex = 22;
        lblAvgCoverGradeThisText.Text = "Avg. Cover Grade:";
        // 
        // lblThisBookAvgBookGradeValue
        // 
        lblThisBookAvgBookGradeValue.Location = new System.Drawing.Point(105, 19);
        lblThisBookAvgBookGradeValue.Name = "lblThisBookAvgBookGradeValue";
        lblThisBookAvgBookGradeValue.Size = new System.Drawing.Size(44, 22);
        lblThisBookAvgBookGradeValue.TabIndex = 24;
        lblThisBookAvgBookGradeValue.Text = "label18";
        // 
        // lblTotalReviewsThisText
        // 
        lblTotalReviewsThisText.Location = new System.Drawing.Point(6, 63);
        lblTotalReviewsThisText.Name = "lblTotalReviewsThisText";
        lblTotalReviewsThisText.Size = new System.Drawing.Size(102, 20);
        lblTotalReviewsThisText.TabIndex = 23;
        lblTotalReviewsThisText.Text = "Total Reviews:";
        // 
        // grpAuthorOverall
        // 
        grpAuthorOverall.Controls.Add(lblAvgBookGradeAuthorText);
        grpAuthorOverall.Controls.Add(lblTotalReviewedBooksAuthorValue);
        grpAuthorOverall.Controls.Add(lblTotalReviewedBooksAuthorText);
        grpAuthorOverall.Controls.Add(lblAvgBookGradeAuthorValue);
        grpAuthorOverall.Location = new System.Drawing.Point(7, 122);
        grpAuthorOverall.Name = "grpAuthorOverall";
        grpAuthorOverall.Size = new System.Drawing.Size(221, 66);
        grpAuthorOverall.TabIndex = 21;
        grpAuthorOverall.TabStop = false;
        grpAuthorOverall.Text = "Author\'s Overall Performance";
        // 
        // lblAvgBookGradeAuthorText
        // 
        lblAvgBookGradeAuthorText.Location = new System.Drawing.Point(6, 19);
        lblAvgBookGradeAuthorText.Name = "lblAvgBookGradeAuthorText";
        lblAvgBookGradeAuthorText.Size = new System.Drawing.Size(158, 22);
        lblAvgBookGradeAuthorText.TabIndex = 21;
        lblAvgBookGradeAuthorText.Text = "Avg. Book Grade (All Books):";
        // 
        // lblTotalReviewedBooksAuthorValue
        // 
        lblTotalReviewedBooksAuthorValue.Location = new System.Drawing.Point(164, 41);
        lblTotalReviewedBooksAuthorValue.Name = "lblTotalReviewedBooksAuthorValue";
        lblTotalReviewedBooksAuthorValue.Size = new System.Drawing.Size(51, 22);
        lblTotalReviewedBooksAuthorValue.TabIndex = 25;
        lblTotalReviewedBooksAuthorValue.Text = "label17";
        // 
        // lblTotalReviewedBooksAuthorText
        // 
        lblTotalReviewedBooksAuthorText.Location = new System.Drawing.Point(6, 41);
        lblTotalReviewedBooksAuthorText.Name = "lblTotalReviewedBooksAuthorText";
        lblTotalReviewedBooksAuthorText.Size = new System.Drawing.Size(158, 22);
        lblTotalReviewedBooksAuthorText.TabIndex = 22;
        lblTotalReviewedBooksAuthorText.Text = "Reviewed Books by Author:";
        // 
        // lblAvgBookGradeAuthorValue
        // 
        lblAvgBookGradeAuthorValue.Location = new System.Drawing.Point(164, 19);
        lblAvgBookGradeAuthorValue.Name = "lblAvgBookGradeAuthorValue";
        lblAvgBookGradeAuthorValue.Size = new System.Drawing.Size(51, 22);
        lblAvgBookGradeAuthorValue.TabIndex = 24;
        lblAvgBookGradeAuthorValue.Text = "label18";
        // 
        // grpDesignerOverall
        // 
        grpDesignerOverall.Controls.Add(lblAvgCoverGradeDesignerText);
        grpDesignerOverall.Controls.Add(lblDesignerTotalReviewedCoversValue);
        grpDesignerOverall.Controls.Add(lblTotalReviewedCoversDesignerText);
        grpDesignerOverall.Controls.Add(lblDesignerOverallAvgCoverGradeValue);
        grpDesignerOverall.Location = new System.Drawing.Point(13, 194);
        grpDesignerOverall.Name = "grpDesignerOverall";
        grpDesignerOverall.Size = new System.Drawing.Size(221, 66);
        grpDesignerOverall.TabIndex = 26;
        grpDesignerOverall.TabStop = false;
        grpDesignerOverall.Text = "Designer\'s Overall Performance";
        // 
        // lblAvgCoverGradeDesignerText
        // 
        lblAvgCoverGradeDesignerText.Location = new System.Drawing.Point(6, 19);
        lblAvgCoverGradeDesignerText.Name = "lblAvgCoverGradeDesignerText";
        lblAvgCoverGradeDesignerText.Size = new System.Drawing.Size(166, 22);
        lblAvgCoverGradeDesignerText.TabIndex = 21;
        lblAvgCoverGradeDesignerText.Text = "Avg. Cover Grade (All Covers):";
        // 
        // lblDesignerTotalReviewedCoversValue
        // 
        lblDesignerTotalReviewedCoversValue.Location = new System.Drawing.Point(170, 41);
        lblDesignerTotalReviewedCoversValue.Name = "lblDesignerTotalReviewedCoversValue";
        lblDesignerTotalReviewedCoversValue.Size = new System.Drawing.Size(45, 22);
        lblDesignerTotalReviewedCoversValue.TabIndex = 25;
        lblDesignerTotalReviewedCoversValue.Text = "label17";
        // 
        // lblTotalReviewedCoversDesignerText
        // 
        lblTotalReviewedCoversDesignerText.Location = new System.Drawing.Point(6, 41);
        lblTotalReviewedCoversDesignerText.Name = "lblTotalReviewedCoversDesignerText";
        lblTotalReviewedCoversDesignerText.Size = new System.Drawing.Size(166, 22);
        lblTotalReviewedCoversDesignerText.TabIndex = 22;
        lblTotalReviewedCoversDesignerText.Text = "Reviewed Covers by Designer:";
        // 
        // lblDesignerOverallAvgCoverGradeValue
        // 
        lblDesignerOverallAvgCoverGradeValue.Location = new System.Drawing.Point(170, 19);
        lblDesignerOverallAvgCoverGradeValue.Name = "lblDesignerOverallAvgCoverGradeValue";
        lblDesignerOverallAvgCoverGradeValue.Size = new System.Drawing.Size(45, 22);
        lblDesignerOverallAvgCoverGradeValue.TabIndex = 24;
        lblDesignerOverallAvgCoverGradeValue.Text = "label18";
        // 
        // BookDeepAnalyticsForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(404, 271);
        Controls.Add(grpDesignerOverall);
        Controls.Add(grpAuthorOverall);
        Controls.Add(grpThisBookRatings);
        Controls.Add(lblCoverPathValue);
        Controls.Add(lblAgeRestrictionValue);
        Controls.Add(lblPublishDateValue);
        Controls.Add(lblEstEndDateValue);
        Controls.Add(lblStartDateValue);
        Controls.Add(lblCoverPathHeader);
        Controls.Add(lblAgeRestrictionHeader);
        Controls.Add(lblPublishDateHeader);
        Controls.Add(lblEstEndDateHeader);
        Controls.Add(lblStartDateHeader);
        Controls.Add(lblDesignerValue);
        Controls.Add(lblEditorValue);
        Controls.Add(lblAuthorValue);
        Controls.Add(lblStateValue);
        Controls.Add(lblTitleValue);
        Controls.Add(lblDesignerHeader);
        Controls.Add(lblEditorHeader);
        Controls.Add(lblAuthorHeader);
        Controls.Add(lblStateHeader);
        Controls.Add(lblTitleHeader);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Deep Analytic";
        grpThisBookRatings.ResumeLayout(false);
        grpAuthorOverall.ResumeLayout(false);
        grpDesignerOverall.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.GroupBox grpDesignerOverall;
    private System.Windows.Forms.Label lblAvgCoverGradeDesignerText;
    private System.Windows.Forms.Label lblDesignerTotalReviewedCoversValue;
    private System.Windows.Forms.Label lblTotalReviewedCoversDesignerText;
    private System.Windows.Forms.Label lblDesignerOverallAvgCoverGradeValue;

    private System.Windows.Forms.GroupBox grpAuthorOverall;
    private System.Windows.Forms.Label lblAvgBookGradeAuthorText;
    private System.Windows.Forms.Label lblTotalReviewedBooksAuthorValue;
    private System.Windows.Forms.Label lblTotalReviewedBooksAuthorText;
    private System.Windows.Forms.Label lblAvgBookGradeAuthorValue;

    private System.Windows.Forms.Label lblThisBookTotalReviewsValue;
    private System.Windows.Forms.Label lblThisBookAvgCoverGradeValue;
    private System.Windows.Forms.Label lblThisBookAvgBookGradeValue;
    private System.Windows.Forms.Label lblTotalReviewsThisText;
    private System.Windows.Forms.Label lblAvgCoverGradeThisText;
    private System.Windows.Forms.Label lblAvgBookGradeThisText;

    private System.Windows.Forms.GroupBox grpThisBookRatings;

    private System.Windows.Forms.Label lblTitleHeader;
    private System.Windows.Forms.Label lblStateHeader;
    private System.Windows.Forms.Label lblAuthorHeader;
    private System.Windows.Forms.Label lblEditorHeader;
    private System.Windows.Forms.Label lblDesignerHeader;
    private System.Windows.Forms.Label lblDesignerValue;
    private System.Windows.Forms.Label lblEditorValue;
    private System.Windows.Forms.Label lblAuthorValue;
    private System.Windows.Forms.Label lblStateValue;
    private System.Windows.Forms.Label lblTitleValue;
    private System.Windows.Forms.Label lblCoverPathHeader;
    private System.Windows.Forms.Label lblAgeRestrictionHeader;
    private System.Windows.Forms.Label lblPublishDateHeader;
    private System.Windows.Forms.Label lblEstEndDateHeader;
    private System.Windows.Forms.Label lblStartDateHeader;
    private System.Windows.Forms.Label lblCoverPathValue;
    private System.Windows.Forms.Label lblAgeRestrictionValue;
    private System.Windows.Forms.Label lblPublishDateValue;
    private System.Windows.Forms.Label lblEstEndDateValue;
    private System.Windows.Forms.Label lblStartDateValue;

    #endregion
}