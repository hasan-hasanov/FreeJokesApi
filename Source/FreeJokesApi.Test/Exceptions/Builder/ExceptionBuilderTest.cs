using FreeJokesApi.Exceptions.Builder;
using FreeJokesApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Hosting.Internal;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace FreeJokesApi.Test.Exceptions.Builder
{
    [TestClass]
    public class ExceptionBuilderTest
    {
        private readonly ExceptionBuilder _exceptionBuilder;

        public ExceptionBuilderTest()
        {
            _exceptionBuilder = new ExceptionBuilder();
        }

        [TestMethod]
        public void Should_Return_Debug_Exceptions()
        {
            Mock<IHostingEnvironment> env = new Mock<IHostingEnvironment>();

            Mock<Exception> exMock = new Mock<Exception>();
            exMock.SetupGet(e => e.Message).Returns("This is a mock exception Message");
            exMock.SetupGet(e => e.StackTrace).Returns("This is a mock exception Stack Trace");

            ApiErrorModel actual = _exceptionBuilder.BuildException(exMock.Object, env.Object);
            ApiErrorModel expected = new ApiErrorModel()
            {
                Message = "This is a mock exception Message",
                Details = "This is a mock exception Stack Trace"
            };

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.That(expectedJson, Is.EqualTo(actualJson));
        }
    }

    public static class MockExtensions
    {
        private static IHostingEnvironment defaultHostingEnvironment = new HostingEnvironment();

        public static IHostingEnvironment MockedHostingEnvironment { private get; set; } = defaultHostingEnvironment;

        public static void RevertToDefaultImplementation()
        {
            MockedHostingEnvironment = defaultHostingEnvironment;
        }

        public static bool IsDevelopment(this string hostingEnvironment)
        {
            return true;
        }
    }
}
