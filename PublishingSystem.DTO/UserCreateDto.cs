using PublishingSystem.DTO;


namespace PublishingSystem.DTO
{
    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } // "author", "editor", "critic", "designer"
        public bool IsActive { get; set; }
    }
}
