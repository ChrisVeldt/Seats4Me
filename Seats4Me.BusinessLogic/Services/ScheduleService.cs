using Seats4Me.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.Common.Enum;
using Seats4Me.Common.Utils;
using Seats4Me.Model.Result;

namespace Seats4Me.BusinessLogic.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Schedule>> GetScheduleAsync(string period, DateTime? periodDate)
        {
            var range = ScheduleRange.GetRange(period, periodDate);
            var result = await _repository.GetScheduleAsync(range.from, range.until);

            return result ?? new List<Schedule>();
        }
    }
}
