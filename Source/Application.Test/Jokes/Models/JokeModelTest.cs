using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Jokes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Application.Test.Jokes.Models
{
    [TestClass]
    public class JokeModelTest
    {
        private readonly JokeModel _jokeModel;

        private const string Id = "d5f812512f7f426999f9daf79b78fe73";
        private const string Description = "Hilarious Joke";
        private const string Category = "Stupid";

        public JokeModelTest()
        {
            _jokeModel = new JokeModel();
        }

        [TestMethod]
        public void TestSetAndGetId()
        {
            _jokeModel.Id = Id;

            Assert.That(_jokeModel.Id, Is.EqualTo(Id));
        }

        [TestMethod]
        public void TestSetAndGetDescription()
        {
            _jokeModel.Description = Description;

            Assert.That(_jokeModel.Description, Is.EqualTo(Description));
        }

        [TestMethod]
        public void TestSetAndGetCategoryId()
        {
            _jokeModel.Category = Category;

            Assert.That(_jokeModel.Category, Is.EqualTo(Category));
        }
    }
}
