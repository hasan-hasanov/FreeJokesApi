using Microsoft.AspNetCore.Mvc;

namespace FreeJokesApi.Controllers
{
    [Route("api/jokes")]
    public class JokesController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
