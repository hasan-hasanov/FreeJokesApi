using Core.Validations;
using MediatR;
using Services.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.JokesHandlers
{
    public class PublishJokeHandler : AsyncRequestHandler<PublishJokeRequestModel>
    {
        private readonly IValidation<PublishJokeRequestModel> _publishJokeValidation;

        public PublishJokeHandler(IValidation<PublishJokeRequestModel> publishJokeValidation)
        {
            _publishJokeValidation = publishJokeValidation;
        }

        protected override async Task Handle(PublishJokeRequestModel request, CancellationToken cancellationToken)
        {
            await _publishJokeValidation.Validate(request);

            throw new System.NotImplementedException();
        }
    }
}
