using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using Seats4Me.DataAccess.Context;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.DataAccess.Repositories;
using Seats4Me.Model.Result;
using Seats4Me.Test.Utils;
using Xunit;

namespace Seats4Me.DataAccess.Test
{
    public class ScheduleRepositoryTests
    {
        [Fact]
        public async void GetScheduleAsync()
        {
            var repository = new ScheduleRepository(MockDbContext.MockSeats4MeContext());

            var result = await repository.GetScheduleAsync(new DateTime(2018, 4, 16), new DateTime(2018, 4, 23));

            Assert.IsType<List<Schedule>>(result);
            Assert.Equal(2, result.Count);
        }

    }
}
