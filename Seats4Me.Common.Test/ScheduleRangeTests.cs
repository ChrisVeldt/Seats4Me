using System;
using System.Collections.Generic;
using System.Text;
using Seats4Me.Common.Enum;
using Seats4Me.Common.Utils;
using Xunit;

namespace Seats4Me.Common.Test
{
    public class ScheduleRangeTests
    {
        [Fact]
        public void WeekRangeTest()
        {
            var range = ScheduleRange.GetRange("week", new DateTime(2018, 4, 19));

            Assert.Equal(ScheduleRangePeriod.Week, range.period);
            Assert.Equal(new DateTime(2018, 4, 16), range.from);
            Assert.Equal(new DateTime(2018, 4, 22), range.until);
        }

        [Fact]
        public void GetPreviousRangeWeekTest()
        {
            var range = ScheduleRange.GetPreviousRange("week", new DateTime(2018, 4, 19));

            Assert.Equal(ScheduleRangePeriod.Week, range.period);
            Assert.Equal(new DateTime(2018, 4, 9), range.from);
            Assert.Equal(new DateTime(2018, 4, 15), range.until);
        }

        [Fact]
        public void GetNextRangeWeekTest()
        {
            var range = ScheduleRange.GetNextRange("week", new DateTime(2018, 4, 19));

            Assert.Equal(ScheduleRangePeriod.Week, range.period);
            Assert.Equal(new DateTime(2018, 4, 23), range.from);
            Assert.Equal(new DateTime(2018, 4, 29), range.until);
        }

        [Fact]
        public void GetPreviousRangeMonthTest()
        {
            var range = ScheduleRange.GetPreviousRange("month", new DateTime(2018, 4, 19));

            Assert.Equal(ScheduleRangePeriod.Month, range.period);
            Assert.Equal(new DateTime(2018, 3, 1), range.from);
            Assert.Equal(new DateTime(2018, 3, 31), range.until);
        }

        [Fact]
        public void GetNextRangeMonthTest()
        {
            var range = ScheduleRange.GetNextRange("month", new DateTime(2018, 4, 19));

            Assert.Equal(ScheduleRangePeriod.Month, range.period);
            Assert.Equal(new DateTime(2018, 5, 1), range.from);
            Assert.Equal(new DateTime(2018, 5, 31), range.until);
        }

        [Fact]
        public void GetPreviousRangeAllTest()
        {
            var range = ScheduleRange.GetPreviousRange("all", new DateTime(2018, 4, 19));

            Assert.Equal(ScheduleRangePeriod.All, range.period);
            Assert.Equal(new DateTime(2018, 4, 19), range.from);
            Assert.Equal(DateTime.MaxValue, range.until);
        }

        [Fact]
        public void GetNextRangeAllTest()
        {
            var range = ScheduleRange.GetNextRange("all", new DateTime(2018, 4, 19));

            Assert.Equal(ScheduleRangePeriod.All, range.period);
            Assert.Equal(new DateTime(2018, 4, 19), range.from);
            Assert.Equal(DateTime.MaxValue, range.until);
        }

    }
}
