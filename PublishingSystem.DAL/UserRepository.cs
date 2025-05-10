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

                return connection.QuerySingle<int>(sql, new
                {
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Password,
                    user.Status
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
                        status = @Status
                    WHERE id = @Id";

                connection.Execute(sql, user);
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

        public List<User> GetUsers(string role = null, string status = null, string email = null)
        {
            using (var connection = DbContext.GetConnection())
            {
                var rolesToQuery = string.IsNullOrEmpty(role) ? Roles : new[] { role };
                var allUsers = new List<User>();

                foreach (var r in rolesToQuery)
                {
                    var sql = $@"
                        SELECT id, first_name AS FirstName, last_name AS LastName,
                               email, password AS Password, status,
                               '{r}' AS Role
                        FROM {r}
                        WHERE (@Status IS NULL OR status = @Status)
                          AND (@Email IS NULL OR email ILIKE '%' || @Email || '%')";

                    var users = connection.Query<User>(sql, new { Status = status, Email = email }).ToList();
                    allUsers.AddRange(users);
                }

                return allUsers.OrderBy(u => u.Id).ToList();
            }
        }
    }
}
