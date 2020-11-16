using Core.Entities;
using Core.Queries;
using System.Collections.Generic;

namespace Adapter.Database.Queries.GetAllCategoriesByName
{
    public class GetAllCategoriesByNamesQuery : IQuery<IList<Category>>
    {
        public GetAllCategoriesByNamesQuery(List<string> categoryNames)
        {
            CategoryNames = categoryNames;
        }

        public List<string> CategoryNames { get; }
    }
}
