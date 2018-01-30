using Application.Jokes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract
{
    public interface IGetJokesByCategoryAndCountQuery
    {
        List<JokeModel> Execute(string categoryName, int count);
    }
}
