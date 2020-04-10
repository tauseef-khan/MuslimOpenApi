using System;

namespace MuslimOpenApi.Helpers
{
    public static class DateHelper
    {
        public static string GetTodaysDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }

        public static string CreateDate(int day, int month)
        {
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            return new DateTime(year, month, day).ToString("dd-MM-yyyy");
        }

        public static bool IsMonthValid(int month)
        {
            return month >= 1 && month <= 12;
        }

        public static bool IsDayValid(int day, int month)
        {
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int numberOfDays = DateTime.DaysInMonth(year, month);

            return day >= 0 && day <= numberOfDays;
        }
    }
}
