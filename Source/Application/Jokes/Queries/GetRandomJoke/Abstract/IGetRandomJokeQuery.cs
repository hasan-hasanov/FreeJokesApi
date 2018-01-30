using Application.Jokes.Models;

namespace Application.Jokes.Queries.GetRandomJoke.Abstract
{
    public interface IGetRandomJokeQuery
    {
        JokeModel Execute();
    }
}
