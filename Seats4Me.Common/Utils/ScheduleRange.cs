using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Seats4Me.Common.Enum;
using Seats4Me.Common.Extensions;

namespace Seats4Me.Common.Utils
{
    public static class ScheduleRange
    {
        /// <summary>
        /// Translate a period and date to from- and to-date.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="periodDate"></param>
        /// <returns></returns>
        public static (ScheduleRangePeriod period, DateTime from, DateTime until) GetRange(string period, DateTime? periodDate)
        {
            DateTime fromDate;
            DateTime untilDate;

            System.Enum.TryParse<ScheduleRangePeriod>(period, true, out var schedulePeriod);
            var from = periodDate ?? DateTime.Today;

            switch (schedulePeriod)
            {
                case ScheduleRangePeriod.Week:
                    fromDate = from.FirstDateOfWeek();
                    untilDate = from.LastDateOfWeek();
                    break;
                case ScheduleRangePeriod.Month:
                    fromDate = from.FirstDateOfMonth();
                    untilDate = from.LastDateOfMonth();
                    break;
                case ScheduleRangePeriod.Year:
                    fromDate = from.FirstDateOfYear();
                    untilDate = from.LastDateOfYear();
                    break;
                case ScheduleRangePeriod.All:
                    fromDate = from;
                    untilDate = DateTime.MaxValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }

            return (schedulePeriod, fromDate, untilDate);
        }

        /// <summary>
        /// Get the from-and to-date previous to the given period and date.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="periodDate"></param>
        /// <returns></returns>
        public static (ScheduleRangePeriod period, DateTime from, DateTime until) GetPreviousRange(string period, DateTime? periodDate)
        {
            var range = GetRange(period, periodDate);
            if (range.from == DateTime.MinValue || range.period == ScheduleRangePeriod.All)
            {
                return range;
            }
            return GetRange(range.period.ToString(), range.from.AddDays(-1));
        }

        /// <summary>
        /// Get the from-and to-date next after the given period and date.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="periodDate"></param>
        /// <returns></returns>
        public static (ScheduleRangePeriod period, DateTime from, DateTime until) GetNextRange(string period, DateTime? periodDate)
        {
            var range = GetRange(period, periodDate);
            if (range.until == DateTime.MaxValue || range.period == ScheduleRangePeriod.All)
            {
                return range;
            }
            return GetRange(range.period.ToString(), range.until.AddDays(1));
        }

    }
}
