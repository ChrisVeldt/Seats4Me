using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seats4Me.BusinessLogic.Interfaces;

namespace Seats4Me.Controllers
{
    [Produces("application/json")]
    [Route("api/show/{id}")]
    public class ShowController : Controller
    {
        private readonly IShowService _service;

        public ShowController(IShowService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetShowAsync(int id)
        {
            var result = await _service.GetShowAsync(id);

            if (result == null)
            {
                return new NoContentResult();
            }

            return new ObjectResult(result);
        }

    }
}