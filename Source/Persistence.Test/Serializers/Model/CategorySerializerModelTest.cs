using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using Persistence.Serializers.Model;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Persistence.Test.Serializers.Model
{
    [TestClass]
    public class CategorySerializerModelTest
    {
        private readonly List<Category> _categories;
        private readonly CategorySerializerModel _categorySerializerModel;

        public CategorySerializerModelTest()
        {
            _categories = BuildCategoriesMock();
            _categorySerializerModel = new CategorySerializerModel();
        }

        [TestMethod]
        public void Test_Set_And_Get_Categories()
        {
            _categorySerializerModel.Categories = _categories;

            string expectedJson = JsonConvert.SerializeObject(_categories);
            string actualJson = JsonConvert.SerializeObject(_categorySerializerModel.Categories);

            Assert.That(expectedJson, Is.EqualTo(actualJson));
        }

        private List<Category> BuildCategoriesMock()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Description = "Test 1"
                },
                new Category()
                {
                    Id = 2,
                    Description = "Test 2"
                },
                new Category()
                {
                    Id = 3,
                    Description = "Test 3"
                }
            };
        }
    }
}
