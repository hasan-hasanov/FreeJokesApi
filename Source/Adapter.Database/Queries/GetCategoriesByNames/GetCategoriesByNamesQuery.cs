using Core.Entities;
using Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter.Database.Queries.GetAllCategoriesByNames
{
    public class GetCategoriesByNamesQuery : IQuery<IList<Category>>
    {
        public GetCategoriesByNamesQuery(IList<string> categoryNames)
        {
            if (categoryNames == null || !categoryNames.Any())
            {
                throw new ArgumentException(nameof(categoryNames));
            }

            CategoryNames = categoryNames;
        }

        public IList<string> CategoryNames { get; }
    }
}
