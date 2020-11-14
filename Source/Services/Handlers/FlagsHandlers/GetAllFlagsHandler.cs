using Adapter.Database.Queries.GetAllFlags;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.FlagsHandlers
{
    public class GetAllFlagsHandler : IRequestHandler<GetAllFlagsRequestModel, IList<FlagResponseModel>>
    {
        private readonly IQueryHandler<GetAllFlagsQuery, IList<Flag>> _getAllFlagsQueryHandler;

        public GetAllFlagsHandler(IQueryHandler<GetAllFlagsQuery, IList<Flag>> getAllFlagsQueryHandler)
        {
            _getAllFlagsQueryHandler = getAllFlagsQueryHandler;
        }

        public async Task<IList<FlagResponseModel>> Handle(GetAllFlagsRequestModel request, CancellationToken cancellationToken)
        {
            IList<Flag> allFlags = await _getAllFlagsQueryHandler.HandleAsync(new GetAllFlagsQuery());
            return allFlags.Select(c => new FlagResponseModel(c)).ToList();
        }
    }
}
