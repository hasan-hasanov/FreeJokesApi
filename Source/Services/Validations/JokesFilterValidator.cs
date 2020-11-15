using Adapter.Database.Queries.GetAllCategories;
using Adapter.Database.Queries.GetAllFlags;
using Common.Exceptions;
using Core.Entities;
using Core.Queries;
using Core.Validations;
using Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Validations
{
    public class JokesFilterValidator : IValidation<JokesFilterRequestModel>
    {
        private readonly IQueryHandler<GetAllFlagsQuery, IList<Flag>> _getAllFlagsQueryHandler;
        private readonly IQueryHandler<GetAllCategoriesQuery, IList<Category>> _getAllCategoriesQueryHandler;

        public JokesFilterValidator(
            IQueryHandler<GetAllFlagsQuery, IList<Flag>> getAllFlagsQueryHandler,
            IQueryHandler<GetAllCategoriesQuery, IList<Category>> getAllCategoriesQueryHandler)
        {
            _getAllFlagsQueryHandler = getAllFlagsQueryHandler;
            _getAllCategoriesQueryHandler = getAllCategoriesQueryHandler;
        }

        public async Task Validate(JokesFilterRequestModel model)
        {
            List<string> errorMessages = new List<string>();

            if (model.Flags != null && model.Flags.Any())
            {
                IList<Flag> flags = await _getAllFlagsQueryHandler.HandleAsync(new GetAllFlagsQuery());
                foreach (var flag in model.Flags)
                {
                    if (!flags.Any(f => f.Name.ToLower() == flag.ToLower()))
                    {
                        errorMessages.Add($"{flag} could not be found");
                    }
                }
            }

            if (model.Categories != null && model.Categories.Any())
            {
                IList<Category> categories = await _getAllCategoriesQueryHandler.HandleAsync(new GetAllCategoriesQuery());
                foreach (var category in model.Categories)
                {
                    if (!categories.Any(f => f.Name.ToLower() == category.ToLower()))
                    {
                        errorMessages.Add($"{category} could not be found");
                    }
                }
            }

            if (model.RatingMin < 0 || model.RatingMin > 10)
            {
                errorMessages.Add($"{nameof(model.RatingMin)} should be in range [0 10]");
            }


            if (model.RatingMax < 0 || model.RatingMax > 10)
            {
                errorMessages.Add($"{nameof(model.RatingMax)} should be in range [0 10] and greater than {nameof(model.RatingMin)}");
            }

            if (model.RatingMax != 0 && model.RatingMin != 0 && model.RatingMax <= model.RatingMin)
            {
                errorMessages.Add($"{nameof(model.RatingMax)} should be in range [0 10] and greater than {nameof(model.RatingMin)}");
            }

            if (model.Random && model.Page != 1)
            {
                errorMessages.Add($"You cannot {nameof(model.Random)} and {nameof(model.Page)} at the same time");
            }

            if (model.Page < 1)
            {
                errorMessages.Add($"{nameof(model.Page)} should be greater than 0");
            }

            if (model.PageSize < 1 && model.PageSize > 100)
            {
                errorMessages.Add($"{nameof(model.Page)} should be greater than 0");
            }

            if (errorMessages.Any())
            {
                throw new BadRequestException(string.Join(Environment.NewLine, errorMessages));
            }
        }
    }
}
