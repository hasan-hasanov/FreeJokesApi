using Application.Jokes.Models;
using Application.Jokes.Queries.GetJokesByCount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Application.Test.Jokes.Queries.GetJokesByCount
{
    [TestClass]
    public class GetJokesByCountQueryTest
    {
        private readonly GetJokesByCountQuery _getJokesByCountQuery;

        public GetJokesByCountQueryTest()
        {
            UnitTestContext context = new UnitTestContext();

            _getJokesByCountQuery = new GetJokesByCountQuery(context.JokeService.Object);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Should_return_Jokes_By_Count(int count)
        {
            List<JokeModel> actual = _getJokesByCountQuery.Execute(count);

            Assert.That(actual.Count, Is.EqualTo(count));
        }

        [DataTestMethod]
        [DataRow(10)]
        [DataRow(int.MaxValue)]
        [DataRow(1)]
        [DataRow(4)]
        public void Should_Return_Jokes_By_Specific_Count_Or_All(int count)
        {
            List<JokeModel> actual = _getJokesByCountQuery.Execute(count);
            int internalCount = count > actual.Count ? actual.Count : count;

            Assert.That(actual.Count, Is.EqualTo(internalCount));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10)]
        public void Should_Return_Empty_For_Zero_Or_Negative_Count(int count)
        {
            List<JokeModel> actual = _getJokesByCountQuery.Execute(count);

            Assert.IsEmpty(actual);
        }
    }
}
