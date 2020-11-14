using Core.Entities;

namespace Services.Models.ResponseModels
{
    public class CategoryResponseModel
    {
        public CategoryResponseModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}
