using Npgsql; // Required for NpgsqlConnection
using Publishing;
using PublishingSystem.Models; // Required for StatusType
using System;
using System.Windows.Forms;

namespace PublishingSystem.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configure Npgsql to map the PostgreSQL enum 'status_type' to the C# enum 'StatusType'
            NpgsqlConnection.GlobalTypeMapper.MapEnum<StatusType>("status_type");

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}