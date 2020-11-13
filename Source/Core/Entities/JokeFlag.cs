namespace Core.Entities
{
    public class JokeFlag
    {
        public long Id { get; set; }

        public long JokeId { get; set; }

        public long FlagId { get; set; }

        public Joke Joke { get; set; }

        public Flag Flag { get; set; }
    }
}
