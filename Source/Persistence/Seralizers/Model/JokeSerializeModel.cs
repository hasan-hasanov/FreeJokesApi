using Domain.Entities;
using System.Collections.Generic;

namespace Persistence.Seralizers.Model
{
    public class JokeSerializeModel
    {
        public List<Joke> Jokes { get; set; }
    }
}
