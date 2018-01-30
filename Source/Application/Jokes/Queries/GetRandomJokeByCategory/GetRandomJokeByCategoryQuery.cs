using Application.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetRandomJokeByCategory.Abstract;
using System;
using System.Linq;

namespace Application.Jokes.Queries.GetRandomJokeByCategory
{
    public class GetRandomJokeByCategoryQuery : IGetRandomJokeByCategoryQuery
    {
        private readonly IJokeService _jokeService;

        public GetRandomJokeByCategoryQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public JokeModel Execute(string categoryName)
        {
            return (from joke in _jokeService.Jokes
                    join category in _jokeService.Categories on joke.CategoryId equals category.Id
                    select new JokeModel()
                    {
                        Id = joke.Id,
                        Description = joke.Description,
                        Category = category.Description
                    })
                     .Where(j => j.Category.Trim().ToLower() == categoryName.Trim().ToLower())
                     .OrderBy(j => Guid.NewGuid())
                     .First();
        }
    }
}
