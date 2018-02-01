using Application.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetAllJokes.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Application.Jokes.Queries.GetAllJokes
{
    public class GetAllJokesQuery : IGetAllJokesQuery
    {
        private readonly IJokeService _jokeService;

        public GetAllJokesQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public List<JokeModel> Execute()
        {
            return (from joke in _jokeService.Jokes
                    join category in _jokeService.Categories on joke.CategoryId equals category.Id
                    select new JokeModel()
                    {
                        Id = joke.Id,
                        Description = joke.Description,
                        Category = category.Description
                    }).ToList();
        }
    }
}
