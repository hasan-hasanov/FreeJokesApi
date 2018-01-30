using Application.Jokes.Models;
using System.Collections.Generic;

namespace Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract
{
    public interface IGetJokesByCategoryAndCountQuery
    {
        List<JokeModel> Execute(string categoryName, int count);
    }
}
