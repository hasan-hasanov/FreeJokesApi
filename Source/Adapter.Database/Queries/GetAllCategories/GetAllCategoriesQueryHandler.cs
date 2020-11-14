using Adapter.Database.Contexts;
using Core.Entities;
using Core.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IList<Category>>
    {
        private readonly JokesContext _context;
        private readonly ILogger<GetAllCategoriesQueryHandler> _logger;

        public GetAllCategoriesQueryHandler(JokesContext context, ILogger<GetAllCategoriesQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IList<Category>> HandleAsync(GetAllCategoriesQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = _context.Categories;
            _logger.LogDebug(dbQuery.ToQueryString());

            return await dbQuery.ToListAsync();
        }
    }
}
