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
using Seats4Me.ViewModel;

namespace Seats4Me.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _service;
        private readonly IUrlHelper _urlHelper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="urlHelper"></param>
        public ScheduleController(IScheduleService service, IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
            _service = service;
        }

        /// <summary>
        /// Get all scheduled events for the given period.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name="GetSchedule")]
        public async Task<IActionResult> GetScheduleAsync([FromQuery] string period, [FromQuery] DateTime? date)
        {
            var schedule = await _service.GetScheduleAsync(period, date);

            // Map to viewmodel
            var scheduleViewModel = new List<ScheduleViewModel>();
            if (schedule != null)
            {
                foreach (var scheduleItem in schedule)
                {
                    scheduleViewModel.Add(ScheduleViewModel.MapFromDbResult(scheduleItem));
                }
            }

            //Build JSON data.
            var result = new
            {
                PreviousPeriod = PeriodUrl(ScheduleRange.GetPreviousRange(period, date).from),
                NextPeriod = PeriodUrl(ScheduleRange.GetNextRange(period, date).from),
                Schedule = scheduleViewModel
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