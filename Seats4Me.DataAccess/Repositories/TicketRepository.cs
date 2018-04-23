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
    public class TicketRepository : ITicketRepository
    {
        private readonly Seats4MeContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public TicketRepository(Seats4MeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Post a ticket to the DB
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public async Task<int> PostTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Get all sold tickets for a given event
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public async Task<List<Ticket>> GetTicketsByScheduleAsync(int scheduleId)
        {
            var query = _context.Tickets.Where(t => t.ScheduleId == scheduleId);
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get the number of seats that are sold for a given event
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public async Task<int> GetSeatsSoldForScheduleAsync(int scheduleId)
        {
            return await _context.Tickets.Where(t => t.ScheduleId == scheduleId).SumAsync(s => s.Seats);
        }

    }
}
