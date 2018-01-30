using Domain.Common;

namespace Domain.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
