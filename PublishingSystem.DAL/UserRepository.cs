using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PublishingSystem.Models;
// Npgsql using не требуется для этого конкретного изменения, если только для DbContext

namespace PublishingSystem.DAL
{
    public class UserRepository
    {
        private static readonly string[] Roles = { "author", "editor", "critic", "designer" };

        public User GetUserByEmail(string email)
        {
            using (var connection = DbContext.GetConnection())
            {
                foreach (var role in Roles)
                {
                    var sql = $@"
                        SELECT id, first_name AS FirstName, last_name AS LastName,
                               email, password AS Password, status,
                               '{role}' AS Role
                        FROM {role}
                        WHERE email = @Email
                        LIMIT 1";

                    var user = connection.QueryFirstOrDefault<User>(sql, new { Email = email });
                    if (user != null)
                        return user;
                }
                return null;
            }
        }


        public int CreateUser(string role, User user)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = $@"
                    INSERT INTO {role} (first_name, last_name, email, password, status)
                    VALUES (@FirstName, @LastName, @Email, @Password, @Status)
                    RETURNING id";

                // Для CreateUser, если маппинг работает, это должно быть ОК.
                // Если и здесь проблема, то Status = user.Status.ToString() также потребуется.
                return connection.QuerySingle<int>(sql, new
                {
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Password,
                    Status = user.Status // Оставляем пока так, предполагая, что Npgsql.GlobalTypeMapper.MapEnum срабатывает здесь
                                         // или Dapper обрабатывает это иначе при INSERT RETURNING.
                                         // Если CreateUser тоже ломается с той же ошибкой, примените .ToString() и здесь.
                });
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = $@"
                    UPDATE {user.Role}
                    SET first_name = @FirstName,
                        last_name = @LastName,
                        status = @Status::status_type -- Явное приведение типа в SQL для строки
                    WHERE id = @Id";

                connection.Execute(sql, new
                {
                    user.FirstName,
                    user.LastName,
                    Status = user.Status.ToString(), // Явно преобразуем enum в строку
                    user.Id
                });
            }
        }

        public void DeleteUser(User user)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = $"DELETE FROM {user.Role} WHERE id = @Id";
                connection.Execute(sql, new { user.Id });
            }
        }

        public List<User> GetUsers(string role = null, StatusType? status = null, string email = null)
        {
            using (var connection = DbContext.GetConnection())
            {
                var rolesToQuery = string.IsNullOrEmpty(role) ? Roles : new[] { role };
                var allUsers = new List<User>();

                foreach (var r in rolesToQuery)
                {
                    var whereClauses = new List<string>();
                    var parameters = new DynamicParameters(); // DynamicParameters для гибкости

                    if (status.HasValue)
                    {
                        whereClauses.Add("status = @Status");
                        // Здесь также может потребоваться .ToString() если глобальный маппинг не срабатывает
                        // Но Dapper.DynamicParameters может лучше обрабатывать enum с MapEnum.
                        parameters.Add("Status", status.Value);
                    }
                    if (!string.IsNullOrEmpty(email))
                    {
                        whereClauses.Add("email ILIKE @Email");
                        parameters.Add("Email", $"%{email}%");
                    }

                    var whereSql = whereClauses.Count > 0
                        ? "WHERE " + string.Join(" AND ", whereClauses)
                        : "";

                    var sql = $@"
                        SELECT id, first_name AS FirstName, last_name AS LastName,
                               email, password AS Password, status,
                               '{r}' AS Role
                        FROM {r}
                        {whereSql}";

                    var users = connection.Query<User>(sql, parameters).ToList();
                    allUsers.AddRange(users);
                }

                return allUsers.OrderBy(u => u.Id).ToList();
            }
        }
    }
}