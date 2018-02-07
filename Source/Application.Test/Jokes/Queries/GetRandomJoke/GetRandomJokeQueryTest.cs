using Application.Jokes.Models;
using Application.Jokes.Queries.GetRandomJoke;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Jokes.Queries.GetRandomJoke
{
    [TestClass]
    public class GetRandomJokeQueryTest
    {
        private readonly GetRandomJokeQuery _getRandomJokeQuery;

        public GetRandomJokeQueryTest()
        {
            UnitTestContext context = new UnitTestContext();
            _getRandomJokeQuery = new GetRandomJokeQuery(context.JokeService.Object);
        }

        [TestMethod]
        public void Should_Not_Be_Null()
        {
            JokeModel actual = _getRandomJokeQuery.Execute();

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Should_Not_Be_Empty()
        {
            JokeModel actual = _getRandomJokeQuery.Execute();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(actual.Description));
        }
    }
}
