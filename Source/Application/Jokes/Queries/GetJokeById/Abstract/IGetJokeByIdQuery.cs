using Application.Jokes.Models;

namespace Application.Jokes.Queries.GetJokeById.Abstract
{
    public interface IGetJokeByIdQuery
    {
        JokeModel Execute(string jokeId);
    }
}
