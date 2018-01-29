using Application.Abstract;
using System.Collections.Generic;
using System.Linq;
using Application.Jokes.Queries.GetJokesWithCategories.Abstract;

namespace Application.Jokes.Queries.GetJokesWithCategories
{
    public class GetJokesWithCategoriesQuery : IGetJokesWithCategoriesQuery
    {
        private readonly IJokeService _jokeService;

        public GetJokesWithCategoriesQuery(IJokeService jokeService)
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
