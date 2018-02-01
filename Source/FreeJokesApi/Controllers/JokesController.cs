using Application.Categories.Models;
using Application.Categories.Queries.GetAllCategoriesQuery.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetAllJokesByCategory.Abstract;
using Application.Jokes.Queries.GetJokeById.Abstrac;
using Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract;
using Application.Jokes.Queries.GetJokesByCount.Abstract;
using Application.Jokes.Queries.GetJokesWithCategories.Abstract;
using Application.Jokes.Queries.GetRandomJoke.Abstract;
using Application.Jokes.Queries.GetRandomJokeByCategory.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FreeJokesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class JokesController : Controller
    {
        private readonly IGetAllCategoriesQuery _getAllCategoriesQuery;
        private readonly IGetAllJokesQuery _getAllJokesQuery;
        private readonly IGetAllJokesByCategoryQuery _getAllJokesByCategoryQuery;
        private readonly IGetJokeByIdQuery _getJokeByIdQuery;
        private readonly IGetJokesByCategoryAndCountQuery _getJokesByCategoryAndCountQuery;
        private readonly IGetJokesByCountQuery _getJokesByCount;
        private readonly IGetRandomJokeQuery _getRandomJokeQuery;
        private readonly IGetRandomJokeByCategoryQuery _getRandomJokeByCategoryQuery;

        public JokesController(IGetAllCategoriesQuery getAllCategoriesQuery,
            IGetAllJokesQuery getAllJokesQuery,
            IGetAllJokesByCategoryQuery getAllJokesByCategoryQuery,
            IGetJokeByIdQuery getJokeByIdQuery,
            IGetJokesByCategoryAndCountQuery getJokesByCategoryAndCount,
            IGetJokesByCountQuery getJokesByCount,
            IGetRandomJokeQuery getRandomJokeQuery,
            IGetRandomJokeByCategoryQuery getRandomJokeByCategoryQuery)
        {
            _getAllCategoriesQuery = getAllCategoriesQuery;
            _getAllJokesQuery = getAllJokesQuery;
            _getAllJokesByCategoryQuery = getAllJokesByCategoryQuery;
            _getJokeByIdQuery = getJokeByIdQuery;
            _getJokesByCategoryAndCountQuery = getJokesByCategoryAndCount;
            _getJokesByCount = getJokesByCount;
            _getRandomJokeQuery = getRandomJokeQuery;
            _getRandomJokeByCategoryQuery = getRandomJokeByCategoryQuery;
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            List<CategoryModel> categories = _getAllCategoriesQuery.Execute();

            return Json(categories);
        }

        [HttpGet]
        public JsonResult GetAllJokes()
        {
            List<JokeModel> jokes = _getAllJokesQuery.Execute();

            return Json(jokes);
        }

        [HttpGet]
        public JsonResult GetJokes(string categoryName)
        {
            List<JokeModel> jokesByCategory = _getAllJokesByCategoryQuery.Execute(categoryName);

            if (!jokesByCategory.Any()) return Json(NotFound());

            return Json(jokesByCategory);
        }

        [HttpGet]
        public JsonResult GetJokes(int count)
        {
            if (count <= 0) return Json(NotFound());

            List<JokeModel> jokesByCount = _getJokesByCount.Execute(count);

            return Json(jokesByCount);
        }

        [HttpGet]
        public JsonResult GetJokes(string categoryName, int count)
        {
            if (count <= 0) return Json(NotFound());

            List<JokeModel> jokesByCategory = _getJokesByCategoryAndCountQuery.Execute(categoryName, count);

            if (!jokesByCategory.Any()) return Json(NotFound());

            return Json(jokesByCategory);
        }

        [HttpGet]
        public JsonResult GetJokeById(string jokeId)
        {
            if (string.IsNullOrWhiteSpace(jokeId)) return Json(NotFound());

            JokeModel joke = _getJokeByIdQuery.Execute(jokeId);

            if (joke == null) return Json(NotFound());

            return Json(joke);
        }

        [HttpGet]
        public JsonResult GetRandomJoke()
        {
            JokeModel joke = _getRandomJokeQuery.Execute();

            return Json(joke);
        }

        [HttpGet]
        public JsonResult GetRandomJoke(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName)) return Json(NotFound());

            JokeModel joke = _getRandomJokeByCategoryQuery.Execute(categoryName);

            if (joke == null) return Json(NotFound());

            return Json(joke);
        }
    }
}
