using Adapter.Database.Contexts;
using Adapter.Database.Queries.GetJokeById;
using Core.Commands;
using Core.Entities;
using Core.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Commands.RateJoke
{
    public class RateJokeCommandHandler : ICommandHandler<RateJokeCommand>
    {
        private readonly JokesContext _context;
        private readonly IQueryHandler<GetJokeByIdQuery, Joke> _getJokeByIdQueryHandler;

        public RateJokeCommandHandler(
            JokesContext context,
            IQueryHandler<GetJokeByIdQuery, Joke> getJokeByIdQueryHandler)
        {
            _context = context;
            _getJokeByIdQueryHandler = getJokeByIdQueryHandler;
        }

        public async Task HandleAsync(RateJokeCommand command, CancellationToken cancellationToken = default)
        {
            var joke = await _getJokeByIdQueryHandler.HandleAsync(new GetJokeByIdQuery(command.JokeId));
            joke.Ratings.Add(new Rating()
            {
                JokeId = command.JokeId,
                JokeRating = command.Rating,
                CreateDate = DateTime.Now
            });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
