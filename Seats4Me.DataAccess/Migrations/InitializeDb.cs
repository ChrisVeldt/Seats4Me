using System;
using System.Linq;
using Seats4Me.DataAccess.Context;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Migrations
{
    public static class InitializeDb
    {
        public static void Seed(Seats4MeContext context)
        {
            if (!context.Shows.Any())
            {
                var shows = new Show[]
                {
                    new Show
                    {
                        Title = "Herman van Veen",
                        SubTitle = "Gaat maar door...",
                        Price = 15.75M,
                        Duration = new TimeSpan(2, 30, 0)
                    },
                    new Show
                    {
                        Title = "Led Zep",
                        Description = "The best Led Zeppelin cover band ever!",
                        Price = 12.5M,
                        Duration = new TimeSpan(2, 0, 0)
                    }
                };

                foreach (var show in shows)
                {
                    context.Shows.Add(show);
                }

                context.SaveChanges();
            }

            if (!context.Schedules.Any())
            {
                var show = context.Shows.FirstOrDefault(s => s.Title == "Herman van Veen");
                var schedule = new Schedule {ScheduleDate = new DateTime(2018, 4, 19, 20, 30, 0), Show = show};
                context.Schedules.Add(schedule);

                show = context.Shows.FirstOrDefault(s => s.Title == "Led Zep");
                schedule = new Schedule { ScheduleDate = new DateTime(2018, 4, 23, 20, 0, 0), Show = show};
                context.Schedules.Add(schedule);

                context.SaveChanges();
            }
        }
    }
}