using Core.Entities;
using Core.Queries;
using System.Collections.Generic;

namespace Adapter.Database.Queries.GetFlagsByNames
{
    public class GetFlagsByNamesQuery : IQuery<IList<Flag>>
    {
        public GetFlagsByNamesQuery(IList<string> flagNames)
        {
            FlagNames = flagNames;
        }

        public IList<string> FlagNames { get; }
    }
}
