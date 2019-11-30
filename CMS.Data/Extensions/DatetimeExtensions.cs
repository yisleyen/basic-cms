using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public static partial class Extensions
    {
        public static string GetMonthName(this DateTime date, string cultureInfoName)
        {
            string monthName = date.ToString("MMMM", CultureInfo.CreateSpecificCulture(cultureInfoName));
            return monthName;
        }

        public static string GetDayName(this DayOfWeek dayOfWeek, string cultureInfoName)
        {
            CultureInfo culture = new CultureInfo(cultureInfoName);
            string dayName = culture.DateTimeFormat.GetDayName(dayOfWeek);
            return dayName;
        }

        public static int GetQuarter(this DateTime date)
        {
            int[] quarters = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4 };
            return quarters[date.Month - 1];
        }

    }
}
