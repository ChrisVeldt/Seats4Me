using System;
using System.Collections.Generic;
using System.Text;
using Seats4Me.Common.interfaces;

namespace Seats4Me.Common.Utils
{
    public class Seats4MeConfiguration : ISeats4MeConfiguration
    {
        public int TotalSeats { get; set; }
    }
}
