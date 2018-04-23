using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Seats4Me.DataAccess.Context;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.DataAccess.Repositories;
using Seats4Me.Model.Result;
using Seats4Me.Test.Utils;
using Xunit;

namespace Seats4Me.DataAccess.Test
{
    public class TicketRepositoryTests
    {
        [Fact]
        public async void EnterNewTicketTestAsync()
        {
            var repository = new TicketRepository(MockDbContext.MockSeats4MeContext());
            var ticket = new Ticket()
            {
                TicketId = 2,
                CustomerName = "Marijke",
                OrderDate = DateTime.Today,
                Paid = false,
                Schedule = new Schedule {ScheduleId = 1},
                Seats = 4
            };

            var result = await repository.PostTicketAsync(ticket);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }

        [Fact]
        public async void GetAllTicketsForAScheduleTestAsync()
        {
            var repository = new TicketRepository(MockDbContext.MockSeats4MeContext());

            var result = await repository.GetTicketsByScheduleAsync(2);

            Assert.IsType<List<Ticket>>(result);
        }

        [Fact]
        public async void GetSumOfTicketsForAScheduleTestAsync()
        {
            var repository = new TicketRepository(MockDbContext.MockSeats4MeContext());

            var result = await repository.GetSeatsSoldForScheduleAsync(2);

            Assert.Equal(3, result);
        }
    }
}
