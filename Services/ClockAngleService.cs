namespace TimeInAngle.Services
{
    public class ClockAngleService
    {
        public double CalculateTimeAngle(int hour, int minute)
        {
            // Normalize hour to 12-hour format
            hour = hour % 12;

            // Calculate angles
            double minuteAngle = minute * 6; // 360 degrees / 60 minutes = 6 degrees per minute
            double hourAngle = (hour * 30) + (minute * 0.5); // 360 degrees / 12 hours = 30 degrees per hour, 0.5 degrees per minute

            // Sum the angles
            return hourAngle + minuteAngle;
        }
    }
}