using Microsoft.AspNetCore.Mvc;
using Moq;
using TimeInAngle.Controllers;
using TimeInAngle.Services;
using Xunit;

namespace TimeInAngle.Tests
{
    public class ClockControllerTests
    {
        private readonly Mock<ClockAngleService> _mockClockAngleService;
        private readonly ClockController _clockController;

        public ClockControllerTests()
        {
            _mockClockAngleService = new Mock<ClockAngleService>();
            _clockController = new ClockController(_mockClockAngleService.Object);
        }

        [Theory]
        [InlineData("3:00", 90)]   // 3:00 -> 90 degrees
        [InlineData("6:00", 180)]  // 6:00 -> 180 degrees
        [InlineData("9:00", 270)]  // 9:00 -> 270 degrees
        [InlineData("12:00", 0)]   // 12:00 -> 0 degrees
        [InlineData("3:30", 285)]  // 3:30 -> 285 degrees
        public void CalculateTimeAngle_ValidInput_ReturnsOkResult(string time, double expectedAngle)
        {
            // Arrange
            _mockClockAngleService.Setup(service => service.CalculateTimeAngle(It.IsAny<int>(), It.IsAny<int>()))
                                 .Returns(expectedAngle);

            // Act
            var result = _clockController.CalculateTimeAngle(time);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var angle = Assert.IsType<double>(((dynamic)okResult.Value).TotalAngle);
            Assert.Equal(expectedAngle, angle);
        }

        [Theory]
        [InlineData("invalid")]  // Invalid time format
        [InlineData("25:00")]   // Invalid hour
        [InlineData("12:60")]   // Invalid minute
        public void CalculateTimeAngle_InvalidInput_ReturnsBadRequest(string time)
        {
            // Act
            var result = _clockController.CalculateTimeAngle(time);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}