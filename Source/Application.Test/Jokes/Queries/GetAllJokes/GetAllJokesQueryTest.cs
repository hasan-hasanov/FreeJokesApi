using Application.Jokes.Models;
using Application.Jokes.Queries.GetAllJokes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Application.Test.Jokes.Queries.GetAllJokes
{
    [TestClass]
    public class GetAllJokesQueryTest
    {
        private readonly UnitTestContext _context;
        private readonly GetAllJokesQuery _getAllJokesQuery;

        public GetAllJokesQueryTest()
        {
            _context = new UnitTestContext();

            _getAllJokesQuery = new GetAllJokesQuery(_context.JokeService.Object);
        }

        [TestMethod]
        public void Should_Return_All_Jokes()
        {
            List<JokeModel> actual = _getAllJokesQuery.Execute();
            List<JokeModel> expected = _context.JokeModels;

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }
    }
}
