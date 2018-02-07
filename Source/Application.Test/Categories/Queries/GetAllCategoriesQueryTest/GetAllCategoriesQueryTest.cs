using Application.Categories.Models;
using Application.Categories.Queries.GetAllCategoriesQuery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Application.Test.Categories.Queries.GetAllCategoriesQueryTest
{
    [TestClass]
    public class GetAllCategoriesQueryTest
    {
        private readonly UnitTestContext _context;
        private readonly GetAllCategoriesQuery _getAllCategoriesQuery;

        public GetAllCategoriesQueryTest()
        {
            _context = new UnitTestContext();

            _getAllCategoriesQuery = new GetAllCategoriesQuery(_context.JokeService.Object);
        }

        [TestMethod]
        public void Should_Return_The_Result_From_Categories()
        {
            List<CategoryModel> actual = _getAllCategoriesQuery.Execute();
            List<CategoryModel> expected = _context.CategoryModels;

            var jsonActual = JsonConvert.SerializeObject(actual);
            var jsonExpected = JsonConvert.SerializeObject(expected);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }
    }
}
