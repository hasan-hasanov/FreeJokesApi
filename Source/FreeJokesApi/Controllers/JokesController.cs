using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeJokesApi.Controllers
{
    [Route("api/jokes")]
    public class JokesController : Controller
    {
        private readonly IMediator _mediator;

        public JokesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredJokes(JokesFilter filter)
        {
            IList<JokeResponseModel> response = await _mediator.Send(filter);
            return Ok(response);
        }
    }
}
