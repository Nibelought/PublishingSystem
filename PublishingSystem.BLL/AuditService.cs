using System;
using Dapper;
using PublishingSystem.DAL;

namespace PublishingSystem.BLL
{
    public static class AuditService
    {
        public static void LogAdminAction(string adminEmail, string action, int? entityId = null)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = @"INSERT INTO admin_audit (admin_email, action, entity_id, action_time)
                            VALUES (@Email, @Action, @EntityId, @Time)";
                connection.Execute(sql, new
                {
                    Email = adminEmail,
                    Action = action,
                    EntityId = entityId,
                    Time = DateTime.Now
                });
            }
        }
    }
}
