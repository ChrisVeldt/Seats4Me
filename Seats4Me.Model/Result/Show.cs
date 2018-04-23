using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seats4Me.Model.Result
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<Schedule> Schedule { get; set; }
    }
}
