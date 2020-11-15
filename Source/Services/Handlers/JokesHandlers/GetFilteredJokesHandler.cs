using Core.Validations;
using MediatR;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.JokesHandlers
{
    public class GetFilteredJokesHandler : IRequestHandler<JokesFilterRequestModel, IList<JokeResponseModel>>
    {
        private readonly IValidation<JokesFilterRequestModel> _jokesFilterValidation;

        public GetFilteredJokesHandler(IValidation<JokesFilterRequestModel> jokesFilterValidation)
        {
            _jokesFilterValidation = jokesFilterValidation;
        }

        public async Task<IList<JokeResponseModel>> Handle(JokesFilterRequestModel request, CancellationToken cancellationToken)
        {
            await _jokesFilterValidation.Validate(request);

            throw new System.NotImplementedException();
        }
    }
}
