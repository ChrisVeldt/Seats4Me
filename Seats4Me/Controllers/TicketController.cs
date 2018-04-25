using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.ViewModel;

namespace Seats4Me.Controllers
{
    [Produces("application/json")]
    public class TicketController : Controller
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/ticket")]
        public async Task<IActionResult> PostTicketAsync([FromBody] TicketViewModel ticketView)
        {
            var ticket = TicketViewModel.MapToDbResult(ticketView);
            var result = await _service.EnterTicketAsync(ticket);

            if (result == 0)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("api/schedule/{scheduleId}/ticket")]
        public async Task<IActionResult> GetAllTicketsForAScheduleAsync(int scheduleId)
        {
            var result = await _service.GetTicketsForAScheduleAsync(scheduleId);

            if (result == null)
            {
                return new NoContentResult();
            }
            return new OkObjectResult(result);

        }
    }
}