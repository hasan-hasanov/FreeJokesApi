using Application.Jokes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jokes.Queries.GetRandomJoke.Abstract
{
    public interface IGetRandomJokeQuery
    {
        JokeModel Execute();
    }
}
