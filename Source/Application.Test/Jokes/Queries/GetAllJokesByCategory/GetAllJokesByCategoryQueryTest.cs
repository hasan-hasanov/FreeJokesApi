using Application.Jokes.Models;
using Application.Jokes.Queries.GetAllJokesByCategory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace Application.Test.Jokes.Queries.GetAllJokesByCategory
{
    [TestClass]
    public class GetAllJokesByCategoryQueryTest
    {
        private readonly UnitTestContext _context;
        private readonly GetAllJokesByCategoryQuery _getAllJokesByCategoryQuery;

        public GetAllJokesByCategoryQueryTest()
        {
            _context = new UnitTestContext();

            _getAllJokesByCategoryQuery = new GetAllJokesByCategoryQuery(_context.JokeService.Object);
        }

        [DataTestMethod]
        [DataRow("Stupid")]
        [DataRow("Programmer")]
        [DataRow("Animal")]
        public void Should_Return_Jokes_By_Category_Name(string categoryName)
        {
            List<JokeModel> actual = _getAllJokesByCategoryQuery.Execute(categoryName);
            List<JokeModel> expected = _context.JokeModels
                .Where(j => string.Equals(j.Category.Trim(), categoryName.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void Should_Return_Empty_When_CategoryName_Is_Null_Or_Empty(string categoryName)
        {
            List<JokeModel> actual = _getAllJokesByCategoryQuery.Execute(categoryName);

            CollectionAssert.IsEmpty(actual);
        }
    }
}
