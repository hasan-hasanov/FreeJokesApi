using Domain.Entities;
using Newtonsoft.Json;
using Persistence.Serializers.Abstract;
using Persistence.Serializers.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace Persistence.Serializers
{
    public class DataSerializer : IDataSerializer
    {
        private readonly string _jokesLocation;
        private readonly string _categoriesLocation;
        private readonly IFileSystem _fileSystem;

        public DataSerializer(IFileSystem fileSystem)
        {
            _jokesLocation = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Jokes.json";
            _categoriesLocation = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Categories.json";

            _fileSystem = fileSystem;
        }

        public IEnumerable<Joke> SerializeJokes()
        {
            using (StreamReader file = _fileSystem.File.OpenText(_jokesLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                JokeSerializerModel jokeSerializeModel = (JokeSerializerModel)serializer.Deserialize(file, typeof(JokeSerializerModel));

                return jokeSerializeModel.Jokes;
            }
        }

        public IEnumerable<Category> SerializerCategories()
        {
            using (StreamReader file = _fileSystem.File.OpenText(_categoriesLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                CategorySerializerModel categorySerializeModel = (CategorySerializerModel)serializer.Deserialize(file, typeof(CategorySerializerModel));

                return categorySerializeModel.Categories;
            }
        }
    }
}
