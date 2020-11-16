using Adapter.Database.Contexts;
using Adapter.Database.Queries.GetAllCategoriesByNames;
using Adapter.Database.Queries.GetFlagsByNames;
using Core.Commands;
using Core.Entities;
using Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.Database.Commands.PublishJoke
{
    public class PublishJokeCommandHandler : ICommandHandler<PublishJokeCommand>
    {
        private readonly JokesContext _context;
        private readonly IQueryHandler<GetFlagsByNamesQuery, IList<Flag>> _getFlagsByNamesQuery;
        private readonly IQueryHandler<GetCategoriesByNamesQuery, IList<Category>> _getCategoriesByNamesQuery;

        public PublishJokeCommandHandler(
            JokesContext context,
            IQueryHandler<GetFlagsByNamesQuery, IList<Flag>> getFlagsByNamesQuery,
            IQueryHandler<GetCategoriesByNamesQuery, IList<Category>> getCategoriesByNamesQuery)
        {
            _context = context;
            _getFlagsByNamesQuery = getFlagsByNamesQuery;
            _getCategoriesByNamesQuery = getCategoriesByNamesQuery;
        }

        public async Task HandleAsync(PublishJokeCommand command, CancellationToken cancellationToken = default)
        {
            IList<Flag> flags = await _getFlagsByNamesQuery.HandleAsync(new GetFlagsByNamesQuery(command.Flags));
            IList<Category> categories = await _getCategoriesByNamesQuery.HandleAsync(new GetCategoriesByNamesQuery(new List<string> { command.Category }));

            Joke joke = new Joke
            {
                CategoryId = categories.First().Id,
                CreateDate = DateTime.Now,
                JokeFlags = flags.Select(f => new JokeFlag()
                {
                    FlagId = f.Id,
                }).ToList(),
                Parts = command.Parts.Select((p, i) => new Part()
                {
                    JokePart = p,
                    Order = i
                }).ToList()
            };

            await _context.Jokes.AddAsync(joke);
        }
    }
}
