using Application.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetJokesByCount.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Jokes.Queries.GetJokesByCount
{
    public class GetJokesByCountQuery : IGetJokesByCountQuery
    {
        private readonly IJokeService _jokeService;

        public GetJokesByCountQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public List<JokeModel> Execute(int count)
        {
            return (from joke in _jokeService.Jokes
                    join category in _jokeService.Categories on joke.CategoryId equals category.Id
                    select new JokeModel()
                    {
                        Id = joke.Id,
                        Description = joke.Description,
                        Category = category.Description
                    })
                    .OrderBy(j => Guid.NewGuid())
                    .Take(count)
                    .ToList();
        }
    }
}
