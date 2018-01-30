using Application.Abstract;
using Application.Categories.Queries.GetAllCategoriesQuery;
using Application.Categories.Queries.GetAllCategoriesQuery.Abstract;
using Application.Jokes.Queries.GetAllJokesByCategory;
using Application.Jokes.Queries.GetAllJokesByCategory.Abstract;
using Application.Jokes.Queries.GetJokeById;
using Application.Jokes.Queries.GetJokeById.Abstrac;
using Application.Jokes.Queries.GetJokesByCategoryAndCount;
using Application.Jokes.Queries.GetJokesByCategoryAndCount.Abstract;
using Application.Jokes.Queries.GetJokesByCount;
using Application.Jokes.Queries.GetJokesByCount.Abstract;
using Application.Jokes.Queries.GetJokesWithCategories;
using Application.Jokes.Queries.GetJokesWithCategories.Abstract;
using Application.Jokes.Queries.GetRandomJoke;
using Application.Jokes.Queries.GetRandomJoke.Abstract;
using Application.Jokes.Queries.GetRandomJokeByCategory;
using Application.Jokes.Queries.GetRandomJokeByCategory.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Seralizers;
using Persistence.Serializers.Abstract;

namespace FreeJokesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
