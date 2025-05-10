using Npgsql;

namespace PublishingSystem.DAL
{
    public static class DbContext
    {
        private static string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=IneGer371;Database=Publishing";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
