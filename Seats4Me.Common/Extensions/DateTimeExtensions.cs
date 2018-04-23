using System;
using System.Collections.Generic;
using System.Text;

namespace Seats4Me.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDateOfWeek(this DateTime dateInWeek)
        {
            var dayDiff = (7 + (dateInWeek.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dateInWeek.AddDays(-dayDiff);
        }

        public static DateTime LastDateOfWeek(this DateTime dateInWeek)
        {
            var dayDiff = (7 + (DayOfWeek.Sunday - dateInWeek.DayOfWeek)) % 7;
            return dateInWeek.AddDays(dayDiff);
        }

        public static DateTime FirstDateOfMonth(this DateTime dateInMonth)
        {
            return new DateTime(dateInMonth.Year, dateInMonth.Month, 1);
        }

        public static DateTime LastDateOfMonth(this DateTime dateInMonth)
        {
            var year = dateInMonth.Year;
            var month = dateInMonth.Month;
            return (new DateTime(year, month, 1)).AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDateOfYear(this DateTime dateInYear)
        {
            return new DateTime(dateInYear.Year, 1, 1);
        }

        public static DateTime LastDateOfYear(this DateTime dateInYear)
        {
            var year = dateInYear.Year;
            return (new DateTime(year, 1, 1)).AddYears(1).AddDays(-1);
        }
    }
}
