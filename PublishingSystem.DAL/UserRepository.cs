using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PublishingSystem.Models;

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
                    // При выборке Dapper сопоставит столбец 'status' (теперь BOOLEAN)
                    // со свойством 'IsActive' (bool) модели User.
                    var sql = $@"
                        SELECT id, first_name AS FirstName, last_name AS LastName,
                               email, password AS Password, status AS IsActive,
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
                // Dapper корректно обработает user.IsActive (bool) для столбца status (BOOLEAN)
                var sql = $@"
                    INSERT INTO {role} (first_name, last_name, email, password, status)
                    VALUES (@FirstName, @LastName, @Email, @Password, @IsActive)
                    RETURNING id";

                return connection.QuerySingle<int>(sql, new
                {
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Password,
                    user.IsActive // Передаем bool значение
                });
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = DbContext.GetConnection())
            {
                // Dapper корректно обработает user.IsActive (bool) для столбца status (BOOLEAN)
                var sql = $@"
                    UPDATE {user.Role}
                    SET first_name = @FirstName,
                        last_name = @LastName,
                        status = @IsActive
                    WHERE id = @Id";

                connection.Execute(sql, new
                {
                    user.FirstName,
                    user.LastName,
                    user.IsActive, // Передаем bool значение
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

        public List<User> GetUsers(string role = null, bool? isActive = null, string email = null)
        {
            using (var connection = DbContext.GetConnection())
            {
                var rolesToQuery = string.IsNullOrEmpty(role) ? Roles : new[] { role };
                var allUsers = new List<User>();

                foreach (var r in rolesToQuery)
                {
                    var whereClauses = new List<string>();
                    var parameters = new DynamicParameters();

                    if (isActive.HasValue)
                    {
                        whereClauses.Add("status = @IsActive"); // 'status' это имя столбца в БД
                        parameters.Add("IsActive", isActive.Value);
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
                               email, password AS Password, status AS IsActive,
                               '{r}' AS Role
                        FROM {r}
                        {whereSql}";

                    var users = connection.Query<User>(sql, parameters).ToList();
                    allUsers.AddRange(users);
                }

                return allUsers.OrderBy(u => u.Id).ToList();
            }
        }
        public User GetUserById(int userId, string role)
        {
            if (!Roles.Contains(role)) return null; // Проверка роли

            using (var connection = DbContext.GetConnection())
            {
                var sql = $@"
                    SELECT id, first_name AS FirstName, last_name AS LastName,
                           email, password AS Password, status AS IsActive,
                           '{role}' AS Role
                    FROM {role}
                    WHERE id = @UserId";
                return connection.QueryFirstOrDefault<User>(sql, new { UserId = userId });
            }
        }


        public void UpdatePassword(int userId, string role, string newHashedPassword)
        {
            if (!Roles.Contains(role)) return;

            using (var connection = DbContext.GetConnection())
            {
                var sql = $"UPDATE {role} SET password = @Password WHERE id = @UserId";
                connection.Execute(sql, new { Password = newHashedPassword, UserId = userId });
            }
        }

        public void UpdateProfile(int userId, string role, string firstName, string lastName)
        {
            if (!Roles.Contains(role)) return;

            using (var connection = DbContext.GetConnection())
            {
                var sql = $"UPDATE {role} SET first_name = @FirstName, last_name = @LastName WHERE id = @UserId";
                connection.Execute(sql, new { FirstName = firstName, LastName = lastName, UserId = userId });
            }
        }
    }
}