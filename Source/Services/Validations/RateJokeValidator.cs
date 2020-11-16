using Adapter.Database.Queries.GetJokeById;
using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validations;
using Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class RateJokeValidator : IValidation<RateJokeRequestModel>
    {
        private readonly IQueryHandler<GetJokeByIdQuery, Joke> _getJokeByIdQuery;

        public RateJokeValidator(IQueryHandler<GetJokeByIdQuery, Joke> getJokeByIdQuery)
        {
            _getJokeByIdQuery = getJokeByIdQuery;
        }

        public async Task Validate(RateJokeRequestModel model, CancellationToken cancellationToken = default)
        {
            List<string> errorMessages = new List<string>();

            var joke = await _getJokeByIdQuery.HandleAsync(new GetJokeByIdQuery(model.JokeId), cancellationToken);
            if (joke == null)
            {
                errorMessages.Add($"Joke with id {model.JokeId} is not found");
            }

            if (model.Rating < 1 && model.Rating > 10)
            {
                errorMessages.Add($"Rating should be in range [1 10]");
            }

            if (errorMessages.Any())
            {
                throw new BadRequestException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
