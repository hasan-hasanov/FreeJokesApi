using Domain.Entities;
using NUnit.Framework;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Domain.Test.CategoryTests
{
    public class CategoryTests
    {
        private readonly Category _category;

        private const int Id = 1;
        private const string Description = "Test";


        public CategoryTests()
        {
            _category = new Category();
        }

        [Fact]
        public void TestSetAndGetId()
        {
            _category.Id = Id;

            Assert.That(_category.Id, Is.EqualTo(Id));
        }

        [Fact]
        public void TestSetAndGetDescription()
        {
            _category.Description = Description;

            Assert.That(_category.Description, Is.EqualTo(Description));
        }
    }
}
