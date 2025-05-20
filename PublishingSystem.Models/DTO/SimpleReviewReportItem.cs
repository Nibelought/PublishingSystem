using System;
namespace PublishingSystem.Models.DTO
{
    public class SimpleReviewReportItem
    {
        public int ReviewId { get; set; }
        public DateTime DateTime { get; set; }
        public string CriticName { get; set; }
        public string BookName { get; set; }
        public decimal GradeBook { get; set; }
        public decimal GradeCover { get; set; }
        public string ReviewTextRtf { get; set; }
    }
}