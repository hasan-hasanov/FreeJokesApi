using Application.Jokes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jokes.Queries.GetRandomJokeByCategory.Abstract
{
    public interface IGetRandomJokeByCategoryQuery
    {
        JokeModel Execute(string categoryName);
    }
}
