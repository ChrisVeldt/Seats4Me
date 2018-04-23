using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.Common.Utils;
using Seats4Me.DataAccess.Interfaces;
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
            var scheduleId = ticket.Schedule.ScheduleId;
            var seats = await _repository.GetSeatsSoldForScheduleAsync(scheduleId);

            var totalSeats = _config.TotalSeats;
            if (seats + ticket.Seats > totalSeats)
            {
                return 0;
            }

            return await _repository.PostTicketAsync(ticket);
        }

    }
}
