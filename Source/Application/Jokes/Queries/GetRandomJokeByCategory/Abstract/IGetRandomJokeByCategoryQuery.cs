using Application.Jokes.Models;

namespace Application.Jokes.Queries.GetRandomJokeByCategory.Abstract
{
    public interface IGetRandomJokeByCategoryQuery
    {
        JokeModel Execute(string categoryName);
    }
}
