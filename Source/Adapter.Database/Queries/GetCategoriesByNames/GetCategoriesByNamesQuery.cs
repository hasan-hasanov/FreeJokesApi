using Core.Entities;
using Core.Queries;
using System.Collections.Generic;

namespace Adapter.Database.Queries.GetAllCategoriesByNames
{
    public class GetCategoriesByNamesQuery : IQuery<IList<Category>>
    {
        public GetCategoriesByNamesQuery(IList<string> categoryNames)
        {
            CategoryNames = categoryNames;
        }

        public IList<string> CategoryNames { get; }
    }
}
