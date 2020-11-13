using System.Collections.Generic;

namespace Core.Entities
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Joke> Jokes { get; set; }
    }
}
