using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetFilteredJokes
{
    public class GetFilteredJokesQueryHandler : IQueryHandler<GetFilteredJokesQuery, IList<Joke>>
    {
        private readonly JokesContext _context;

        public GetFilteredJokesQueryHandler(JokesContext context)
        {
            _context = context;
        }

        public async Task<IList<Joke>> HandleAsync(GetFilteredJokesQuery query, CancellationToken cancellationToken = default)
        {
            List<Joke> jokes = new List<Joke>();
            IQueryable<Joke> dbQuery = _context.Jokes
                .Include(j => j.Category)
                .Include(j => j.JokeFlags)
                .ThenInclude(j => j.Flag)
                .Include(j => j.Ratings)
                .Include(j => j.Parts)
                .AsQueryable();

            if (query.FlagIds.Any())
            {
                dbQuery.Where(j => query.FlagIds.Any(f => j.JokeFlags.Select(jf => jf.FlagId).Contains(f)));
            }

            if (query.CategoryIds.Any())
            {
                dbQuery.Where(j => query.CategoryIds.Contains(j.CategoryId));
            }

            if (query.Random)
            {
                // Since the maximum amount of PageSize cannot exceed 100 this simple solution will work.
                jokes = await dbQuery
                    .Take(query.PageSize)
                    .OrderBy(x => Guid.NewGuid())
                    .ToListAsync(cancellationToken);
            }
            else
            {
                jokes = await dbQuery
                    .Skip((query.Page - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .ToListAsync(cancellationToken);
            }

            return jokes ?? new List<Joke>();
        }
    }
}
