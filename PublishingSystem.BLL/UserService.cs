using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PublishingSystem.Models;
using PublishingSystem.DTO;
using PublishingSystem.DAL;
using BCrypt.Net;

namespace PublishingSystem.BLL
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public void CreateUser(UserCreateDto dto, string adminEmail)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName) ||
                string.IsNullOrWhiteSpace(dto.LastName) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Password) ||
                string.IsNullOrWhiteSpace(dto.ConfirmPassword) ||
                string.IsNullOrWhiteSpace(dto.Role))
            {
                throw new Exception("All fields are required.");
            }

            if (dto.Password != dto.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            if (!IsPasswordStrong(dto.Password))
                throw new Exception("Password does not meet complexity requirements.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            int userId = _repository.CreateUser(dto, hashedPassword);

            AuditService.LogAdminAction(adminEmail, $"Created user with role {dto.Role}", userId);
        }

        public List<User> GetUsers(string roleFilter = null, bool? isActive = null, string emailFilter = null)
        {
            return _repository.GetUsers(roleFilter, isActive, emailFilter);
        }

        private bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 && password.Length <= 20 &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[0-9]") &&
                   Regex.IsMatch(password, @"[\W_]");
        }
    }
}
