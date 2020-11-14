using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Joke
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public DateTime CreateDate { get; set; }

        public Category Category { get; set; }

        public ICollection<Part> JokeParts { get; set; }

        public ICollection<JokeFlag> JokeFlags { get; set; }

        public ICollection<Rating> JokeRatings { get; set; }
    }
}
