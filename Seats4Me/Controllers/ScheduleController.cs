using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.Common.Enum;
using Seats4Me.Common.Utils;
using Seats4Me.Model.Result;

namespace Seats4Me.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _service;
        private readonly IUrlHelper _urlHelper;

        public ScheduleController(IScheduleService service, IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
            _service = service;
        }

        [HttpGet]
        [Route("", Name="GetSchedule")]
        public async Task<IActionResult> GetScheduleAsync([FromQuery] string period, [FromQuery] DateTime? date)
        {
            var schedule = await _service.GetScheduleAsync(period, date);

            var result = new
            {
                PreviousPeriod = PeriodUrl(ScheduleRange.GetPreviousRange(period, date).from),
                NextPeriod = PeriodUrl(ScheduleRange.GetNextRange(period, date).from),
                Schedule = schedule ?? new List<Schedule>()
            };

            return new ObjectResult(result);
        }

        private string PeriodUrl(DateTime date)
        {
            if (Request == null || _urlHelper == null)
            {
                return "";
            }

            var newUrlQuery = new Dictionary<string, object>();
            Request.Query
                .Where(q => q.Key.ToLower() != "date")
                .ToList().ForEach(q => newUrlQuery.Add(q.Key, q.Value));
            newUrlQuery.Add("date", date.ToString("yyyy-MM-dd"));

            return _urlHelper.Link("GetSchedule", newUrlQuery);
        }
    }
}