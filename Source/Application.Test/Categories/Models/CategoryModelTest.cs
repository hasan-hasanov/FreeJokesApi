using Application.Categories.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Application.Test.Categories.Models
{
    [TestClass]
    public class CategoryModelTest
    {
        private readonly CategoryModel _categoryModel;

        private const int Id = 1;
        private const string Name = "Test";


        public CategoryModelTest()
        {
            _categoryModel = new CategoryModel();
        }

        [TestMethod]
        public void TestSetAndGetId()
        {
            _categoryModel.Id = Id;

            Assert.That(_categoryModel.Id, Is.EqualTo(Id));
        }

        [TestMethod]
        public void TestSetAndGetDescription()
        {
            _categoryModel.Name = Name;

            Assert.That(_categoryModel.Name, Is.EqualTo(Name));
        }
    }
}
