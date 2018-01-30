using Domain.Common;

namespace Domain.Entities
{
    public class Joke : IEntity<string>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
