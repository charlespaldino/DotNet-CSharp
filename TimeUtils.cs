using System;

namespace Utils
{
    public static class TimeUtils
    {
        public static DateTime getPreviousDay()
        {
             return DateTime.Now.AddDays(-1);
        }
        public static DateTime getPreviousWeekDay()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return DateTime.Now.AddDays(-3);
                case DayOfWeek.Sunday:
                    return DateTime.Now.AddDays(-2);
                default:
                    return DateTime.Now.AddDays(-1);
            }
        }
        public static DateTime getPreviousSunday()
        {
            return DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - DayOfWeek.Monday)).AddDays(-1);
        }
        public static DateTime getPreviousMonday()
        {
            return DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek - DayOfWeek.Monday));
        }
    }
}
