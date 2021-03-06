﻿using Adapter.Database.Commands.PublishJoke;
using Adapter.Database.Commands.RateJoke;
using Adapter.Database.Contexts;
using Adapter.Database.Queries.GetAllCategories;
using Adapter.Database.Queries.GetAllCategoriesByNames;
using Adapter.Database.Queries.GetAllFlags;
using Adapter.Database.Queries.GetFilteredJokes;
using Adapter.Database.Queries.GetFlagsByNames;
using Adapter.Database.Queries.GetJokeById;
using Common.Constants;
using Core.Commands;
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
            services.AddScoped<IQueryHandler<GetFilteredJokesQuery, IList<Joke>>, GetFilteredJokesQueryHandler>();
            services.AddScoped<IQueryHandler<GetFlagsByNamesQuery, IList<Flag>>, GetFlagsByNamesQueryHandler>();
            services.AddScoped<IQueryHandler<GetCategoriesByNamesQuery, IList<Category>>, GetCategoriesByNamesQueryHandler>();
            services.AddScoped<IQueryHandler<GetJokeByIdQuery, Joke>, GetJokeByIdQueryHandler>();

            services.AddScoped<ICommandHandler<PublishJokeCommand>, PublishJokeCommandHandler>();
            services.AddScoped<ICommandHandler<RateJokeCommand>, RateJokeCommandHandler>();

            services.AddScoped<IValidation<JokesFilterRequestModel>, JokesFilterValidator>();
            services.AddScoped<IValidation<PublishJokeRequestModel>, PublishJokesValidator>();
            services.AddScoped<IValidation<RateJokeRequestModel>, RateJokeValidator>();

            return services;
        }
    }
}
