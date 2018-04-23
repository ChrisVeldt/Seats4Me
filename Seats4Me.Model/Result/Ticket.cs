using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Seats4Me.Model.Result
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        public string CustomerName { get; set; }
        public int Seats { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

    }
}
