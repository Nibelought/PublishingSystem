using PublishingSystem.DAL;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;

namespace PublishingSystem.BLL
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public Book GetBookById(int id) => _bookRepository.GetById(id);
        public List<Book> GetAllBooks() => _bookRepository.GetAll();
        public List<Book> GetBooksByAuthor(int authorId) => _bookRepository.GetByAuthor(authorId);
        public List<Book> GetBooksNeedingEditor() => _bookRepository.GetBooksNeedingEditor();
        public List<Book> GetBooksNeedingDesigner() => _bookRepository.GetBooksNeedingDesigner();
        public List<Book> GetBooksForReview() => _bookRepository.GetBooksForReview();


        public int AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Name) || book.IdAuthor <= 0) // EstimatedEndDate теперь nullable
            {
                throw new ArgumentException("Invalid book data provided (Name and Author are required).");
            }

            // StartDate и State устанавливаются здесь или в AuthorDashboardForm
            book.StartDate = DateTime.Now.Date;
            book.State = BookState.in_progress;

            // IdEditor, IdDesigner, CoverImagePath, EstimatedEndDate могут быть null
            // Они должны быть установлены в null в объекте book перед вызовом _bookRepository.Create,
            // если автор их не предоставляет.
            // book.IdEditor = null; // Если не назначается сразу
            // book.IdDesigner = null; // Если не назначается сразу
            // book.CoverImagePath = null; // Если нет обложки по умолчанию

            return _bookRepository.Create(book);
        }

        public void AssignEditor(int bookId, int editorId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null || book.State != BookState.in_progress || book.IdEditor.HasValue)
            {
                throw new InvalidOperationException("Book cannot be assigned to editor in its current state.");
            }
             _bookRepository.AssignEditor(bookId, editorId);
        }

        public void AssignDesigner(int bookId, int designerId)
        {
             var book = _bookRepository.GetById(bookId);
             if (book == null || book.State != BookState.editing || book.IdDesigner.HasValue)
             {
                 throw new InvalidOperationException("Book cannot be assigned to designer in its current state.");
             }
             _bookRepository.AssignDesigner(bookId, designerId);
        }
        
        public List<Book> GetBooksByEditor(int editorId) => _bookRepository.GetByEditor(editorId);
        
        public List<Book> GetBooksByDesigner(int designerId) => _bookRepository.GetByDesigner(designerId);

         public void UpdateCoverPath(int bookId, string relativePath)
         {
             _bookRepository.UpdateCoverPath(bookId, relativePath);
         }

        public void UpdateBookEstimate(int bookId, DateTime newEstimateDate)
        {
             var book = _bookRepository.GetById(bookId);
             if (book == null || newEstimateDate < book.StartDate)
             {
                  throw new ArgumentException("Estimated end date cannot be earlier than start date.");
             }
             _bookRepository.UpdateEstimatedEndDate(bookId, newEstimateDate);
        }

         public void UpdateBookState(int bookId, BookState newState)
         {
             _bookRepository.UpdateState(bookId, newState);
         }

        // Только для админа
        public void UpdateBook(Book book)
        {
            if (book == null || book.Id <= 0) throw new ArgumentNullException("Book data required.");
            _bookRepository.Update(book);
        }

        // Только для админа
        public void DeleteBook(int bookId)
        {
            _bookRepository.Delete(bookId);
        }
    }
}