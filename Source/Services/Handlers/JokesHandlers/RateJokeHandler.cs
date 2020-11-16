using Adapter.Database.Commands.RateJoke;
using Core.Commands;
using Core.Validations;
using MediatR;
using Services.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.JokesHandlers
{
    public class RateJokeHandler : AsyncRequestHandler<RateJokeRequestModel>
    {
        private readonly IValidation<RateJokeRequestModel> _rateJokeValidation;
        private readonly ICommandHandler<RateJokeCommand> _rateJokeCommandHandler;

        public RateJokeHandler(
            IValidation<RateJokeRequestModel> rateJokeValidation,
            ICommandHandler<RateJokeCommand> rateJokeCommandHandler)
        {
            _rateJokeValidation = rateJokeValidation;
            _rateJokeCommandHandler = rateJokeCommandHandler;
        }

        protected override async Task Handle(RateJokeRequestModel request, CancellationToken cancellationToken)
        {
            await _rateJokeValidation.Validate(request);
            await _rateJokeCommandHandler.HandleAsync(new RateJokeCommand(request.JokeId, request.Rating), cancellationToken);
        }
    }
}
