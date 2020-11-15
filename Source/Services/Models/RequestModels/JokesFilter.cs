using Core.Entities;
using MediatR;
using Services.Models.ResponseModels;
using System.Collections.Generic;

namespace Services.Models.RequestModels
{
    public class JokesFilter : IRequest<IList<JokeResponseModel>>
    {
        public JokesFilter()
        {
            RatingMin = 0;
            RatingMax = 10;
            Random = true;
            PageSize = 10;
            Page = 1;
        }

        public List<string> Flags { get; set; }

        public List<string> Categories { get; set; }

        public int RatingMin { get; set; }

        public int RatingMax { get; set; }

        public bool Random { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
