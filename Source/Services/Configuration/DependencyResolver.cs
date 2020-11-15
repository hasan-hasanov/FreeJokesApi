using Adapter.Database.Contexts;
using Adapter.Database.Queries.GetAllCategories;
using Adapter.Database.Queries.GetAllFlags;
using Common.Constants;
using Core.Entities;
using Core.Queries;
using Core.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Models.RequestModels;
using Services.Validations;
using System.Collections.Generic;

namespace Services.Configuration
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<JokesContext>(options => options.UseSqlServer(configuration.GetConnectionString(GeneralConstants.JokesApiDatabase)));

            services.AddScoped<IQueryHandler<GetAllCategoriesQuery, IList<Category>>, GetAllCategoriesQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllFlagsQuery, IList<Flag>>, GetAllFlagsQueryHandler>();

            services.AddScoped<IValidation<JokesFilter>, JokesFilterValidator>();

            return services;
        }
    }
}
