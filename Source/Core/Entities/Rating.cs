using System;

namespace Core.Entities
{
    public class Rating
    {
        public long Id { get; set; }

        public float JokeRating { get; set; }

        public long JokeId { get; set; }

        public DateTime CreateDate { get; set; }

        public Joke Joke { get; set; }
    }
}
