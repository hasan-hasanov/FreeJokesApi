using Core.Entities;
using Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter.Database.Queries.GetFlagsByNames
{
    public class GetFlagsByNamesQuery : IQuery<IList<Flag>>
    {
        public GetFlagsByNamesQuery(IList<string> flagNames)
        {
            if (flagNames == null || !flagNames.Any())
            {
                throw new ArgumentNullException(nameof(flagNames));
            }

            FlagNames = flagNames;
        }

        public IList<string> FlagNames { get; }
    }
}
