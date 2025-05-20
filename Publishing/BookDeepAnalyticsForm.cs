using System;
using System.Globalization; // For CultureInfo.InvariantCulture
using System.Windows.Forms;
using PublishingSystem.Models.DTO; // Assuming DTOs are in Models.DTO

namespace PublishingSystem.UI
{
    public partial class BookDeepAnalyticsForm : Form
    {
        private readonly BookAnalyticsReportData _reportData;

        public BookDeepAnalyticsForm(BookAnalyticsReportData reportData)
        {
            InitializeComponent(); // This will initialize controls if they are in Designer.cs
            _reportData = reportData;
            DisplayReportData();
        }

        private void DisplayReportData()
        {
            if (_reportData == null)
            {
                MessageBox.Show("No data to display for the report.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = $"Deep Analytics: {_reportData.BookTitle ?? "N/A"} (ID: {_reportData.BookId})";

            // General Book Info
            SetLabelText(FindControlRecursive(this, "lblTitleValue") as Label, _reportData.BookTitle);
            SetLabelText(FindControlRecursive(this, "lblStateValue") as Label, _reportData.BookState);
            SetLabelText(FindControlRecursive(this, "lblAuthorValue") as Label, _reportData.AuthorName);
            SetLabelText(FindControlRecursive(this, "lblEditorValue") as Label, _reportData.EditorName);
            SetLabelText(FindControlRecursive(this, "lblDesignerValue") as Label, _reportData.DesignerName);
            SetLabelText(FindControlRecursive(this, "lblStartDateValue") as Label, _reportData.StartDate?.ToString("yyyy-MM-dd") ?? "N/A");
            SetLabelText(FindControlRecursive(this, "lblEstEndDateValue") as Label, _reportData.EstimatedEndDate?.ToString("yyyy-MM-dd") ?? "N/A");
            SetLabelText(FindControlRecursive(this, "lblPublishDateValue") as Label, _reportData.PublishDate?.ToString("yyyy-MM-dd") ?? "N/A");
            SetLabelText(FindControlRecursive(this, "lblAgeRestrictionValue") as Label, _reportData.AgeRestrictions);
            SetLabelText(FindControlRecursive(this, "lblCoverPathValue") as Label, _reportData.CoverImagePath ?? "N/A");

            // This Book's Ratings
            GroupBox grpThisBook = FindControlRecursive(this, "grpThisBookRatings") as GroupBox;
            if (grpThisBook != null)
            {
                SetLabelText(FindControlRecursive(grpThisBook, "lblThisBookAvgBookGradeValue") as Label, _reportData.ThisBookAvgBookGrade.ToString("0.0", CultureInfo.InvariantCulture));
                SetLabelText(FindControlRecursive(grpThisBook, "lblThisBookAvgCoverGradeValue") as Label, _reportData.ThisBookAvgCoverGrade.ToString("0.0", CultureInfo.InvariantCulture));
                SetLabelText(FindControlRecursive(grpThisBook, "lblThisBookTotalReviewsValue") as Label, _reportData.ThisBookTotalReviews.ToString());
            }

            // Author's Overall Performance
            GroupBox grpAuthor = FindControlRecursive(this, "grpAuthorOverall") as GroupBox;
            if (grpAuthor != null)
            {
                SetLabelText(FindControlRecursive(grpAuthor, "lblAvgBookGradeAuthorValue") as Label, _reportData.AuthorOverallAvgBookGrade.ToString("0.0", CultureInfo.InvariantCulture));
                SetLabelText(FindControlRecursive(grpAuthor, "lblTotalReviewedBooksAuthorValue") as Label, _reportData.AuthorTotalReviewedBooks.ToString());
            }
            
            // Designer's Overall Performance
            GroupBox grpDesigner = FindControlRecursive(this, "grpDesignerOverall") as GroupBox;
            if (grpDesigner != null)
            {
                SetLabelText(FindControlRecursive(grpDesigner, "lblDesignerOverallAvgCoverGradeValue") as Label, _reportData.DesignerOverallAvgCoverGrade.ToString("0.0", CultureInfo.InvariantCulture));
                SetLabelText(FindControlRecursive(grpDesigner, "lblDesignerTotalReviewedCoversValue") as Label, _reportData.DesignerTotalReviewedCovers.ToString());
            }
        }

        private void SetLabelText(Label label, string text)
        {
            if (label != null)
            {
                label.Text = text ?? "N/A";
            }
            else
            {
                Console.WriteLine($"Warning: Label to set text '{text}' was not found.");
            }
        }

        // Helper to find controls if they are nested (e.g., Label inside GroupBox)
        public static Control FindControlRecursive(Control root, string name)
        {
            if (root.Name == name) return root;
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, name);
                if (t != null) return t;
            }
            return null;
        }
    }
}