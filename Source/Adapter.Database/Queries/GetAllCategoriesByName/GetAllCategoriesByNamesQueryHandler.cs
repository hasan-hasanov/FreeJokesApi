using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetAllCategoriesByName
{
    public class GetAllCategoriesByNamesQueryHandler : IQueryHandler<GetAllCategoriesByNamesQuery, IList<Category>>
    {
        private readonly JokesContext _context;

        public GetAllCategoriesByNamesQueryHandler(JokesContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> HandleAsync(GetAllCategoriesByNamesQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = await _context.Categories
                .Where(c => query.CategoryNames.Any(qc => qc.ToLower() == c.Name.ToLower()))
                .ToListAsync(cancellationToken);

            return dbQuery;
        }
    }
}
