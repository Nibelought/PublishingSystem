﻿namespace PublishingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; } // author/editor/critic/designer
        public string Email { get; set; }
        public string Password { get; set; } // hashed
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; } // Заменено Status на IsActive (boolean)
    }
}