using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Seats4Me.BusinessLogic.Services;
using Seats4Me.Common.Utils;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.DataAccess.Repositories;
using Seats4Me.Model.Result;
using Xunit;
using Seats4Me.Test.Utils;

namespace Seats4Me.BusinessLogic.Test
{
    public class TicketServiceTests
    {
        [Fact]
        public async void EnterTicketTestAsync()
        {
            var repository = new TicketRepository(MockDbContext.MockSeats4MeContext());
            var config = new Seats4MeConfiguration {TotalSeats = 150};
            var service = new TicketService(repository, config);
            var ticket = new Ticket
            {
                TicketId = 2,
                CustomerName = "Marijke",
                OrderDate = new DateTime(2018, 2, 1),
                Paid = true,
                Schedule = new Schedule {ScheduleId = 1}
            };

            var result = await service.EnterTicketAsync(ticket);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }

        [Fact]
        public async void CannotEnterMoreTicketsThanAvailableSeatsTestAsync()
        {
            // Arrange
            var repository = new TicketRepository(MockDbContext.MockSeats4MeContext());
            var config = new Seats4MeConfiguration { TotalSeats = 150 };
            var service = new TicketService(repository, config);
            var ticket1 = new Ticket
            {
                TicketId = 2,
                CustomerName = "Marijke",
                OrderDate = new DateTime(2018, 2, 1),
                Paid = true,
                ScheduleId =  1,
                Seats = 10
            };
            var ticket2 = new Ticket
            {
                TicketId = 3,
                CustomerName = "Marijke",
                OrderDate = new DateTime(2018, 2, 1),
                Paid = true,
                ScheduleId = 2,
                Seats = 141
            };
            var ticket3 = new Ticket
            {
                TicketId = 4,
                CustomerName = "Marijke",
                OrderDate = new DateTime(2018, 2, 1),
                Paid = true,
                ScheduleId = 1,
                Seats = 141
            };

            // Act
            var result1 = await service.EnterTicketAsync(ticket1);
            var result2 = await service.EnterTicketAsync(ticket2);
            var result3 = await service.EnterTicketAsync(ticket3);

            // Assert
            Assert.True(result1 > 0);
            Assert.True(result2 > 0);
            Assert.Equal(0, result3);
        }

        [Fact]
        public async void GetTicketsForAScheduleTestAsync()
        {
            var repository = new TicketRepository(MockDbContext.MockSeats4MeContext());
            var config = new Seats4MeConfiguration { TotalSeats = 150 };
            var service = new TicketService(repository, config);

            var result = await service.GetTicketsForAScheduleAsync(2);

            Assert.IsType<List<Ticket>>(result);
            Assert.All(result, t => Assert.Contains("Chris", t.CustomerName));
        }
    }
}
