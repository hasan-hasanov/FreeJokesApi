using Domain.Entities;
using System.Collections.Generic;

namespace Persistence.Serializers.Model
{
    public class JokeSerializeModel
    {
        public List<Joke> Jokes { get; set; }
    }
}
