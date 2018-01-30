using Application.Jokes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jokes.Queries.GetJokesByCount.Abstract
{
    public interface IGetJokesByCountQuery
    {
        List<JokeModel> Execute(int count);
    }
}
