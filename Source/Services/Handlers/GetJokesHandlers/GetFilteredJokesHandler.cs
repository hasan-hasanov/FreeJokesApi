using Core.Validations;
using MediatR;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.GetJokesHandlers
{
    public class GetFilteredJokesHandler : IRequestHandler<JokesFilter, IList<JokeResponseModel>>
    {
        private readonly IValidation<JokesFilter> _jokesFilterValidation;

        public GetFilteredJokesHandler(IValidation<JokesFilter> jokesFilterValidation)
        {
            _jokesFilterValidation = jokesFilterValidation;
        }

        public async Task<IList<JokeResponseModel>> Handle(JokesFilter request, CancellationToken cancellationToken)
        {
            await _jokesFilterValidation.Validate(request);

            throw new System.NotImplementedException();
        }
    }
}
