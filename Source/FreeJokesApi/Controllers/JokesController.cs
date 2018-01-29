using Application.Jokes.Queries.GetJokesWithCategories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeJokesApi.Controllers
{
    [Route("api/[controller]")]
    public class JokesController : Controller
    {
        IGetJokesWithCategoriesQuery _getJokesWithCategoriesQuery;

        public JokesController(IGetJokesWithCategoriesQuery getJokesWithCategoriesQuery)
        {
            _getJokesWithCategoriesQuery = getJokesWithCategoriesQuery;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var jokes = _getJokesWithCategoriesQuery.Execute();

            return Json(jokes);
        }
    }
}
