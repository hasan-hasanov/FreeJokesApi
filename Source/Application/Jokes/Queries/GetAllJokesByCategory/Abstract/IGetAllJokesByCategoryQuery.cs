using Application.Jokes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jokes.Queries.GetAllJokesByCategory.Abstract
{
    public interface IGetAllJokesByCategoryQuery
    {
        List<JokeModel> Execute(string categoryName);
    }
}
