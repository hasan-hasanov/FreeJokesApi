using Core.Entities;
using Core.Queries;

namespace Adapter.Database.Queries.GetJokeById
{
    public class GetJokeByIdQuery : IQuery<Joke>
    {
        public GetJokeByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
