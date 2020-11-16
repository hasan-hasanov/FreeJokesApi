using Core.Entities;
using Core.Queries;
using System.Collections.Generic;

namespace Adapter.Database.Queries.GetFlagsByName
{
    public class GetFlagsByNamesQuery : IQuery<IList<Flag>>
    {
        public GetFlagsByNamesQuery(List<string> flagNames)
        {
            FlagNames = flagNames;
        }

        public List<string> FlagNames { get; }
    }
}
