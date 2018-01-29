using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstract
{
    public interface IJokeService
    {
        List<Joke> Jokes { get; }

        List<Category> Categories { get; }
    }
}
