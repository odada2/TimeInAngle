namespace TimeInAngle.Validators
{
    public static class ClockAngleValidator
    {
        public static bool ValidateTime(string time, out int hour, out int minute)
        {
            hour = 0;
            minute = 0;

            if (string.IsNullOrEmpty(time))
                return false;

            var timeParts = time.Split(':');
            if (timeParts.Length != 2 || !int.TryParse(timeParts[0], out hour) || !int.TryParse(timeParts[1], out minute))
                return false;

            return true;
        }

        public static bool ValidateHourAndMinute(int hour, int minute)
        {
            return hour >= 0 && hour <= 23 && minute >= 0 && minute <= 59;
        }
    }
}