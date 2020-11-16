using MediatR;
using System.Collections.Generic;

namespace Services.Models.RequestModels
{
    public class PublishJokeRequestModel : IRequest
    {
        public string Category { get; set; }

        public List<string> Parts { get; set; }

        public List<string> Flags { get; set; }
    }
}
