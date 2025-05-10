using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PublishingSystem.Models;
using PublishingSystem.DTO;

namespace PublishingSystem.DAL
{
    public class UserRepository
    {
        public int CreateUser(UserCreateDto dto, string hashedPassword)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = @"INSERT INTO users (first_name, last_name, email, password_hash, is_active)
                            VALUES (@FirstName, @LastName, @Email, @PasswordHash, @IsActive)
                            RETURNING id";

                int userId = connection.QuerySingle<int>(sql, new
                {
                    dto.FirstName,
                    dto.LastName,
                    dto.Email,
                    PasswordHash = hashedPassword,
                    dto.IsActive
                });

                string roleInsert = dto.Role switch
                {
                    "author" => "INSERT INTO authors (user_id) VALUES (@UserId)",
                    "editor" => "INSERT INTO editors (user_id) VALUES (@UserId)",
                    "critic" => "INSERT INTO critics (user_id) VALUES (@UserId)",
                    "designer" => "INSERT INTO designers (user_id) VALUES (@UserId)",
                    _ => null
                };

                if (roleInsert != null)
                {
                    connection.Execute(roleInsert, new { UserId = userId });
                }

                return userId;
            }
        }

        public List<User> GetUsers(string role = null, bool? isActive = null, string email = null)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = @"SELECT u.* FROM users u
                            LEFT JOIN authors a ON u.id = a.user_id
                            LEFT JOIN editors e ON u.id = e.user_id
                            LEFT JOIN critics c ON u.id = c.user_id
                            LEFT JOIN designers d ON u.id = d.user_id
                            WHERE (COALESCE(@Role, '') = '' OR 
                                  (@Role = 'author' AND a.user_id IS NOT NULL) OR
                                  (@Role = 'editor' AND e.user_id IS NOT NULL) OR
                                  (@Role = 'critic' AND c.user_id IS NOT NULL) OR
                                  (@Role = 'designer' AND d.user_id IS NOT NULL))
                              AND (@IsActive IS NULL OR u.is_active = @IsActive)
                              AND (@Email IS NULL OR u.email ILIKE '%' || @Email || '%')
                            ORDER BY u.id";

                return connection.Query<User>(sql, new { Role = role, IsActive = isActive, Email = email }).ToList();
            }
        }
    }
}
