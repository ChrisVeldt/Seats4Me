using Seats4Me.Model.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seats4Me.Common.Enum;

namespace Seats4Me.DataAccess.Interfaces
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetScheduleAsync(DateTime fromDate, DateTime untilDate);
    }
}
