using System;
using System.Collections.Generic;
using System.Text;
using Seats4Me.Test.Utils;
using Xunit;
using Seats4Me.DataAccess.Repositories;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Test
{
    public class ShowRepositoryTests
    {
        [Fact]
        public async void GetShowTest()
        {
            var repository = new ShowRepository(MockDbContext.MockSeats4MeContext());

            var result = await repository.GetShowAsync(2);

            Assert.IsType<Show>(result);
        }
    }
}
