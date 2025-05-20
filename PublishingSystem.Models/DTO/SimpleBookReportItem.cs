using System;
namespace PublishingSystem.Models.DTO
{
    public class SimpleBookReportItem
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string BookState { get; set; }
        public string AgeRestrictions { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}