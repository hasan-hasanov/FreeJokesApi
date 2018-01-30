using Application.Jokes.Models;

namespace Application.Jokes.Queries.GetJokeById.Abstrac
{
    public interface IGetJokeByIdQuery
    {
        JokeModel Execute(string jokeId);
    }
}
