using Adapter.Database.Queries.GetAllCategories;
using Core.Entities;
using Core.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CategoriesHandlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequestModel, IList<CategoriesResponseModel>>
    {
        private readonly ILogger<GetAllCategoriesHandler> _logger;
        private readonly IQueryHandler<GetAllCategoriesQuery, IList<Category>> _getAllCategoriesQueryHandler;

        public GetAllCategoriesHandler(
            ILogger<GetAllCategoriesHandler> logger,
            IQueryHandler<GetAllCategoriesQuery, IList<Category>> getAllCategoriesQueryHandler)
        {
            _logger = logger;
            _getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
        }

        public async Task<IList<CategoriesResponseModel>> Handle(GetAllCategoriesRequestModel request, CancellationToken cancellationToken)
        {
            IList<Category> allCategories = await _getAllCategoriesQueryHandler.HandleAsync(new GetAllCategoriesQuery());
            return allCategories.Select(c => new CategoriesResponseModel(c)).ToList();
        }
    }
}
