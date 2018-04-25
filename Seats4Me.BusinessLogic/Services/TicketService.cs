using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.Common.Utils;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.DataAccess.Repositories;
using Seats4Me.Model.Result;

namespace Seats4Me.BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly Seats4MeConfiguration _config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="config"></param>
        public TicketService(ITicketRepository repository, Seats4MeConfiguration config)
        {
            _config = config;
            _repository = repository;
        }

        /// <summary>
        /// Post a ticket to the DB
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public async Task<int> EnterTicketAsync(Ticket ticket)
        {
            var seats = await _repository.GetSeatsSoldForScheduleAsync(ticket.ScheduleId);
            var totalSeats = _config.TotalSeats;

            if (seats + ticket.Seats > totalSeats)
            {
                return 0;
            }
            return await _repository.PostTicketAsync(ticket);
        }

        public async Task<List<Ticket>> GetTicketsForAScheduleAsync(int scheduleId)
        {
            var result = await _repository.GetTicketsByScheduleAsync(scheduleId);
            if (result == null)
            {
                result = new List<Ticket>();
            }

            return result;
        }

    }
}
