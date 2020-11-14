using Core.Entities;

namespace Services.Models.ResponseModels
{
    public class CategoriesResponseModel
    {
        public CategoriesResponseModel() { }

        public CategoriesResponseModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
