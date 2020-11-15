using MediatR;
using System.Collections.Generic;

namespace Services.Models.RequestModels
{
    public class PublishJokeRequestModel : IRequest
    {
        public long CategoryId { get; set; }

        public List<string> Parts { get; set; }

        public List<int> Flags { get; set; }
    }
}
