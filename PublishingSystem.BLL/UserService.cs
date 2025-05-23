﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PublishingSystem.Models;
using PublishingSystem.DAL;
using System.Text;

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
            if (user == null || !user.IsActive) return null;

            return BCrypt.Net.BCrypt.Verify(password, user.Password) ? user : null;
        }

        public int CreateUser(User user) // already hashed
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Password) || // Check hash pass not empty
                string.IsNullOrWhiteSpace(user.Role))
            {
                throw new Exception("All user fields are required.");
            }
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

        public List<User> GetUsers(string role = null, bool? isActive = null, string email = null)
        {
            return _repository.GetUsers(role, isActive, email);
        }

        public void ChangePassword(int userId, string role, string currentPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("New password cannot be empty.");
            if (!IsPasswordStrong(newPassword))
                throw new ArgumentException("New password does not meet complexity requirements.");

            var user = _repository.GetUserById(userId, role);
            // MessageBox.Show($"GetUserById: User ID: {userId}, Role: {role}\nFound User: {(user != null ? user.Email : "NOT FOUND")}\nPassword Hash from DB: {(user != null ? user.Password : "N/A")}");
            // // ВРЕМЕННАЯ ПРОВЕРКА 2: Какие пароли сравниваются?
            // string currentPasswordPlainText = currentPassword; // Это пароль, введенный пользователем
            // string hashedPasswordFromDb = user.Password;
            // bool verificationResult = BCrypt.Net.BCrypt.Verify(currentPasswordPlainText, hashedPasswordFromDb);
            // MessageBox.Show($"Current Plain: {currentPasswordPlainText}\nHash from DB: {hashedPasswordFromDb}\nBCrypt.Verify Result: {verificationResult}");
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            if (!BCrypt.Net.BCrypt.Verify(currentPassword, user.Password))
                throw new UnauthorizedAccessException("Invalid current password.");

            var newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _repository.UpdatePassword(userId, role, newHashedPassword);
        }

        public void UpdateProfile(int userId, string role, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("First name and last name cannot be empty.");
            _repository.UpdateProfile(userId, role, firstName, lastName);
        }

        public string GeneratePassword(int length = 12)
        {
            const string lowers = "abcdefghijklmnopqrstuvwxyz";
            const string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "1234567890";
            const string specials = "!@#$%^&*()_-+=";
            const string allChars = lowers + uppers + digits + specials;

            var random = new Random();
            var password = new StringBuilder(length);
            bool hasLower = false, hasUpper = false, hasDigit = false, hasSpecial = false;

            int attempts = 0; // try limit
            while (password.Length < length || !(hasLower && hasUpper && hasDigit && hasSpecial))
            {
                if (password.Length == length || attempts > length * 5) // If enough lenght, but not all types OR too many tries
                {
                    password.Clear();
                    hasLower = hasUpper = hasDigit = hasSpecial = false;
                    attempts = 0;
                }

                char nextChar = allChars[random.Next(allChars.Length)];
                password.Append(nextChar);
                attempts++;

                if (lowers.Contains(nextChar)) hasLower = true;
                else if (uppers.Contains(nextChar)) hasUpper = true;
                else if (digits.Contains(nextChar)) hasDigit = true;
                else if (specials.Contains(nextChar)) hasSpecial = true;
            }
            return new string(password.ToString().ToCharArray().OrderBy(x => random.Next()).ToArray());
        }

        private bool IsPasswordStrong(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            return password.Length >= 8 && password.Length <= 20 &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[0-9]") &&
                   Regex.IsMatch(password, @"[\W_]");
        }
    }
}