﻿using Adapter.Database.Contexts;
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
        private readonly ILogger<GetAllCategoriesQueryHandler> _logger;
        private readonly JokesContext _context;

        public GetAllCategoriesQueryHandler(
            ILogger<GetAllCategoriesQueryHandler> logger,
            JokesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Category>> HandleAsync(GetAllCategoriesQuery query, CancellationToken cancellationToken = default)
        {
            var dbQuery = _context.Categories;
            _logger.LogDebug(dbQuery.ToQueryString());

            return await dbQuery.ToListAsync(cancellationToken);
        }
    }
}