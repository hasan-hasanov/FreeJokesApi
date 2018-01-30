using Application.Jokes.Queries.GetAllJokesByCategory.Abstract;
using Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract;
using Application.Jokes.Queries.GetJokesByCount.Abstract;
using Application.Jokes.Queries.GetJokesWithCategories.Abstract;
using Application.Jokes.Queries.GetRandomJoke.Abstract;
using Application.Jokes.Queries.GetRandomJokeByCategory.Abstract;
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
        IGetAllJokesByCategoryQuery _getAllJokesByCategoryQuery;
        IGetJokesByCategoryAndCountQuery _getJokesByCategoryAndCountQuery;
        IGetRandomJokeByCategoryQuery _getRandomJokeByCategoryQuery;

        public JokesController(IGetAllJokesQuery getJokesWithCategoriesQuery,
            IGetRandomJokeQuery getRandomJokeQuery,
            IGetJokesByCountQuery getJokesByCount,
            IGetAllJokesByCategoryQuery getAllJokesByCategoryQuery,
            IGetJokesByCategoryAndCountQuery getJokesByCategoryAndCount,
            IGetRandomJokeByCategoryQuery getRandomJokeByCategoryQuery)
        {
            _getJokesWithCategoriesQuery = getJokesWithCategoriesQuery;
            _getRandomJokeQuery = getRandomJokeQuery;
            _getJokesByCount = getJokesByCount;
            _getAllJokesByCategoryQuery = getAllJokesByCategoryQuery;
            _getJokesByCategoryAndCountQuery = getJokesByCategoryAndCount;
            _getRandomJokeByCategoryQuery = getRandomJokeByCategoryQuery;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var jokes = _getJokesWithCategoriesQuery.Execute();

            return Json(jokes);
        }
    }
}
