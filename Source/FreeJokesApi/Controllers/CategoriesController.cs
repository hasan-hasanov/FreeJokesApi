using Microsoft.AspNetCore.Mvc;

namespace FreeJokesApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Ok();
        }
    }
}
