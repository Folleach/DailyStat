using System;

namespace DailyStat
{
    public static class Extensions
    {
        public static string CreateYearDayValue(this DateTime dateTime)
        {
            return $"{dateTime.Year}/{dateTime.DayOfYear}";
        }
    }
}
