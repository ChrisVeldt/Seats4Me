using System;
using Seats4Me.Common.Extensions;
using Xunit;

namespace Seats4Me.Common.Test
{
    public class DateTimeExtensionTest
    {
        [Fact]
        public void FirstDayOfWeekTest1()
        {
            var result = new DateTime(2018, 4, 19).FirstDateOfWeek();

            Assert.Equal(new DateTime(2018, 4, 16), result);
        }

        [Fact]
        public void FirstDayOfWeekTest2()
        {
            var result = new DateTime(2018, 4, 22).FirstDateOfWeek();

            Assert.Equal(new DateTime(2018, 4, 16), result);
        }

        [Fact]
        public void LastDayOfWeekTest1()
        {
            var result = new DateTime(2018, 4, 19).LastDateOfWeek();

            Assert.Equal(new DateTime(2018, 4, 22), result);
        }

        [Fact]
        public void LastDayOfWeekTest2()
        {
            var result = new DateTime(2018, 4, 22).LastDateOfWeek();

            Assert.Equal(new DateTime(2018, 4, 22), result);
        }

        [Fact]
        public void FirstDayOfMonthTest()
        {
            var result = new DateTime(2018, 4, 19).FirstDateOfMonth();

            Assert.Equal(new DateTime(2018, 4, 1), result);
        }

        [Fact]
        public void LastDayOfMonthTest()
        {
            var result = new DateTime(2018, 4, 19).LastDateOfMonth();

            Assert.Equal(new DateTime(2018, 4, 30), result);
        }

        [Fact]
        public void FirstDayOfYearTest()
        {
            var result = new DateTime(2018, 4, 19).FirstDateOfYear();

            Assert.Equal(new DateTime(2018, 1, 1), result);
        }

        [Fact]
        public void LastDayOfYearTest()
        {
            var result = new DateTime(2018, 4, 19).LastDateOfYear();

            Assert.Equal(new DateTime(2018, 12, 31), result);
        }
    }
}
