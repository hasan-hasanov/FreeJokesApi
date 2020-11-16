using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetJokeById
{
    public class GetJokeByIdQueryHandler : IQueryHandler<GetJokeByIdQuery, Joke>
    {
        private readonly JokesContext _context;

        public GetJokeByIdQueryHandler(JokesContext context)
        {
            _context = context;
        }

        public async Task<Joke> HandleAsync(GetJokeByIdQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = await _context.Jokes
                .Include(j => j.Ratings)
                .FirstOrDefaultAsync(j => j.Id == query.Id);

            return dbQuery;
        }
    }
}
