using Adapter.Database.Commands.PublishJoke;
using Core.Commands;
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
        private readonly ICommandHandler<PublishJokeCommand> _publishJokeCommandHandler;

        public PublishJokeHandler(
            IValidation<PublishJokeRequestModel> publishJokeValidation,
            ICommandHandler<PublishJokeCommand> publishJokeCommandHandler)
        {
            _publishJokeValidation = publishJokeValidation;
            _publishJokeCommandHandler = publishJokeCommandHandler;
        }

        protected override async Task Handle(PublishJokeRequestModel request, CancellationToken cancellationToken)
        {
            await _publishJokeValidation.Validate(request);
            await _publishJokeCommandHandler.HandleAsync(
                new PublishJokeCommand(request.Category, request.Parts, request.Flags),
                cancellationToken);
        }
    }
}
