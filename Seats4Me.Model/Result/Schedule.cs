using System;
using System.ComponentModel.DataAnnotations;

namespace Seats4Me.Model.Result
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public DateTime ScheduleDate { get; set; }

        public Show Show { get; set; }
    }
}
