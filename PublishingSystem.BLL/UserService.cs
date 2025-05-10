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

            return BCrypt.Net.BCrypt.Verify(password, user.Password) ? user : null;
        }

        public int CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.Role) ||
                string.IsNullOrWhiteSpace(user.Status))
            {
                throw new Exception("All fields are required.");
            }

            if (!IsPasswordStrong(user.Password))
                throw new Exception("Password does not meet complexity requirements.");

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return _repository.CreateUser(user.Role, user);
        }

        public void UpdateUser(User user)
        {
            _repository.UpdateUser(user);
        }

        public void DeleteUser(User user)
        {
            _repository.DeleteUser(user);
        }

        public List<User> GetUsers(string role = null, string status = null, string email = null)
        {
            return _repository.GetUsers(role, status, email);
        }

        private bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 && password.Length <= 20 &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[0-9]") &&
                   Regex.IsMatch(password, @"[\\W_]");
        }
    }
}
