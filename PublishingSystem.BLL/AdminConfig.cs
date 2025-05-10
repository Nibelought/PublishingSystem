using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PublishingSystem.BLL
{
    public static class AdminConfig
    {
        private static readonly string AdminListPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "admins.txt");
        private static HashSet<string>? _cachedEmails;

        public static bool IsAdmin(string email)
        {
            if (_cachedEmails == null)
                LoadAdminList();

            return _cachedEmails!.Contains(email.ToLowerInvariant());
        }

        private static void LoadAdminList()
        {
            if (!File.Exists(AdminListPath))
                _cachedEmails = new HashSet<string>();
            else
                _cachedEmails = File.ReadAllLines(AdminListPath)
                    .Select(e => e.Trim().ToLowerInvariant())
                    .Where(e => !string.IsNullOrWhiteSpace(e))
                    .ToHashSet();
        }
    }
}
