using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using Persistence.Serializers.Model;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Persistence.Test.Serializers.Model
{
    [TestClass]
    public class JokeSerializerModelTest
    {
        private readonly List<Joke> _jokes;
        private readonly JokeSerializerModel _jokeSerializerModel;

        public JokeSerializerModelTest()
        {
            _jokes = BuildJokesMock();
            _jokeSerializerModel = new JokeSerializerModel();
        }

        [TestMethod]
        public void Test_Set_And_Get_Jokes()
        {
            _jokeSerializerModel.Jokes = _jokes;

            string expectedJson = JsonConvert.SerializeObject(_jokes);
            string actualJson = JsonConvert.SerializeObject(_jokeSerializerModel.Jokes);

            Assert.That(expectedJson, Is.EqualTo(actualJson));
        }

        private List<Joke> BuildJokesMock()
        {
            return new List<Joke>()
            {
                new Joke()
                {
                    Id = "d5f812512f7f426999f9daf79b78fe73",
                    Description = "Q: Why did the chewing gum cross the road? \n A: He was stuck to the chicken's foot.",
                    CategoryId = 3
                },
                new Joke()
                {
                    Id = "9734f88b513c4f88a51eb829ee3f3ce1",
                    Description = "Animals have two vital functions in today's society: to be delicious and to fit well.",
                    CategoryId = 3
                },
                new Joke()
                {
                    Id = "cfe96a38ae9c49b3b2922c0ca3aecec4",
                    Description = "What did Harry Potter do when he found the three-headed dog? \n He ran... wouldn't you?.",
                    CategoryId = 3
                }
            };
        }
    }
}
