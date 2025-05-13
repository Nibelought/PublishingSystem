using PublishingSystem.DAL;
using PublishingSystem.Models;
using System;
using System.Collections.Generic;

namespace PublishingSystem.BLL
{
    public class ReviewService
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewService()
        {
            _reviewRepository = new ReviewRepository();
        }

        public Review GetReviewById(int id) => _reviewRepository.GetById(id);
        public List<Review> GetAllReviews() => _reviewRepository.GetAll();
        public List<Review> GetReviewsByBook(int bookId) => _reviewRepository.GetByBookId(bookId);
        public List<Review> GetReviewsByCritic(int criticId) => _reviewRepository.GetByCriticId(criticId);


        public int AddReview(Review review)
        {
            if (review.IdCritic <= 0 || review.IdBook <= 0 || string.IsNullOrWhiteSpace(review.RtfText) ||
                review.GradeBook < 0 || review.GradeBook > 10 || review.GradeBook % 0.5m != 0 ||
                review.GradeCover < 0 || review.GradeCover > 10 || review.GradeCover % 0.5m != 0)
            {
                throw new ArgumentException("Invalid review data.");
            }
            review.DateTime = DateTime.Now;
            return _reviewRepository.Create(review);
        }

        // Только для админа
        public void DeleteReview(int reviewId)
        {
            _reviewRepository.Delete(reviewId);
        }

    }
}