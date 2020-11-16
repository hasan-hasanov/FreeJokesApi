using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetAllCategoriesByNames
{
    public class GetCategoriesByNamesQueryHandler : IQueryHandler<GetCategoriesByNamesQuery, IList<Category>>
    {
        private readonly JokesContext _context;

        public GetCategoriesByNamesQueryHandler(JokesContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> HandleAsync(GetCategoriesByNamesQuery query, CancellationToken cancellationToken = default)
        {
            // TODO: Fix this with something that EF can translate properly or ditch it.
            var dbQuery = await _context.Categories
                .ToListAsync(cancellationToken);

            return dbQuery.Where(c => query.CategoryNames.Any(qc => qc.ToLower() == c.Name.ToLower())).ToList();
        }
    }
}
