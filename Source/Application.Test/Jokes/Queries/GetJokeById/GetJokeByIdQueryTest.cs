using Application.Jokes.Models;
using Application.Jokes.Queries.GetJokeById;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace Application.Test.Jokes.Queries.GetJokeById
{
    [TestClass]
    public class GetJokeByIdQueryTest
    {
        private readonly UnitTestContext _context;
        private readonly GetJokeByIdQuery _getJokeByIdQuery;

        public GetJokeByIdQueryTest()
        {
            _context = new UnitTestContext();

            _getJokeByIdQuery = new GetJokeByIdQuery(_context.JokeService.Object);
        }

        [DataTestMethod]
        [DataRow("d5f812512f7f426999f9daf79b78fe73")]
        [DataRow("9734f88b513c4f88a51eb829ee3f3ce1")]
        [DataRow("cfe96a38ae9c49b3b2922c0ca3aecec4")]
        [DataRow("2cbcff3a6fc443d18e6c36cbb25370d0")]
        [DataRow("5e150abacd2d46caa1955f81a0dd038a")]
        [DataRow("002515add8124a4a8072bdb6f1dbf3bb")]
        [DataRow("eaaf9a581b39486eb6cd49d3a3880402")]
        public void Should_Return_Joke_By_Id(string id)
        {
            JokeModel actual = _getJokeByIdQuery.Execute(id);
            JokeModel expected = _context.JokeModels.First(j => j.Id == id);

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        [DataRow("IdThatIsNotInTheDataSource")]
        public void Should_Return_Null_For_Null_Empty_Or_Not_Found_Id(string id)
        {
            JokeModel actual = _getJokeByIdQuery.Execute(id);

            Assert.IsNull(actual);
        }
    }
}
