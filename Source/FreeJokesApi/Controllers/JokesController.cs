using Application.Categories.Queries.GetAllCategoriesQuery.Abstract;
using Application.Jokes.Queries.GetAllJokesByCategory.Abstract;
using Application.Jokes.Queries.GetJokeById.Abstrac;
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
        private readonly IGetAllCategoriesQuery _getAllCategoriesQuery;
        private readonly IGetAllJokesQuery _getJokesWithCategoriesQuery;
        private readonly IGetAllJokesByCategoryQuery _getAllJokesByCategoryQuery;
        private readonly IGetJokeByIdQuery _getJokeByIdQuery;
        private readonly IGetJokesByCategoryAndCountQuery _getJokesByCategoryAndCountQuery;
        private readonly IGetJokesByCountQuery _getJokesByCount;
        private readonly IGetRandomJokeQuery _getRandomJokeQuery;
        private readonly IGetRandomJokeByCategoryQuery _getRandomJokeByCategoryQuery;

        public JokesController(IGetAllCategoriesQuery getAllCategoriesQuery,
            IGetAllJokesQuery getJokesWithCategoriesQuery,
            IGetAllJokesByCategoryQuery getAllJokesByCategoryQuery,
            IGetJokeByIdQuery getJokeByIdQuery,
            IGetJokesByCategoryAndCountQuery getJokesByCategoryAndCount,
            IGetJokesByCountQuery getJokesByCount,
            IGetRandomJokeQuery getRandomJokeQuery,
            IGetRandomJokeByCategoryQuery getRandomJokeByCategoryQuery)
        {
            _getAllCategoriesQuery = getAllCategoriesQuery;
            _getJokesWithCategoriesQuery = getJokesWithCategoriesQuery;
            _getAllJokesByCategoryQuery = getAllJokesByCategoryQuery;
            _getJokeByIdQuery = getJokeByIdQuery;
            _getJokesByCategoryAndCountQuery = getJokesByCategoryAndCount;
            _getJokesByCount = getJokesByCount;
            _getRandomJokeQuery = getRandomJokeQuery;
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
