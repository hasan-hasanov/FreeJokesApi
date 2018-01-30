using Application.Abstract;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetJokeById.Abstrac;
using Domain.Entities;
using System.Linq;

namespace Application.Jokes.Queries.GetJokeById
{
    public class GetJokeByIdQuery : IGetJokeByIdQuery
    {
        private readonly IJokeService _jokeService;

        public GetJokeByIdQuery(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public JokeModel Execute(string jokeId)
        {
            Joke joke = _jokeService
                .Jokes
                .FirstOrDefault(j => j.Id == jokeId.Trim());

            if (joke == null) return null;

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
