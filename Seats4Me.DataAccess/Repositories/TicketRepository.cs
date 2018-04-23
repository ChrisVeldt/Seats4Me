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

        public TicketRepository(Seats4MeContext context)
        {
            _context = context;
        }

        public async Task<int> PostTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Ticket>> GetTicketsByScheduleAsync(int scheduleId)
        {
            var query = _context.Tickets.Where(t => t.ScheduleId == scheduleId);
            return await query.ToListAsync();
        }

        public async Task<int> GetSeatsSoldForScheduleAsync(int scheduleId)
        {
            return await _context.Tickets.Where(t => t.ScheduleId == scheduleId).SumAsync(s => s.Seats);
        }

    }
}
