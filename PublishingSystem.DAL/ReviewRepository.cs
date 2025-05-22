using Dapper;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublishingSystem.DAL
{
    public class ReviewRepository
    {
        private const string BaseReviewSelectSql = @"
            SELECT
                r.id AS Id, r.id_critic AS IdCritic, r.id_book AS IdBook,
                r.date_time AS DateTime, r.text AS RtfText,
                r.grade_book AS GradeBook, r.grade_cover AS GradeCover,
                c.first_name || ' ' || c.last_name AS CriticName,
                b.name AS BookName
            FROM review r
            JOIN critic c ON r.id_critic = c.id
            JOIN book b ON r.id_book = b.id";

        public Review GetById(int id)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = $"{BaseReviewSelectSql} WHERE r.id = @Id";
                return connection.QueryFirstOrDefault<Review>(sql, new { Id = id });
            }
        }

         public List<Review> GetAll()
         {
            using (var connection = DbContext.GetConnection())
            {
                 return connection.Query<Review>(BaseReviewSelectSql).ToList();
            }
         }

        public List<Review> GetByBookId(int bookId)
        {
            using (var connection = DbContext.GetConnection())
            {
                 var sql = $"{BaseReviewSelectSql} WHERE r.id_book = @BookId ORDER BY r.date_time DESC";
                return connection.Query<Review>(sql, new { BookId = bookId }).ToList();
            }
        }

        public List<Review> GetByCriticId(int criticId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = $"{BaseReviewSelectSql} WHERE r.id_critic = @CriticId ORDER BY r.date_time DESC";
                 return connection.Query<Review>(sql, new { CriticId = criticId }).ToList();
             }
        }

        public int Create(Review review)
        {
            using (var connection = DbContext.GetConnection())
            {
                // Сохраняем RTF в поле text
                var sql = @"
                    INSERT INTO review (id_critic, id_book, date_time, text, grade_book, grade_cover)
                    VALUES (@IdCritic, @IdBook, @DateTime, @RtfText, @GradeBook, @GradeCover)
                    RETURNING id";
                return connection.QuerySingle<int>(sql, review);
            }
        }

        public void Delete(int reviewId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = "DELETE FROM review WHERE id = @Id";
                 connection.Execute(sql, new { Id = reviewId });
             }
        }
    }
}