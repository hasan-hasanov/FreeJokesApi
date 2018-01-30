using Domain.Entities;
using System.Collections.Generic;

namespace Application.Abstract
{
    public interface IJokeService
    {
        List<Joke> Jokes { get; }

        List<Category> Categories { get; }
    }
}
