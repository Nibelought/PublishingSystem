using System;
namespace PublishingSystem.Models.DTO
{
    public class BookAwaitingAssignmentItem
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string CurrentState { get; set; }
        public string AssignmentStatus { get; set; }
        public DateTime StartDate { get; set; }
    }
}