using Application.Jokes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jokes.Queries.GetJokeById.Abstrac
{
    public interface IGetJokeByIdQuery
    {
        JokeModel Execute(string jokeId);
    }
}
