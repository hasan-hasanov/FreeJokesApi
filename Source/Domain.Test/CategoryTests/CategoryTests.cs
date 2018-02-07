using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Domain.Test.CategoryTests
{
    [TestClass]
    public class CategoryTests
    {
        private readonly Category _category;

        private const int Id = 1;
        private const string Description = "Test";

        public CategoryTests()
        {
            _category = new Category();
        }

        [TestMethod]
        public void Test_Set_And_Get_Category_Id()
        {
            _category.Id = Id;

            Assert.That(_category.Id, Is.EqualTo(Id));
        }

        [TestMethod]
        public void Test_Set_And_Get_Category_Description()
        {
            _category.Description = Description;

            Assert.That(_category.Description, Is.EqualTo(Description));
        }
    }
}
