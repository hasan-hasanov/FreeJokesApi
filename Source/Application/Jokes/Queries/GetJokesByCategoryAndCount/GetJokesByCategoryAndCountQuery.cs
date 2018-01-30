using Application.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Application.Jokes.Queries.GetJokesByCategoryAndCount
{
    public class GetJokesByCategoryAndCountQuery : IGetJokesByCategoryAndCountQuery
    {
        private readonly IJokeService _jokeService;

        public GetJokesByCategoryAndCountQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public List<JokeModel> Execute(string categoryName, int count)
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
                   .Take(count)
                   .ToList();
        }
    }
}
