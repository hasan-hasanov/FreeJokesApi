using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Jokes.Models;
using Application.Jokes.Queries.GetRandomJokeByCategory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Test.Jokes.Queries.GetRandomJokeByCategory
{
    [TestClass]
    public class GetRandomJokeByCategoryQueryTest
    {
        private readonly GetRandomJokeByCategoryQuery _getRandomJokeByCategoryQuery;

        public GetRandomJokeByCategoryQueryTest()
        {
            UnitTestContext context = new UnitTestContext();

            _getRandomJokeByCategoryQuery = new GetRandomJokeByCategoryQuery(context.JokeService.Object);
        }

        [DataTestMethod]
        [DataRow("Stupid")]
        [DataRow("Programmer")]
        [DataRow("Animal")]
        public void Should_Not_Be_Null(string categoryName)
        {
            JokeModel actual = _getRandomJokeByCategoryQuery.Execute(categoryName);

            Assert.IsNotNull(actual);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("    ")]
        [DataRow(null)]
        public void Should_Be_Null(string categoryName)
        {
            JokeModel actual = _getRandomJokeByCategoryQuery.Execute(categoryName);

            Assert.IsNull(actual);
        }

        [DataTestMethod]
        [DataRow("Stupid")]
        [DataRow("Programmer")]
        [DataRow("Animal")]
        public void Should_Return_Joke_By_Category(string categoryName)
        {
            JokeModel actual = _getRandomJokeByCategoryQuery.Execute(categoryName);

            Assert.IsTrue(string.Equals(actual.Category.Trim(), categoryName.Trim(), StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
