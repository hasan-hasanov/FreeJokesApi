using Application.Abstract;
using Domain.Entities;
using Persistence.Serializers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class JokeService : IJokeService
    {
        private readonly IDataSerializer _serializer;

        public List<Joke> Jokes => _serializer.SerializeJokes();

        public List<Category> Categories => _serializer.SerializerCategories();

        public JokeService(IDataSerializer serializer)
        {
            _serializer = serializer;
        }
    }
}
