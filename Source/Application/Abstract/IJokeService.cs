using Domain.Entities;
using System.Collections.Generic;

namespace Application.Abstract
{
    public interface IJokeService
    {
        IEnumerable<Joke> Jokes { get; }

        IEnumerable<Category> Categories { get; }
    }
}
