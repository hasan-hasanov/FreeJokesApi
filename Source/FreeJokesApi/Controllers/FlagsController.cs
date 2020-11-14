using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeJokesApi.Controllers
{
    [Route("api/flags")]
    public class FlagsController : Controller
    {
        private readonly IMediator _mediator;

        public FlagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IList<FlagResponseModel> response = await _mediator.Send(new GetAllFlagsRequestModel());
            return this.Ok(response);
        }
    }
}
