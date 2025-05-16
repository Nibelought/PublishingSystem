using Dapper;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublishingSystem.DAL
{
    public class BookRepository
    {
        private const string BaseBookSelectSql = @"
            SELECT
                b.id AS Id, b.name AS Name, b.id_author AS IdAuthor,
                b.id_editor AS IdEditor, b.id_designer AS IdDesigner,
                b.state AS State, b.start_date AS StartDate, b.estimated_end_date AS EstimatedEndDate,
                b.age_restrictions AS AgeRestrictions, b.cover_image_path AS CoverImagePath,
                b.publish_date AS PublishDate,
                a.first_name || ' ' || a.last_name AS AuthorName,
                e.first_name || ' ' || e.last_name AS EditorName,
                d.first_name || ' ' || d.last_name AS DesignerName
            FROM book b
            JOIN author a ON b.id_author = a.id
            LEFT JOIN editor e ON b.id_editor = e.id
            LEFT JOIN designer d ON b.id_designer = d.id";

        public Book GetById(int id)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = $"{BaseBookSelectSql} WHERE b.id = @Id";
                return connection.QueryFirstOrDefault<Book>(sql, new { Id = id });
            }
        }

        public List<Book> GetAll()
        {
             using (var connection = DbContext.GetConnection())
             {
                 return connection.Query<Book>(BaseBookSelectSql).ToList();
             }
        }

        public List<Book> GetByAuthor(int authorId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = $"{BaseBookSelectSql} WHERE b.id_author = @AuthorId ORDER BY b.id DESC";
                 return connection.Query<Book>(sql, new { AuthorId = authorId }).ToList();
             }
        }
         
        public List<Book> GetByEditor(int editorId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = $"{BaseBookSelectSql} WHERE b.id_editor = @EditorId ORDER BY b.id DESC";
                 return connection.Query<Book>(sql, new { EditorId = editorId }).ToList();
             }
         }
         
        public List<Book> GetByDesigner(int designerId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = $"{BaseBookSelectSql} WHERE b.id_designer = @DesignerId ORDER BY b.id DESC";
                 return connection.Query<Book>(sql, new { DesignerId = designerId }).ToList();
             }
         }

        public List<Book> GetBooksNeedingEditor()
        {
            using (var connection = DbContext.GetConnection())
            {
                // Для SELECT операций глобальный маппинг обычно работает хорошо при чтении.
                // Но если и здесь будут проблемы, можно использовать state = 'in_progress'::book_state
                var sql = $"{BaseBookSelectSql} WHERE b.id_editor IS NULL AND b.state = @State::book_state ORDER BY b.id DESC";
                return connection.Query<Book>(sql, new { State = BookState.in_progress.ToString() }).ToList();
            }
        }

        public List<Book> GetBooksNeedingDesigner()
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = $"{BaseBookSelectSql} WHERE b.id_designer IS NULL AND b.state = @State::book_state ORDER BY b.id DESC";
                return connection.Query<Book>(sql, new { State = BookState.editing.ToString() }).ToList();
            }
        }

        public List<Book> GetBooksForReview()
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = $"{BaseBookSelectSql} WHERE b.state = @State::book_state ORDER BY b.name ASC";
                 return connection.Query<Book>(sql, new { State = BookState.published.ToString() }).ToList();
             }
         }

        public int Create(Book book)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = @"
                    INSERT INTO book (name, id_author, state, start_date, estimated_end_date, age_restrictions, cover_image_path, id_editor, id_designer)
                    VALUES (@Name, @IdAuthor, @State::book_state, @StartDate, @EstimatedEndDate, @AgeRestrictions::age_restriction, @CoverImagePath, @IdEditor, @IdDesigner)
                    RETURNING id";
                return connection.QuerySingle<int>(sql, new {
                    book.Name,
                    book.IdAuthor,
                    State = book.State.ToString(), // Преобразуем C# enum в строку
                    book.StartDate,
                    book.EstimatedEndDate,
                    AgeRestrictions = book.AgeRestrictions.ToString().TrimStart('_').Replace("plus", "+"), // Преобразуем в строку, соответствующую БД enum
                    book.CoverImagePath,
                    book.IdEditor,
                    book.IdDesigner
                });
            }
        }

        public void AssignEditor(int bookId, int editorId)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = "UPDATE book SET id_editor = @EditorId, state = @NewState::book_state WHERE id = @BookId";
                connection.Execute(sql, new { EditorId = editorId, NewState = BookState.editing.ToString(), BookId = bookId });
            }
        }

        public void AssignDesigner(int bookId, int designerId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = "UPDATE book SET id_designer = @DesignerId, state = @NewState::book_state WHERE id = @BookId";
                 connection.Execute(sql, new { DesignerId = designerId, NewState = BookState.ready_to_print.ToString(), BookId = bookId });
             }
         }

        public void UpdateCoverPath(int bookId, string relativePath)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = "UPDATE book SET cover_image_path = @Path WHERE id = @BookId";
                 connection.Execute(sql, new { Path = relativePath, BookId = bookId });
             }
        }

        public void UpdateEstimatedEndDate(int bookId, DateTime date)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = "UPDATE book SET estimated_end_date = @Date WHERE id = @BookId";
                connection.Execute(sql, new { Date = date, BookId = bookId });
            }
        }

        public void UpdateState(int bookId, BookState state)
        {
            using (var connection = DbContext.GetConnection())
            {
                string sql;
                object parameters;

                if (state == BookState.published) {
                    sql = "UPDATE book SET state = @State::book_state, publish_date = @PublishDate WHERE id = @BookId";
                    parameters = new { State = state.ToString(), PublishDate = DateTime.Now, BookId = bookId };
                } else {
                    sql = "UPDATE book SET state = @State::book_state WHERE id = @BookId";
                    parameters = new { State = state.ToString(), BookId = bookId };
                }
                connection.Execute(sql, parameters);
            }
         }

        public void Update(Book book)
        {
            using (var connection = DbContext.GetConnection())
            {
                 var sql = @"
                    UPDATE book SET
                        name = @Name,
                        id_author = @IdAuthor,
                        id_editor = @IdEditor,
                        id_designer = @IdDesigner,
                        state = @State::book_state,
                        start_date = @StartDate,
                        estimated_end_date = @EstimatedEndDate,
                        age_restrictions = @AgeRestrictions::age_restriction,
                        cover_image_path = @CoverImagePath,
                        publish_date = @PublishDate
                    WHERE id = @Id";
                connection.Execute(sql, new {
                    book.Id, // Важно передать ID для WHERE
                    book.Name,
                    book.IdAuthor,
                    book.IdEditor,
                    book.IdDesigner,
                    State = book.State.ToString(),
                    book.StartDate,
                    book.EstimatedEndDate,
                    AgeRestrictions = book.AgeRestrictions.ToString().TrimStart('_').Replace("plus", "+"),
                    book.CoverImagePath,
                    book.PublishDate
                });
            }
        }

        public void Delete(int bookId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = "DELETE FROM book WHERE id = @Id";
                 connection.Execute(sql, new { Id = bookId });
             }
        }
    }
}