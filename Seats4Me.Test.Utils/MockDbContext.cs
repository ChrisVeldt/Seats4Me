using System;
using Microsoft.EntityFrameworkCore;
using Seats4Me.DataAccess.Context;
using Seats4Me.Model.Result;

namespace Seats4Me.Test.Utils
{
    public class MockDbContext
    {
        public static Seats4MeContext MockSeats4MeContext()
        {
            var options = new DbContextOptionsBuilder<Seats4MeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Seats4MeContext(options);

            var showHerman = new Show
            {
                ShowId = 1,
                Title = "Herman van Veen",
                SubTitle = "Gaat maar door...",
                Price = 15.75M,
                Duration = new TimeSpan(2, 30, 0)
            };
            var showLedZep = new Show
            {
                ShowId = 2,
                Title = "Led Zep",
                Description = "The best Led Zeppelin cover band ever!",
                Price = 12.5M,
                Duration = new TimeSpan(2, 0, 0)
            };
            context.Shows.Add(showHerman);
            context.Shows.Add(showLedZep);
            context.SaveChanges();

            var scheduleHerman = new Schedule
            {
                ScheduleId = 1,
                ScheduleDate = new DateTime(2018, 4, 19, 20, 30, 0),
                Show = showHerman
            };
            context.Schedules.Add(scheduleHerman);
            var scheduleLedZep1 = new Schedule
            {
                ScheduleId = 2,
                ScheduleDate = new DateTime(2018, 4, 23, 20, 0, 0),
                Show = showLedZep
            };
            context.Schedules.Add(scheduleLedZep1);
            var scheduleLedZep2 = new Schedule
            {
                ScheduleId = 3,
                ScheduleDate = new DateTime(2018, 4, 24, 20, 0, 0),
                Show = showLedZep
            };
            context.Schedules.Add(scheduleLedZep2);
            context.SaveChanges();

            var ticketsLedZep1 = new Ticket
            {
                TicketId = 1,
                CustomerName = "Chris",
                OrderDate = new DateTime(2018, 2, 3),
                Paid = true,
                Schedule = scheduleLedZep1,
                Seats = 3
            };
            context.Tickets.Add(ticketsLedZep1);
            context.SaveChanges();

            return context;
        }
    }
}