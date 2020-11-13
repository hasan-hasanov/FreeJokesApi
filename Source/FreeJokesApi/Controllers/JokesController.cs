using Microsoft.AspNetCore.Mvc;

namespace FreeJokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class JokesController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
