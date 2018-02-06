using Application.Categories.Models;
using Application.Categories.Queries.GetAllCategoriesQuery.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Application.Test.Categories.Queries.GetAllCategoriesQuery
{
    [TestClass]
    public class GetAllCategoriesQueryTest
    {
        private readonly UnitTestContext _context;
        private readonly IGetAllCategoriesQuery _getAllCategoriesQuery;

        public GetAllCategoriesQueryTest()
        {
            _context = new UnitTestContext();

            Mock<IGetAllCategoriesQuery> getAllCategoriesQueryMock = new Mock<IGetAllCategoriesQuery>();
            getAllCategoriesQueryMock.Setup(c => c.Execute()).Returns(_context.CategoryModels);

            _getAllCategoriesQuery = getAllCategoriesQueryMock.Object;
        }

        [TestMethod]
        public void Should_Return_The_Result_From_Categories()
        {
            List<CategoryModel> categories = _getAllCategoriesQuery.Execute();
            List<CategoryModel> expected = _context.CategoryModels;

            Assert.AreSame(categories, expected);
        }
    }
}
