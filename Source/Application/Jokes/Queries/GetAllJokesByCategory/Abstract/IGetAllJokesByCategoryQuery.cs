using Application.Jokes.Models;
using System.Collections.Generic;

namespace Application.Jokes.Queries.GetAllJokesByCategory.Abstract
{
    public interface IGetAllJokesByCategoryQuery
    {
        List<JokeModel> Execute(string categoryName);
    }
}
