using Domain.Entities;
using Newtonsoft.Json;
using Persistence.Serializers.Abstract;
using Persistence.Serializers.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Persistence.Serializers
{
    public class DataSerializer : IDataSerializer
    {
        private readonly string _jokesLocation;
        private readonly string _categoriesLocation;

        public DataSerializer()
        {
            _jokesLocation = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Jokes.json";
            _categoriesLocation = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Categories.json";
        }

        public IEnumerable<Joke> SerializeJokes()
        {
            using (StreamReader file = File.OpenText(_jokesLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                JokeSerializeModel jokeSerializeModel = (JokeSerializeModel)serializer.Deserialize(file, typeof(JokeSerializeModel));

                return jokeSerializeModel.Jokes;
            }
        }

        public IEnumerable<Category> SerializerCategories()
        {
            using (StreamReader file = File.OpenText(_categoriesLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                CategorySerializerModel categorySerializeModel = (CategorySerializerModel)serializer.Deserialize(file, typeof(CategorySerializerModel));

                return categorySerializeModel.Categories;
            }
        }
    }
}
