using Application.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetAllJokesByCategory.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Application.Jokes.Queries.GetAllJokesByCategory
{
    public class GetAllJokesByCategoryQuery : IGetAllJokesByCategoryQuery
    {
        private readonly IJokeService _jokeService;

        public GetAllJokesByCategoryQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public List<JokeModel> Execute(string categoryName)
        {
            return (from joke in _jokeService.Jokes
                    join category in _jokeService.Categories on joke.CategoryId equals category.Id
                    select new JokeModel()
                    {
                        Id = joke.Id,
                        Description = joke.Description,
                        Category = category.Description
                    })
                    .Where(j => j.Category.Trim().ToLower() == categoryName?.Trim()?.ToLower())
                    .ToList();
        }
    }
}
