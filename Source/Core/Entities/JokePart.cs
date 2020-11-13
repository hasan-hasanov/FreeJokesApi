namespace Core.Entities
{
    public class JokePart
    {
        public long Id { get; set; }

        public long JokeId { get; set; }

        public int Order { get; set; }

        public string Part { get; set; }

        public Joke Joke { get; set; }
    }
}
