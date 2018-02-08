using Application.Abstract;
using Application.Categories.Queries.GetAllCategories;
using Application.Categories.Queries.GetAllCategoriesQuery.Abstract;
using Application.Jokes.Queries.GetAllJokes;
using Application.Jokes.Queries.GetAllJokes.Abstract;
using Application.Jokes.Queries.GetAllJokesByCategory;
using Application.Jokes.Queries.GetAllJokesByCategory.Abstract;
using Application.Jokes.Queries.GetJokeById;
using Application.Jokes.Queries.GetJokeById.Abstract;
using Application.Jokes.Queries.GetJokesByCategoryAndCount;
using Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract;
using Application.Jokes.Queries.GetJokesByCount;
using Application.Jokes.Queries.GetJokesByCount.Abstract;
using Application.Jokes.Queries.GetRandomJoke;
using Application.Jokes.Queries.GetRandomJoke.Abstract;
using Application.Jokes.Queries.GetRandomJokeByCategory;
using Application.Jokes.Queries.GetRandomJokeByCategory.Abstract;
using FreeJokesApi.Exceptions;
using FreeJokesApi.Exceptions.Abstract;
using FreeJokesApi.Exceptions.Builder;
using FreeJokesApi.Exceptions.Builder.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Persistence;
using Persistence.Extensions;
using Persistence.Serializers;
using Persistence.Serializers.Abstract;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using System.IO;

namespace FreeJokesApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .Enrich.WithExceptionDetails()
                .WriteTo.RollingFile(new JsonFormatter(renderMessage: true), Path.Combine(env.ContentRootPath, "../FreeJokesApi/log-{Date}.txt"))
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IJokeService, JokeService>();

            services.AddScoped<IGetAllCategoriesQuery, GetAllCategoriesQuery>();

            services.AddScoped<IGetAllJokesQuery, GetAllJokesQuery>();
            services.AddScoped<IGetAllJokesByCategoryQuery, GetAllJokesByCategoryQuery>();
            services.AddScoped<IGetJokeByIdQuery, GetJokeByIdQuery>();
            services.AddScoped<IGetJokesByCategoryAndCountQuery, GetJokesByCategoryAndCountQuery>();
            services.AddScoped<IGetJokesByCountQuery, GetJokesByCountQuery>();
            services.AddScoped<IGetRandomJokeQuery, GetRandomJokeQuery>();
            services.AddScoped<IGetRandomJokeByCategoryQuery, GetRandomJokeByCategoryQuery>();

            services.AddScoped<IDataSerializer, DataSerializer>();

            services.AddScoped<IExceptionBuilder, ExceptionBuilder>();
            services.AddScoped<IJsonExceptionMiddleware, JsonExceptionMiddleware>();
            services.AddScoped<JsonSerializer>();

            services.RegisterPersistenceServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IJsonExceptionMiddleware jsonExceptionMiddleware)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = jsonExceptionMiddleware.Invoke
            });

            app.UseMvc();
        }
    }
}
