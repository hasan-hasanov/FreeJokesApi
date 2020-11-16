using Core.Entities;
using Core.Queries;
using System.Collections.Generic;

namespace Adapter.Database.Queries.GetFilteredJokes
{
    public class GetFilteredJokesQuery : IQuery<IList<Joke>>
    {
        public GetFilteredJokesQuery(
            IList<long> flagIds,
            IList<long> categoryIds,
            bool random,
            int page,
            int pageSize)
        {
            FlagIds = flagIds ?? new List<long>();
            CategoryIds = categoryIds ?? new List<long>();
            Random = random;
            Page = page;
            PageSize = pageSize;
        }

        public IList<long> FlagIds { get; }

        public IList<long> CategoryIds { get; }

        public bool Random { get; }

        public int Page { get; }

        public int PageSize { get; }
    }
}
