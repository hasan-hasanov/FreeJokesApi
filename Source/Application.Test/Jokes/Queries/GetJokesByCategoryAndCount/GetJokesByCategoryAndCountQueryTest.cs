using Application.Jokes.Models;
using Application.Jokes.Queries.GetJokesByCategoryAndCount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace Application.Test.Jokes.Queries.GetJokesByCategoryAndCount
{
    [TestClass]
    public class GetJokesByCategoryAndCountQueryTest
    {
        private readonly GetJokesByCategoryAndCountQuery _getJokesByCategoryAndCountQuery;

        public GetJokesByCategoryAndCountQueryTest()
        {
            UnitTestContext context = new UnitTestContext();
            _getJokesByCategoryAndCountQuery = new GetJokesByCategoryAndCountQuery(context.JokeService.Object);
        }

        [DataTestMethod]
        [DataRow("Stupid", 10)]
        [DataRow("Programmer", 10)]
        [DataRow("Animal", 10)]
        public void Should_Return_Jokes_For_Specific_Category(string categoryName, int count)
        {
            List<JokeModel> actual = _getJokesByCategoryAndCountQuery.Execute(categoryName, count);
            List<string> actualCategories = actual.Select(c => c.Category.ToLower()).Distinct().ToList();
            List<string> expectedCategories = new List<string>() { categoryName.ToLower() };

            CollectionAssert.AreEquivalent(expectedCategories, actualCategories);
        }

        [DataTestMethod]
        [DataRow("Stupid", 1)]
        [DataRow("Programmer", 2)]
        [DataRow("Animal", 3)]
        public void Should_Return_Jokes_By_Specific_Count(string categoryName, int count)
        {
            List<JokeModel> actual = _getJokesByCategoryAndCountQuery.Execute(categoryName, count);

            Assert.That(actual.Count, Is.EqualTo(count));
        }

        [DataTestMethod]
        [DataRow("Stupid", 10)]
        [DataRow("Stupid", 30)]
        [DataRow("Stupid", 1)]
        [DataRow("Programmer", 2)]
        [DataRow("Programmer", 3)]
        [DataRow("Programmer", 20)]
        [DataRow("Animal", 3)]
        [DataRow("Animal", 1)]
        [DataRow("Animal", 30)]
        public void Should_Return_Jokes_By_Specific_Count_Or_All(string categoryName, int count)
        {
            List<JokeModel> actual = _getJokesByCategoryAndCountQuery.Execute(categoryName, count);
            int internalCount = count > actual.Count ? actual.Count : count;

            Assert.That(actual.Count, Is.EqualTo(internalCount));
        }

        [DataTestMethod]
        [DataRow("Stupid", 0)]
        [DataRow("Stupid", -1)]
        [DataRow("Programmer", 0)]
        [DataRow("Programmer", -10)]
        [DataRow("Animal", 0)]
        [DataRow("Animal", -20)]
        public void Should_Return_Empty_For_Zero_Or_Negative_Count(string categoryName, int count)
        {
            List<JokeModel> actual = _getJokesByCategoryAndCountQuery.Execute(categoryName, count);

            Assert.IsEmpty(actual);
        }

        [DataTestMethod]
        [DataRow("", 1)]
        [DataRow("  ", 2)]
        [DataRow(null, 3)]
        public void Should_Return_Empty_For_Empty_CategoryName(string categoryName, int count)
        {
            List<JokeModel> actual = _getJokesByCategoryAndCountQuery.Execute(categoryName, count);

            Assert.IsEmpty(actual);
        }
    }
}
