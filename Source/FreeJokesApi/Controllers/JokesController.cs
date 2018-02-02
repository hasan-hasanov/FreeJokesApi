using Application.Jokes.Models;
using Application.Jokes.Queries.GetAllJokes.Abstract;
using Application.Jokes.Queries.GetAllJokesByCategory.Abstract;
using Application.Jokes.Queries.GetJokeById.Abstrac;
using Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract;
using Application.Jokes.Queries.GetJokesByCount.Abstract;
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
        private readonly IGetAllJokesQuery _getAllJokesQuery;
        private readonly IGetAllJokesByCategoryQuery _getAllJokesByCategoryQuery;
        private readonly IGetJokeByIdQuery _getJokeByIdQuery;
        private readonly IGetJokesByCategoryAndCountQuery _getJokesByCategoryAndCountQuery;
        private readonly IGetJokesByCountQuery _getJokesByCount;
        private readonly IGetRandomJokeQuery _getRandomJokeQuery;
        private readonly IGetRandomJokeByCategoryQuery _getRandomJokeByCategoryQuery;

        public JokesController(IGetAllJokesQuery getAllJokesQuery,
            IGetAllJokesByCategoryQuery getAllJokesByCategoryQuery,
            IGetJokeByIdQuery getJokeByIdQuery,
            IGetJokesByCategoryAndCountQuery getJokesByCategoryAndCount,
            IGetJokesByCountQuery getJokesByCount,
            IGetRandomJokeQuery getRandomJokeQuery,
            IGetRandomJokeByCategoryQuery getRandomJokeByCategoryQuery)
        {
            _getAllJokesQuery = getAllJokesQuery;
            _getAllJokesByCategoryQuery = getAllJokesByCategoryQuery;
            _getJokeByIdQuery = getJokeByIdQuery;
            _getJokesByCategoryAndCountQuery = getJokesByCategoryAndCount;
            _getJokesByCount = getJokesByCount;
            _getRandomJokeQuery = getRandomJokeQuery;
            _getRandomJokeByCategoryQuery = getRandomJokeByCategoryQuery;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            List<JokeModel> jokes = _getAllJokesQuery.Execute();

            return Json(jokes);
        }

        [HttpGet("{categoryName}", Name = "GetByCategoryName")]
        public JsonResult GetJokes(string categoryName)
        {
            List<JokeModel> jokesByCategory = _getAllJokesByCategoryQuery.Execute(categoryName);

            return !jokesByCategory.Any() ? Json(NotFound()) : Json(jokesByCategory);
        }

        [HttpGet("{count}", Name = "GetByCount")]
        public JsonResult GetJokes(int count)
        {
            if (count <= 0) return Json(NotFound());

            List<JokeModel> jokesByCount = _getJokesByCount.Execute(count);

            return Json(jokesByCount);
        }

        [HttpGet("{categoryName}&{count}", Name = "GetByCategoryAndCount")]
        public JsonResult GetJokes(string categoryName, int count)
        {
            if (count <= 0) return Json(NotFound());

            List<JokeModel> jokesByCategory = _getJokesByCategoryAndCountQuery.Execute(categoryName, count);

            return !jokesByCategory.Any() ? Json(NotFound()) : Json(jokesByCategory);
        }

        [HttpGet]
        public JsonResult GetById(string jokeId)
        {
            if (string.IsNullOrWhiteSpace(jokeId)) return Json(NotFound());

            JokeModel joke = _getJokeByIdQuery.Execute(jokeId);

            return joke == null ? Json(NotFound()) : Json(joke);
        }

        [HttpGet]
        public JsonResult Random()
        {
            JokeModel joke = _getRandomJokeQuery.Execute();

            return Json(joke);
        }

        [HttpGet("{categoryName}", Name = "GetRandom")]
        public JsonResult Random(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName)) return Json(NotFound());

            JokeModel joke = _getRandomJokeByCategoryQuery.Execute(categoryName);

            return joke == null ? Json(NotFound()) : Json(joke);
        }
    }
}
