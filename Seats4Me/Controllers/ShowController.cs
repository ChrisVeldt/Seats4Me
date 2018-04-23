using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seats4Me.BusinessLogic.Interfaces;
using Seats4Me.ViewModel;

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

        /// <summary>
        /// Get a show by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetShowAsync(int id)
        {
            var show = await _service.GetShowAsync(id);

            if (show == null)
            {
                return new NoContentResult();
            }

            return new ObjectResult(ShowViewModel.MapFromDbResult(show));
        }

    }
}