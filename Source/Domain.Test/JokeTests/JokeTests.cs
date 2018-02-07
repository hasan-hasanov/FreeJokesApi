using Domain.Entities;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

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
        public void Test_Set_And_Get_Id()
        {
            _joke.Id = Id;

            Assert.That(_joke.Id, Is.EqualTo(Id));
        }

        [Test]
        public void Test_Set_And_Get_Description()
        {
            _joke.Description = Description;

            Assert.That(_joke.Description, Is.EqualTo(Description));
        }

        [Test]
        public void Test_Set_And_Get_Category_Id()
        {
            _joke.CategoryId = CategoryId;

            Assert.That(_joke.CategoryId, Is.EqualTo(CategoryId));
        }
    }
}
