using System;
namespace PublishingSystem.Models.DTO
{
    public class BookAnalyticsReportData
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookState { get; set; }
        public string AuthorName { get; set; }
        public string EditorName { get; set; }
        public string DesignerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public string AgeRestrictions { get; set; }
        public string CoverImagePath { get; set; }
        public decimal ThisBookAvgBookGrade { get; set; }
        public decimal ThisBookAvgCoverGrade { get; set; }
        public int ThisBookTotalReviews { get; set; }
        public decimal AuthorOverallAvgBookGrade { get; set; }
        public int AuthorTotalReviewedBooks { get; set; }
        public decimal DesignerOverallAvgCoverGrade { get; set; }
        public int DesignerTotalReviewedCovers { get; set; }
    }
}