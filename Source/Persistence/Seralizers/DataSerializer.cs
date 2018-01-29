using Domain.Entities;
using Newtonsoft.Json;
using Persistence.Seralizers.Model;
using Persistence.Serializers.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persistence.Seralizers
{
    public class DataSerializer : IDataSerializer
    {
        private readonly string jokesLocation;
        private readonly string categoriesLocation;

        public DataSerializer()
        {
            jokesLocation = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Jokes.json";
            categoriesLocation = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Categories.json";
        }

        public List<Joke> SerializeJokes()
        {

            using (StreamReader file = File.OpenText(jokesLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                JokeSerializeModel jokeSerializeModel = (JokeSerializeModel)serializer.Deserialize(file, typeof(JokeSerializeModel));

                return jokeSerializeModel.Jokes;
            }
        }

        public List<Category> SerializerCategories()
        {
            using (StreamReader file = File.OpenText(categoriesLocation))
            {
                JsonSerializer serializer = new JsonSerializer();
                CategorySerializerModel categorySerializeModel = (CategorySerializerModel)serializer.Deserialize(file, typeof(CategorySerializerModel));

                return categorySerializeModel.Categories;
            }
        }
    }
}
