namespace Core.Entities
{
    public class Part
    {
        public long Id { get; set; }

        public long JokeId { get; set; }

        public int Order { get; set; }

        public string JokePart { get; set; }

        public Joke Joke { get; set; }
    }
}
