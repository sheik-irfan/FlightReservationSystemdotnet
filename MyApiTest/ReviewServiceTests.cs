using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using FlightReservationSystem.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Tests.Services
{
    [TestClass]
    public class ReviewServiceTests
    {
        private Mock<IReviewRepository> _mockRepo;
        private Mock<IMapper> _mockMapper;
        private ReviewService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IReviewRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new ReviewService(_mockRepo.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task CreateReviewAsync_ReturnsMappedDto()
        {
            // Arrange
            var createDto = new CreateReviewDto { BookingId = 1, Rating = 4.5M, ReviewComment = "Good flight" };
            var review = new Review { BookingId = 1, Rating = 4.5M, ReviewComment = "Good flight", UserEmail = "test@example.com" };
            var savedReview = new Review { Id = 1, BookingId = 1, Rating = 4.5M, ReviewComment = "Good flight", UserEmail = "test@example.com", CreatedAt = DateTime.UtcNow };
            var expectedDto = new ReviewDto { Id = 1, BookingId = 1, Rating = 4.5M, ReviewComment = "Good flight", UserEmail = "test@example.com", CreatedAt = savedReview.CreatedAt };

            _mockMapper.Setup(m => m.Map<Review>(createDto)).Returns(review);
            _mockRepo.Setup(r => r.AddReviewAsync(It.IsAny<Review>())).ReturnsAsync(savedReview);
            _mockMapper.Setup(m => m.Map<ReviewDto>(savedReview)).Returns(expectedDto);

            // Act
            var result = await _service.CreateReviewAsync(createDto, "test@example.com");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDto.Id, result.Id);
            Assert.AreEqual(expectedDto.UserEmail, result.UserEmail);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsMappedList()
        {
            var reviews = new List<Review> { new Review { Id = 1 }, new Review { Id = 2 } };
            var expectedDtos = new List<ReviewDto> { new ReviewDto { Id = 1 }, new ReviewDto { Id = 2 } };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(reviews);
            _mockMapper.Setup(m => m.Map<IEnumerable<ReviewDto>>(reviews)).Returns(expectedDtos);

            var result = await _service.GetAllAsync();

            Assert.AreEqual(2, (result as List<ReviewDto>).Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsMappedDto()
        {
            var review = new Review { Id = 1 };
            var expectedDto = new ReviewDto { Id = 1 };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(review);
            _mockMapper.Setup(m => m.Map<ReviewDto>(review)).Returns(expectedDto);

            var result = await _service.GetByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result?.Id);
        }

        [TestMethod]
        public async Task GetByUserEmailAsync_ReturnsMappedList()
        {
            var reviews = new List<Review> { new Review { Id = 1 }, new Review { Id = 2 } };
            var expectedDtos = new List<ReviewDto> { new ReviewDto { Id = 1 }, new ReviewDto { Id = 2 } };

            _mockRepo.Setup(r => r.GetByUserEmailAsync("user@example.com")).ReturnsAsync(reviews);
            _mockMapper.Setup(m => m.Map<IEnumerable<ReviewDto>>(reviews)).Returns(expectedDtos);

            var result = await _service.GetByUserEmailAsync("user@example.com");

            Assert.AreEqual(2, (result as List<ReviewDto>).Count);
        }

        [TestMethod]
        public async Task UpdateReviewAsync_ReturnsFalse_IfNotFound()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Review?)null);

            var result = await _service.UpdateReviewAsync(1, new ReviewDto(), "user@example.com");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task UpdateReviewAsync_ReturnsFalse_IfEmailMismatch()
        {
            var review = new Review { Id = 1, UserEmail = "other@example.com" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(review);

            var result = await _service.UpdateReviewAsync(1, new ReviewDto(), "user@example.com");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task UpdateReviewAsync_ReturnsTrue_OnSuccess()
        {
            var review = new Review { Id = 1, UserEmail = "user@example.com" };
            var dto = new ReviewDto { BookingId = 1, Rating = 4.0M, ReviewComment = "Updated review" };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(review);

            var result = await _service.UpdateReviewAsync(1, dto, "user@example.com");

            _mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Review>()), Times.Once);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteReviewAsync_ReturnsFalse_IfNotFound()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Review?)null);

            var result = await _service.DeleteReviewAsync(1, "user@example.com");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task DeleteReviewAsync_ReturnsFalse_IfEmailMismatch()
        {
            var review = new Review { Id = 1, UserEmail = "other@example.com" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(review);

            var result = await _service.DeleteReviewAsync(1, "user@example.com");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task DeleteReviewAsync_ReturnsTrue_OnSuccess()
        {
            var review = new Review { Id = 1, UserEmail = "user@example.com" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(review);

            var result = await _service.DeleteReviewAsync(1, "user@example.com");

            _mockRepo.Verify(r => r.DeleteAsync(review), Times.Once);
            Assert.IsTrue(result);
        }
    }
}
