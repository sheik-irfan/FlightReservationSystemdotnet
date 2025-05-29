//using FlightReservationSystem.Controllers;
//using FlightReservationSystem.DTOs;
//using FlightReservationSystem.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Xunit;

//namespace FlightReservationSystem.Tests
//{
//    public class ReviewControllerTests
//    {
//        private readonly Mock<IReviewService> _mockService;
//        private readonly ReviewController _controller;

//        public ReviewControllerTests()
//        {
//            _mockService = new Mock<IReviewService>();
//            _controller = new ReviewController(_mockService.Object);

//            // Set up a fake user for authentication
//            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
//            {
//                new Claim(ClaimTypes.Email, "test@example.com")
//            }, "mock"));

//            _controller.ControllerContext = new ControllerContext()
//            {
//                HttpContext = new DefaultHttpContext() { User = user }
//            };
//        }

//        [Fact]
//        public async Task GetOwnReviews_ReturnsOkResult_WithListOfReviews()
//        {
//            // Arrange
//            var expectedReviews = new List<ReviewDto>
//            {
//                new ReviewDto { Id = 1, UserEmail = "test@example.com", BookingId = 1, Rating = 4, ReviewComment = "Good", CreatedAt = DateTime.UtcNow }
//            };
//            _mockService.Setup(s => s.GetReviewsByEmail("test@example.com"))
//                .ReturnsAsync(expectedReviews);

//            // Act
//            var result = await _controller.GetOwnReviews();

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnValue = Assert.IsType<List<ReviewDto>>(okResult.Value);
//            Assert.Single(returnValue);
//        }

//        [Fact]
//        public async Task CreateReview_ReturnsCreatedAtAction_WithNewReview()
//        {
//            // Arrange
//            var createDto = new CreateReviewDto
//            {
//                BookingId = 1,
//                Rating = 5,
//                ReviewComment = "Excellent"
//            };

//            var createdReview = new ReviewDto
//            {
//                Id = 1,
//                BookingId = 1,
//                Rating = 5,
//                ReviewComment = "Excellent",
//                UserEmail = "test@example.com",
//                CreatedAt = DateTime.UtcNow
//            };

//            _mockService.Setup(s => s.CreateReview("test@example.com", createDto))
//                .ReturnsAsync(createdReview);

//            // Act
//            var result = await _controller.CreateReview(createDto);

//            // Assert
//            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
//            var returnValue = Assert.IsType<ReviewDto>(createdResult.Value);
//            Assert.Equal("test@example.com", returnValue.UserEmail);
//        }
//    }
//}
