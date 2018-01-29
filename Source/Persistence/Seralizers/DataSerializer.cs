using Domain.Entities;
using Newtonsoft.Json;
using Persistence.Serializers.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persistence.Seralizers
{
    public class DataSerializer : IDataSerializer
    {
        private const string JOKES_LOCATION = "/Data/Jokes.json";
        private const string CATEGORIES_LOCATION = "/Data/Categories.json";

        public List<Joke> SerializeJokes()
        {
            using (StreamReader file = File.OpenText(JOKES_LOCATION))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Joke> jokes = (List<Joke>)serializer.Deserialize(file, typeof(List<Joke>));

                return jokes;
            }
        }

        public List<Category> SerializerCategories()
        {
            using (StreamReader file = File.OpenText(CATEGORIES_LOCATION))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Category> categories = (List<Category>)serializer.Deserialize(file, typeof(List<Category>));

                return categories;
            }
        }
    }
}
