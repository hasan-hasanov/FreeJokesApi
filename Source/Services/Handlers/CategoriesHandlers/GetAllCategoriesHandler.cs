using Adapter.Database.Queries.GetAllCategories;
using Core.Entities;
using Core.Queries;
using MediatR;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Handlers.CategoriesHandlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequestModel, IList<CategoryResponseModel>>
    {
        private readonly IQueryHandler<GetAllCategoriesQuery, IList<Category>> _getAllCategoriesQueryHandler;

        public GetAllCategoriesHandler(IQueryHandler<GetAllCategoriesQuery, IList<Category>> getAllCategoriesQueryHandler)
        {
            _getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
        }

        public async Task<IList<CategoryResponseModel>> Handle(GetAllCategoriesRequestModel request, CancellationToken cancellationToken)
        {
            IList<Category> allCategories = await _getAllCategoriesQueryHandler.HandleAsync(new GetAllCategoriesQuery());
            return allCategories.Select(c => new CategoryResponseModel(c)).ToList();
        }
    }
}
