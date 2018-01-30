using Application.Jokes.Models;
using System.Collections.Generic;

namespace Application.Jokes.Queries.GetJokesByCount.Abstract
{
    public interface IGetJokesByCountQuery
    {
        List<JokeModel> Execute(int count);
    }
}
