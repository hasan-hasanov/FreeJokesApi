using System;

namespace Core.Entities
{
    public class JokeRating
    {
        public long Id { get; set; }

        public float Rating { get; set; }

        public long JokeId { get; set; }

        public DateTime CreateDate { get; set; }

        public Joke Joke { get; set; }
    }
}
