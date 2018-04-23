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
    [Route("api/ticket")]
    public class TicketController : Controller
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostTicket(TicketViewModel ticketView)
        {
            var ticket = TicketViewModel.MapToDbResult(ticketView);
            var result = await _service.EnterTicketAsync(ticket);

            if (result == 0)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(result);
        }

    }
}