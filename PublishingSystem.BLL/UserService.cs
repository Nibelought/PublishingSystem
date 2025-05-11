using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PublishingSystem.Models;
using PublishingSystem.DAL;

namespace PublishingSystem.BLL
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public User Authenticate(string email, string password)
        {
            var user = _repository.GetUserByEmail(email);
            if (user == null) return null;

            // Ensure BCrypt.Verify can handle the stored hash format
            return BCrypt.Net.BCrypt.Verify(password, user.Password) ? user : null;
        }

        public int CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Password) || // Password here is plain text from AdminDashboardForm
                string.IsNullOrWhiteSpace(user.Role) ||
                !Enum.IsDefined(typeof(StatusType), user.Status)) // Validate enum value
            {
                throw new Exception("All fields are required and must be valid.");
            }

            if (!IsPasswordStrong(user.Password)) // Check plain text password strength
                throw new Exception("Password does not meet complexity requirements.");

            // Hash the password before saving
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return _repository.CreateUser(user.Role, user);
        }

        public void UpdateUser(User user)
        {
            // Password is not updated here, only FirstName, LastName, Status.
            // If password update is needed, it requires separate logic (current password, new password, etc.)
            _repository.UpdateUser(user);
        }

        public void DeleteUser(User user)
        {
            _repository.DeleteUser(user);
        }

        public List<User> GetUsers(string role = null, StatusType? status = null, string email = null)
        {
            return _repository.GetUsers(role, status, email);
        }

        private bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            return password.Length >= 8 && password.Length <= 20 &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[0-9]") &&
                   Regex.IsMatch(password, @"[\W_]"); // \W matches non-word characters, _ is explicitly added
        }
    }
}