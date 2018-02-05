using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using NUnit.Framework;

namespace Domain.Test.JokeTests
{
    public class JokeTests
    {
        private readonly Joke _joke;

        private const string Id = "c7792486993046b3856a1de6f7c1e6cf";
        private const string Description = "Hilarious joke";
        private const int CategoryId = 1;

        public JokeTests()
        {
            _joke = new Joke();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _joke.Id = Id;

            Assert.That(_joke.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetDescription()
        {
            _joke.Description = Description;

            Assert.That(_joke.Description, Is.EqualTo(Description));
        }

        [Test]
        public void TestSetAndGetCategoryId()
        {
            _joke.CategoryId = CategoryId;

            Assert.That(_joke.CategoryId, Is.EqualTo(CategoryId));
        }
    }
}
