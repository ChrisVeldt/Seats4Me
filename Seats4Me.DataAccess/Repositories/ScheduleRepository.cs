using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seats4Me.DataAccess.Context;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly Seats4MeContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ScheduleRepository(Seats4MeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the scheduled events for a given date range
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="untilDate"></param>
        /// <returns></returns>
        public async Task<List<Schedule>> GetScheduleAsync(DateTime fromDate, DateTime untilDate)
        {
            var scheduleQuery = _context.Schedules
                .Where(s => s.ScheduleDate >= fromDate && s.ScheduleDate < untilDate.AddDays(1))
                .Select(c => new Schedule
                {
                    ScheduleId = c.ScheduleId,
                    ScheduleDate = c.ScheduleDate,
                    Show = new Show
                    {
                        ShowId = c.Show.ShowId,
                        Title = c.Show.Title,
                        SubTitle = c.Show.SubTitle,
                        Price = c.Show.Price
                    }
                });
            var result = await scheduleQuery.ToListAsync();
            
            return result;
        }
    }
}
