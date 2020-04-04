using System;

namespace MuslimOpenApi.Helpers
{
    public static class DateHelper
    {
        public static string GetTodaysDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}
