namespace PublishingSystem.Models.DTO
{
    public class EmployeeWorkloadItem
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeRole { get; set; }
        public int ActiveBooksCount { get; set; }
    }
}