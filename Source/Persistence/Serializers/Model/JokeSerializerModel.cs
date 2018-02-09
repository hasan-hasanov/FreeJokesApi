using Domain.Entities;
using System.Collections.Generic;

namespace Persistence.Serializers.Model
{
    public class JokeSerializerModel
    {
        public List<Joke> Jokes { get; set; }
    }
}
