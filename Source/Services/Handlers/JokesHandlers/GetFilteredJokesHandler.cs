using Adapter.Database.Queries.GetAllCategoriesByNames;
using Adapter.Database.Queries.GetFilteredJokes;
using Adapter.Database.Queries.GetFlagsByNames;
using Core.Entities;
using Core.Queries;
using Core.Validations;
using MediatR;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.JokesHandlers
{
    public class GetFilteredJokesHandler : IRequestHandler<JokesFilterRequestModel, IList<JokeResponseModel>>
    {
        private readonly IValidation<JokesFilterRequestModel> _jokesFilterValidation;
        private readonly IQueryHandler<GetFlagsByNamesQuery, IList<Flag>> _getFlagsByNamesQuery;
        private readonly IQueryHandler<GetCategoriesByNamesQuery, IList<Category>> _getAllCategoriesByNamesQuery;
        private readonly IQueryHandler<GetFilteredJokesQuery, IList<Joke>> _getFilteredJokesQueryHandler;

        public GetFilteredJokesHandler(
            IValidation<JokesFilterRequestModel> jokesFilterValidation,
            IQueryHandler<GetFlagsByNamesQuery, IList<Flag>> getFlagsByNamesQuery,
            IQueryHandler<GetCategoriesByNamesQuery, IList<Category>> getAllCategoriesByNamesQuery,
            IQueryHandler<GetFilteredJokesQuery, IList<Joke>> getFilteredJokesQueryHandler)
        {
            _jokesFilterValidation = jokesFilterValidation;
            _getFlagsByNamesQuery = getFlagsByNamesQuery;
            _getAllCategoriesByNamesQuery = getAllCategoriesByNamesQuery;
            _getFilteredJokesQueryHandler = getFilteredJokesQueryHandler;
        }

        public async Task<IList<JokeResponseModel>> Handle(JokesFilterRequestModel request, CancellationToken cancellationToken)
        {
            await _jokesFilterValidation.Validate(request, cancellationToken);

            IList<Flag> flags = request.Flags != null ?
                await _getFlagsByNamesQuery.HandleAsync(new GetFlagsByNamesQuery(request.Flags), cancellationToken) :
                null;
            IList<Category> categories = request.Categories != null ?
                await _getAllCategoriesByNamesQuery.HandleAsync(new GetCategoriesByNamesQuery(request.Categories), cancellationToken) :
                null;

            IList<Joke> jokesEntity = await _getFilteredJokesQueryHandler.HandleAsync(
                new GetFilteredJokesQuery(
                    flags?.Select(f => f.Id).ToList(),
                    categories?.Select(f => f.Id).ToList(),
                    request.Random,
                    request.Page,
                    request.PageSize),
                cancellationToken);

            List<JokeResponseModel> jokes = new List<JokeResponseModel>();
            foreach (var joke in jokesEntity)
            {
                var rating = joke.Ratings != null && joke.Ratings.Any() ?
                    joke.Ratings.Sum(r => r.JokeRating) / joke.Ratings.Count :
                    0;
                if (request.RatingMin <= rating && request.RatingMax >= rating)
                {
                    jokes.Add(new JokeResponseModel(joke, rating));
                }
            }

            return jokes;
        }
    }
}
