using Application.Abstract;
using Domain.Entities;
using Persistence.Serializers.Abstract;
using System.Collections.Generic;

namespace Persistence
{
    public class JokeService : IJokeService
    {
        private readonly IDataSerializer _serializer;

        public IEnumerable<Joke> Jokes => _serializer.SerializeJokes();

        public IEnumerable<Category> Categories => _serializer.SerializerCategories();

        public JokeService(IDataSerializer serializer)
        {
            _serializer = serializer;
        }
    }
}
