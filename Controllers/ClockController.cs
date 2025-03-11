using Microsoft.AspNetCore.Mvc;
using TimeInAngle.Services;
using TimeInAngle.Validators;

namespace TimeInAngle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClockController : ControllerBase
    {
        private readonly ClockAngleService _clockAngleService;

        public ClockController(ClockAngleService clockAngleService)
        {
            _clockAngleService = clockAngleService;
        }

        [HttpGet("CalculateTimeAngle")]
        public IActionResult CalculateTimeAngle([FromQuery] string? time = null, [FromQuery] int? hour = null, [FromQuery] int? minute = null)
        {
            try
            {
                // Parse time if provided
                if (!string.IsNullOrEmpty(time))
                {
                    if (!ClockAngleValidator.ValidateTime(time, out int parsedHour, out int parsedMinute))
                    {
                        return BadRequest("Invalid time format. Use 'hh:mm'.");
                    }
                    hour = parsedHour;
                    minute = parsedMinute;
                }

                // Validate hour and minute
                if (hour == null || minute == null || !ClockAngleValidator.ValidateHourAndMinute(hour.Value, minute.Value))
                {
                    return BadRequest("Invalid hour or minute values.");
                }

                // Calculate the angle using the service
                double totalAngle = _clockAngleService.CalculateTimeAngle(hour.Value, minute.Value);

                return Ok(new { TotalAngle = totalAngle });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}