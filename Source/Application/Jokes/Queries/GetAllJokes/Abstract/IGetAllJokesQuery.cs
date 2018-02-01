using Application.Jokes.Models;
using System.Collections.Generic;

namespace Application.Jokes.Queries.GetAllJokes.Abstract
{
    public interface IGetAllJokesQuery
    {
        List<JokeModel> Execute();
    }
}
