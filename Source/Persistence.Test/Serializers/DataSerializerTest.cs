using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.Serializers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using Domain.Entities;
using Newtonsoft.Json;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Persistence.Test.Serializers
{
    [TestClass]
    public class DataSerializerTest
    {
        private readonly DataSerializer _dataSerializer;

        public DataSerializerTest()
        {
            MockFileSystem fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                { $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Jokes.json", new MockFileData(BuildJokesJson()) },
                { $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Categories.json", new MockFileData(BuildCategoriesJson()) }
            });

            _dataSerializer = new DataSerializer(fileSystem);
        }

        [TestMethod]
        public void Should_Read_Jokes_From_Json()
        {
            IEnumerable<Joke> actual = _dataSerializer.SerializeJokes();
            IEnumerable<Joke> expected = BuildJokesObject();

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }

        [TestMethod]
        public void Should_Read_Categories_From_Json()
        {
            IEnumerable<Category> actual = _dataSerializer.SerializerCategories();
            IEnumerable<Category> expected = BuildCategoriesObject();

            string actualJson = JsonConvert.SerializeObject(actual);
            string expectedJson = JsonConvert.SerializeObject(expected);

            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }

        private static IEnumerable<Joke> BuildJokesObject()
        {
            return new List<Joke>()
            {
                new Joke()
                {
                    Id = "5920ff05d9ab4203bb8a55b91fbf2250",
                    Description = "Test Joke 1.",
                    CategoryId = 1
                },
                new Joke()
                {
                    Id = "81f67fdbf552427d95c3d40ad42bf142",
                    Description = "Test Joke 2.",
                    CategoryId = 1
                },
                new Joke()
                {
                    Id = "aaba4d9eea304971a22227a0f4fbdd39",
                    Description = "Test Joke 3.",
                    CategoryId = 1
                },
            };
        }

        private static IEnumerable<Category> BuildCategoriesObject()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Description = "Test Category 1"
                },
                new Category()
                {
                    Id = 2,
                    Description = "Test Category 2"
                }
            };
        }

        private static string BuildJokesJson()
        {
            return @"{
                        ""jokes"": [{
			                ""id"": ""5920ff05d9ab4203bb8a55b91fbf2250"",
			                ""description"": ""Test Joke 1."",
			                ""categoryId"": 1
		                },
                        {
                            ""id"": ""81f67fdbf552427d95c3d40ad42bf142"",
                            ""description"": ""Test Joke 2."",
                            ""categoryId"": 1
                        },
                        {
                            ""id"": ""aaba4d9eea304971a22227a0f4fbdd39"",
                            ""description"": ""Test Joke 3."",
                            ""categoryId"": 1
                        }]
                    }";
        }

        private static string BuildCategoriesJson()
        {
            return @"{
                        ""categories"": [{
                            ""id"": ""1"",
                            ""description"": ""Test Category 1""
                        },
                        {
                            ""id"": ""2"",
                            ""description"": ""Test Category 2""
                        }]
                    }";
        }
    }
}