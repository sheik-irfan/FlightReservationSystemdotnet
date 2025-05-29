using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using FlightReservationSystem.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Tests.Services
{
    [TestClass]
    public class AirplaneServiceTests
    {
        private Mock<IAirplaneRepository> _mockRepo;
        private Mock<IMapper> _mockMapper;
        private Mock<ILogger<AirplaneService>> _mockLogger;
        private AirplaneService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IAirplaneRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<AirplaneService>>();
            _service = new AirplaneService(_mockRepo.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsMappedList()
        {
            // Arrange
            var airplanes = new List<Airplanes> { new Airplanes { Id = 1 }, new Airplanes { Id = 2 } };
            var expectedDtos = new List<AirplaneDto> { new AirplaneDto { Id = 1 }, new AirplaneDto { Id = 2 } };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(airplanes);
            _mockMapper.Setup(m => m.Map<List<AirplaneDto>>(airplanes)).Returns(expectedDtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsDto_IfExists()
        {
            var airplane = new Airplanes { Id = 1 };
            var expectedDto = new AirplaneDto { Id = 1 };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(airplane);
            _mockMapper.Setup(m => m.Map<AirplaneDto>(airplane)).Returns(expectedDto);

            var result = await _service.GetByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result?.Id);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsNull_IfNotFound()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Airplanes?)null);

            var result = await _service.GetByIdAsync(999);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task CreateAsync_ReturnsMappedDto()
        {
            var createDto = new AirplaneCreateDto { Model = "Boeing", TotalSeats = 150 };
            var airplane = new Airplanes { Id = 1, Model = "Boeing", TotalSeats = 150 };
            var expectedDto = new AirplaneDto { Id = 1, Model = "Boeing", TotalSeats = 150 };

            _mockMapper.Setup(m => m.Map<Airplanes>(createDto)).Returns(airplane);
            _mockRepo.Setup(r => r.CreateAsync(airplane)).ReturnsAsync(airplane);
            _mockMapper.Setup(m => m.Map<AirplaneDto>(airplane)).Returns(expectedDto);

            var result = await _service.CreateAsync(createDto);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Boeing", result.Model);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsFalse_IfNotFound()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Airplanes?)null);

            var result = await _service.UpdateAsync(1, new AirplaneUpdateDto());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsTrue_IfUpdated()
        {
            var airplane = new Airplanes { Id = 1 };
            var updateDto = new AirplaneUpdateDto { Model = "Airbus", TotalSeats = 180 };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(airplane);
            _mockRepo.Setup(r => r.UpdateAsync(airplane)).ReturnsAsync(true);
            _mockMapper.Setup(m => m.Map(updateDto, airplane)).Verifiable();

            var result = await _service.UpdateAsync(1, updateDto);

            Assert.IsTrue(result);
            _mockMapper.Verify();
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsTrue_IfDeleted()
        {
            _mockRepo.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

            var result = await _service.DeleteAsync(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsFalse_IfNotFound()
        {
            _mockRepo.Setup(r => r.DeleteAsync(999)).ReturnsAsync(false);

            var result = await _service.DeleteAsync(999);

            Assert.IsFalse(result);
        }
    }
}
