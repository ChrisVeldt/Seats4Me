using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seats4Me.Model.Result;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seats4Me.DataAccess.Context;
using Seats4Me.DataAccess.Interfaces;

namespace Seats4Me.DataAccess.Repositories
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TicketRepository(Seats4MeContext context) : base(context)
        {
        }

        /// <summary>
        /// Post a ticket to the DB
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public async Task<int> PostTicketAsync(Ticket ticket)
        {
            Context.Tickets.Add(ticket);
            return await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all sold tickets for a given event
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public async Task<List<Ticket>> GetTicketsByScheduleAsync(int scheduleId)
        {
            var query = Context.Tickets.Where(t => t.ScheduleId == scheduleId);
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get the number of seats that are sold for a given event
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public async Task<int> GetSeatsSoldForScheduleAsync(int scheduleId)
        {
            return await Context.Tickets.Where(t => t.ScheduleId == scheduleId).SumAsync(s => s.Seats);
        }

    }
}
