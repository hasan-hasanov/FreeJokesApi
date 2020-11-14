using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetAllFlags
{
    public class GetAllFlagsQueryHandler : IQueryHandler<GetAllFlagsQuery, IList<Flag>>
    {
        private readonly ILogger<GetAllFlagsQueryHandler> _logger;
        private readonly JokesContext _context;

        public GetAllFlagsQueryHandler(
            ILogger<GetAllFlagsQueryHandler> logger,
            JokesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Flag>> HandleAsync(GetAllFlagsQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = _context.Flags;
            _logger.LogDebug(dbQuery.ToQueryString());

            return await dbQuery.ToListAsync(cancellationToken);
        }
    }
}
