using Xunit;
using TimeInAngle.Services;

namespace TimeInAngle.Tests
{
    public class ClockAngleServiceTests
    {
        private readonly ClockAngleService _clockAngleService;

        public ClockAngleServiceTests()
        {
            _clockAngleService = new ClockAngleService();
        }

        [Theory]
        [InlineData(3, 0, 90)]   // 3:00 -> 90 degrees
        [InlineData(6, 0, 180)]  // 6:00 -> 180 degrees
        [InlineData(9, 0, 270)]  // 9:00 -> 270 degrees
        [InlineData(12, 0, 0)]   // 12:00 -> 0 degrees
        [InlineData(3, 30, 285)] // 3:30 -> 285 degrees
        public void CalculateTimeAngle_ValidInput_ReturnsCorrectAngle(int hour, int minute, double expectedAngle)
        {
            // Act
            var result = _clockAngleService.CalculateTimeAngle(hour, minute);

            // Assert
            Assert.Equal(expectedAngle, result);
        }

        [Theory]
        [InlineData(-1, 0)]  // Invalid hour
        [InlineData(24, 0)]  // Invalid hour
        [InlineData(0, -1)]  // Invalid minute
        [InlineData(0, 60)]  // Invalid minute
        public void CalculateTimeAngle_InvalidInput_ThrowsException(int hour, int minute)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _clockAngleService.CalculateTimeAngle(hour, minute));
        }
    }
}