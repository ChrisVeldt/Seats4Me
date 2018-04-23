using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.Common.interfaces;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.Model.Result;

namespace Seats4Me.BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly ISeats4MeConfiguration _config;

        public TicketService(ITicketRepository repository, ISeats4MeConfiguration config)
        {
            _config = config;
            _repository = repository;
        }

        public async Task<int> EnterTicketAsync(Ticket ticket)
        {
            int result;

            using (var scope = new TransactionScope())
            {
                result = await _repository.PostTicketAsync(ticket);

                var scheduleId = ticket.Schedule.ScheduleId;
                var seats = await _repository.GetSeatsSoldForScheduleAsync(scheduleId);

                var totalSeats = _config.TotalSeats;
                if (seats > totalSeats)
                {
                    result = 0;
                }
            }

            return result;
        }

    }
}
