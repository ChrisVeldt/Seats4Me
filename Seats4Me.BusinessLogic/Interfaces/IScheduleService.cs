using System;
using Seats4Me.Model.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seats4Me.Common.Enum;
using Seats4Me.Common.Utils;

namespace Seats4Me.BusinessLogic.Interfaces
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetScheduleAsync(string period, DateTime? periodDate);
    }
}