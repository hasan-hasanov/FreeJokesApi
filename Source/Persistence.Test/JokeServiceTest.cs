using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Persistence.Serializers.Abstract;

namespace Persistence.Test
{
    [TestClass]
    public class JokeServiceTest
    {
        private readonly UnitTestContext _context;
        private readonly JokeService _jokeService;

        public JokeServiceTest()
        {
            _context = new UnitTestContext();
            Mock<IDataSerializer> dataSerializer = new Mock<IDataSerializer>();

            dataSerializer.Setup(s => s.SerializeJokes()).Returns(_context.Jokes);
            dataSerializer.Setup(s => s.SerializerCategories()).Returns(_context.Categories);

            _jokeService = new JokeService(dataSerializer.Object);
        }

        [TestMethod]
        public void Should_Return_Jokes()
        {
            IEnumerable<Joke> actual = _jokeService.Jokes;
            IEnumerable<Joke> expected = _context.Jokes;

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.AreEqual(actualJson, expectedJson);
        }

        [TestMethod]
        public void Should_Return_Categories()
        {
            IEnumerable<Category> actual = _jokeService.Categories;
            IEnumerable<Category> expected = _context.Categories;

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.AreEqual(actualJson, expectedJson);
        }
    }
}
