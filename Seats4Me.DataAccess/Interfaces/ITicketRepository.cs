using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Interfaces
{
    public interface ITicketRepository
    {
        Task<int> PostTicketAsync(Ticket ticket);
        Task<List<Ticket>> GetTicketsByScheduleAsync(int scheduleId);
        Task<int> GetSeatsSoldForScheduleAsync(int scheduleId);
    }
}
