using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seats4Me.Model.Result;

namespace Seats4Me.ViewModel
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }
        public string CustomerName { get; set; }
        public int Seats { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }

        public int ScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }

        public int ShowId { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Maps a ticket to a viewmodel
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static TicketViewModel MapFromDbResult(Ticket ticket)
        {
            return new TicketViewModel
            {
                TicketId = ticket.TicketId,
                CustomerName = ticket.CustomerName,
                OrderDate = ticket.OrderDate,
                Seats = ticket.Seats,
                Paid = ticket.Paid,
                ScheduleId = ticket.Schedule.ScheduleId,
                ScheduleDate = ticket.Schedule.ScheduleDate,
                ShowId = ticket.Schedule.Show.ShowId,
                Price = ticket.Schedule.Show.Price
            };
        }

        /// <summary>
        /// Maps a viewmodel to a ticket
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static Ticket MapToDbResult(TicketViewModel viewModel)
        {
            return new Ticket
            {
                TicketId = viewModel.TicketId,
                CustomerName = viewModel.CustomerName,
                Seats = viewModel.Seats,
                OrderDate = viewModel.OrderDate,
                Paid = viewModel.Paid,
                ScheduleId = viewModel.ScheduleId,
//                Schedule = new Schedule { ScheduleId = viewModel.ScheduleId}
            };
        }
    }
}
