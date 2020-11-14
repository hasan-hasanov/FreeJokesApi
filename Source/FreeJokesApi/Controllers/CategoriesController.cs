using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeJokesApi.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IList<CategoryResponseModel> response = await _mediator.Send(new GetAllCategoriesRequestModel());
            return this.Ok(response);
        }
    }
}
