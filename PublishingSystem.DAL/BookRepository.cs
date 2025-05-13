using Dapper;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublishingSystem.DAL
{
    public class BookRepository
    {
        // Базовый SELECT с JOIN'ами для получения имен
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
                 // Используем BaseBookSelectSql из предыдущего ответа
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

        // Книги, ожидающие редактора
        public List<Book> GetBooksNeedingEditor()
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = $"{BaseBookSelectSql} WHERE b.id_editor IS NULL AND b.state = @State ORDER BY b.id DESC";
                return connection.Query<Book>(sql, new { State = BookState.in_progress }).ToList();
            }
        }

        // Книги, ожидающие дизайнера
        public List<Book> GetBooksNeedingDesigner()
        {
            using (var connection = DbContext.GetConnection())
            {
                // Дизайнер может взять книгу после редактора
                var sql = $"{BaseBookSelectSql} WHERE b.id_designer IS NULL AND b.state = @State ORDER BY b.id DESC";
                return connection.Query<Book>(sql, new { State = BookState.editing }).ToList();
            }
        }

        // Книги для рецензирования (например, опубликованные)
         public List<Book> GetBooksForReview()
         {
             using (var connection = DbContext.GetConnection())
             {
                 // Предположим, рецензировать можно только опубликованные
                 var sql = $"{BaseBookSelectSql} WHERE b.state = @State ORDER BY b.name ASC";
                 return connection.Query<Book>(sql, new { State = BookState.published }).ToList();
             }
         }


        public int Create(Book book)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = @"
                    INSERT INTO book (name, id_author, state, start_date, estimated_end_date, age_restrictions)
                    VALUES (@Name, @IdAuthor, @State, @StartDate, @EstimatedEndDate, @AgeRestrictions)
                    RETURNING id";
                return connection.QuerySingle<int>(sql, book);
            }
        }

        public void AssignEditor(int bookId, int editorId)
        {
            using (var connection = DbContext.GetConnection())
            {
                var sql = "UPDATE book SET id_editor = @EditorId, state = @NewState WHERE id = @BookId";
                connection.Execute(sql, new { EditorId = editorId, NewState = BookState.editing, BookId = bookId });
            }
        }

         public void AssignDesigner(int bookId, int designerId)
         {
             using (var connection = DbContext.GetConnection())
             {
                 var sql = "UPDATE book SET id_designer = @DesignerId, state = @NewState WHERE id = @BookId";
                 // После дизайнера, книга готова к печати (или другой статус по вашей логике)
                 connection.Execute(sql, new { DesignerId = designerId, NewState = BookState.ready_to_print, BookId = bookId });
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
                var sql = "UPDATE book SET state = @State WHERE id = @BookId";
                 // Если статус 'published', можно установить дату публикации
                 if (state == BookState.published) {
                     sql = "UPDATE book SET state = @State, publish_date = @PublishDate WHERE id = @BookId";
                     connection.Execute(sql, new { State = state, PublishDate = DateTime.Now, BookId = bookId });
                 } else {
                     connection.Execute(sql, new { State = state, BookId = bookId });
                 }
            }
         }

        // Полное обновление для админа
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
                        state = @State,
                        start_date = @StartDate,
                        estimated_end_date = @EstimatedEndDate,
                        age_restrictions = @AgeRestrictions,
                        cover_image_path = @CoverImagePath,
                        publish_date = @PublishDate
                    WHERE id = @Id";
                connection.Execute(sql, book);
            }
        }

        public void Delete(int bookId)
        {
             using (var connection = DbContext.GetConnection())
             {
                 // Удаление книги приведет к каскадному удалению рецензий (ON DELETE CASCADE)
                 var sql = "DELETE FROM book WHERE id = @Id";
                 connection.Execute(sql, new { Id = bookId });
             }
        }
    }
}