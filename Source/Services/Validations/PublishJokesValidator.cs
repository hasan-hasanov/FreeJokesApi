using Adapter.Database.Queries.GetAllCategories;
using Adapter.Database.Queries.GetAllFlags;
using Core.Entities;
using Core.Queries;
using Core.Validations;
using Services.Models.RequestModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class PublishJokesValidator : IValidation<PublishJokeRequestModel>
    {
        private readonly IQueryHandler<GetAllCategoriesQuery, IList<Category>> _getAllCategoriesQueryHandler;
        private readonly IQueryHandler<GetAllFlagsQuery, IList<Flag>> _getAllFlagsQueryHandler;

        public PublishJokesValidator(
            IQueryHandler<GetAllCategoriesQuery, IList<Category>> getAllCategoriesQueryHandler,
            IQueryHandler<GetAllFlagsQuery, IList<Flag>> getAllFlagsQueryHandler)
        {
            _getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
            _getAllFlagsQueryHandler = getAllFlagsQueryHandler;
        }

        public async Task Validate(PublishJokeRequestModel model)
        {
            List<string> errorMessages = new List<string>();

            IList<Category> categories = await _getAllCategoriesQueryHandler.HandleAsync(new GetAllCategoriesQuery());
            if (!categories.Any(c => c.Id == model.CategoryId))
            {
                errorMessages.Add($"Category with id {model.CategoryId} could not be found");
            }

            if (model.Parts == null || !model.Parts.Any())
            {
                errorMessages.Add($"{model.Parts} is required");
            }
            else
            {
                foreach (var part in model.Parts)
                {
                    if (string.IsNullOrWhiteSpace(part))
                    {
                        errorMessages.Add($"{model.Parts} should not be null or whitespace.");
                        break;
                    }
                }
            }

            if (model.Flags != null && model.Flags.Any())
            {
                IList<Flag> flags = await _getAllFlagsQueryHandler.HandleAsync(new GetAllFlagsQuery());
                foreach (var flag in model.Flags)
                {
                    if (!flags.Any(f => f.Id == flag))
                    {
                        errorMessages.Add($"Flag with id {flag} could not be found");
                    }
                }
            }
        }
    }
}
