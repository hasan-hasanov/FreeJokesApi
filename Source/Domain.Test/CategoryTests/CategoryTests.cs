using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using NUnit.Framework;

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

        [Test]
        public void TestSetAndGetId()
        {
            _category.Id = Id;

            Assert.That(_category.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetDescription()
        {
            _category.Description = Description;

            Assert.That(_category.Description, Is.EqualTo(Description));
        }
    }
}
