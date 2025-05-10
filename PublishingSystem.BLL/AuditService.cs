using System;
using System.IO;

namespace PublishingSystem.BLL
{
    public static class AuditService
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string LogFilePath = Path.Combine(LogDirectory, "admin_audit.log");

        public static void LogAdminAction(string adminEmail, string action, int? entityId = null)
        {
            try
            {
                if (!Directory.Exists(LogDirectory))
                    Directory.CreateDirectory(LogDirectory);

                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {adminEmail} | {action} | RecordID: {(entityId?.ToString() ?? "N/A")}";
                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit logging failed: " + ex.Message);
            }
        }
    }
}
