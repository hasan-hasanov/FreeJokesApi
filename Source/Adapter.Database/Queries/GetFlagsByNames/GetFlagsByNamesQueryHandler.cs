using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetFlagsByNames
{
    public class GetFlagsByNamesQueryHandler : IQueryHandler<GetFlagsByNamesQuery, IList<Flag>>
    {
        private readonly JokesContext _context;

        public GetFlagsByNamesQueryHandler(JokesContext context)
        {
            _context = context;
        }

        public async Task<IList<Flag>> HandleAsync(GetFlagsByNamesQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = await _context.Flags
                .Where(f => query.FlagNames.Any(q => q.ToLower() == f.Name.ToLower()))
                .ToListAsync(cancellationToken);

            return dbQuery;
        }
    }
}
