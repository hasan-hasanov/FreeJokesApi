using System.Collections.Generic;

namespace Core.Entities
{
    public class Flag
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<JokeFlag> JokeFlags { get; set; }
    }
}
