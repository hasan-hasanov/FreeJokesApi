using Core.Commands;

namespace Adapter.Database.Commands.RateJoke
{
    public class RateJokeCommand : ICommand
    {
        public RateJokeCommand(long jokeId, float rating)
        {
            JokeId = jokeId;
            Rating = rating;
        }

        public long JokeId { get; }

        public float Rating { get; }
    }
}
