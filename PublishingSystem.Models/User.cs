namespace PublishingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; } // "author", "editor", etc.
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; } // active/inactive
    }
}
