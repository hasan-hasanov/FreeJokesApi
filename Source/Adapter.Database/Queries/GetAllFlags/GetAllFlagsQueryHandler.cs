using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetAllFlags
{
    public class GetAllFlagsQueryHandler : IQueryHandler<GetAllFlagsQuery, IList<Flag>>
    {
        private readonly JokesContext _context;

        public GetAllFlagsQueryHandler(JokesContext context)
        {
            _context = context;
        }

        public async Task<IList<Flag>> HandleAsync(GetAllFlagsQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = _context.Flags;
            return await dbQuery.ToListAsync(cancellationToken);
        }
    }
}
