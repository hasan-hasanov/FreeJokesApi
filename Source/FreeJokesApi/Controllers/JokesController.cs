using Application.Jokes.Queries.GetJokesByCount.Abstract;
using Application.Jokes.Queries.GetJokesWithCategories.Abstract;
using Application.Jokes.Queries.GetRandomJoke.Abstract;
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
        IGetAllJokesQuery _getJokesWithCategoriesQuery;
        IGetRandomJokeQuery _getRandomJokeQuery;
        IGetJokesByCountQuery _getJokesByCount;

        public JokesController(IGetAllJokesQuery getJokesWithCategoriesQuery,
            IGetRandomJokeQuery getRandomJokeQuery,
            IGetJokesByCountQuery getJokesByCount)
        {
            _getJokesWithCategoriesQuery = getJokesWithCategoriesQuery;
            _getRandomJokeQuery = getRandomJokeQuery;
            _getJokesByCount = getJokesByCount;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var jokes = _getJokesWithCategoriesQuery.Execute();

            return Json(jokes);
        }
    }
}
