using MediatR;

namespace Services.Models.RequestModels
{
    public class RateJokeRequestModel : IRequest
    {
        public long JokeId { get; set; }

        public float Rating { get; set; }
    }
}
