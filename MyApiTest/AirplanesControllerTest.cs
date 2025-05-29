using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FlightReservationSystem.Controllers;
using FlightReservationSystem.Services;
using FlightReservationSystem.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Tests
{
    [TestClass]
    public class AirplanesControllerTests
    {
        private Mock<IAirplaneService> _mockService;
        private AirplanesController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<IAirplaneService>();
            _controller = new AirplanesController(_mockService.Object);
        }

        [TestMethod]
        public async Task GetAll_ReturnsOkWithList()
        {
            // Arrange
            var mockList = new List<AirplaneDto>
            {
                new AirplaneDto { Id = 1, Model = "Boeing 737", TotalSeats = 180 },
                new AirplaneDto { Id = 2, Model = "Airbus A320", TotalSeats = 160 }
            };

            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(mockList);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var data = okResult.Value as List<AirplaneDto>;
            Assert.AreEqual(2, data.Count);
        }

        [TestMethod]
        public async Task GetById_ReturnsNotFound_IfAirplaneNotFound()
        {
            // Arrange
            _mockService.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((AirplaneDto?)null);

            // Act
            var result = await _controller.GetById(99);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetById_ReturnsOk_IfAirplaneFound()
        {
            // Arrange
            var airplane = new AirplaneDto { Id = 1, Model = "Boeing 747", TotalSeats = 400 };
            _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(airplane);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(airplane, okResult.Value);
        }

        [TestMethod]
        public async Task Create_ReturnsCreatedAtAction()
        {
            // Arrange
            var createDto = new AirplaneCreateDto { Model = "Boeing 787", TotalSeats = 250 };
            var resultDto = new AirplaneDto { Id = 3, Model = "Boeing 787", TotalSeats = 250 };

            _mockService.Setup(s => s.CreateAsync(createDto)).ReturnsAsync(resultDto);

            // Act
            var result = await _controller.Create(createDto);

            // Assert
            var createdAt = result.Result as CreatedAtActionResult;
            Assert.IsNotNull(createdAt);
            Assert.AreEqual("GetById", createdAt.ActionName);
            Assert.AreEqual(resultDto, createdAt.Value);
        }

        [TestMethod]
        public async Task Update_ReturnsNoContent_OnSuccess()
        {
            // Arrange
            var updateDto = new AirplaneUpdateDto { Model = "Updated Model", TotalSeats = 300 };
            _mockService.Setup(s => s.UpdateAsync(1, updateDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.Update(1, updateDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task Update_ReturnsNotFound_OnFailure()
        {
            // Arrange
            var updateDto = new AirplaneUpdateDto { Model = "Fail Model", TotalSeats = 0 };
            _mockService.Setup(s => s.UpdateAsync(99, updateDto)).ReturnsAsync(false);

            // Act
            var result = await _controller.Update(99, updateDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Delete_ReturnsNoContent_OnSuccess()
        {
            _mockService.Setup(s => s.DeleteAsync(1)).ReturnsAsync(true);

            var result = await _controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFound_OnFailure()
        {
            _mockService.Setup(s => s.DeleteAsync(99)).ReturnsAsync(false);

            var result = await _controller.Delete(99);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
