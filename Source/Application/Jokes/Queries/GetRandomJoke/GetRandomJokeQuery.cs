using Application.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetRandomJoke.Abstract;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Jokes.Queries.GetRandomJoke
{
    public class GetRandomJokeQuery : IGetRandomJokeQuery
    {
        private readonly IJokeService _jokeService;

        public GetRandomJokeQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public JokeModel Execute()
        {
            Joke joke = _jokeService
                .Jokes
                .OrderBy(j => Guid.NewGuid())
                .First();

            JokeModel jokeModel = new JokeModel
            {
                Category = _jokeService.Categories.First(c => c.Id == joke.CategoryId).Description,
                Description = joke.Description,
                Id = joke.Id
            };

            return jokeModel;
        }
    }
}
