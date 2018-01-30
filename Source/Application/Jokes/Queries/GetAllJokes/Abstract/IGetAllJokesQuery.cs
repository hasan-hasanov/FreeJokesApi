using Application.Jokes.Models;
using System.Collections.Generic;

namespace Application.Jokes.Queries.GetJokesWithCategories.Abstract
{
    public interface IGetAllJokesQuery
    {
        List<JokeModel> Execute();
    }
}
