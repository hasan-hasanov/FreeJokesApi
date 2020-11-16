using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IList<Category>>
    {
        private readonly JokesContext _context;

        public GetAllCategoriesQueryHandler(JokesContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> HandleAsync(GetAllCategoriesQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = _context.Categories;
            return await dbQuery.ToListAsync(cancellationToken);
        }
    }
}
