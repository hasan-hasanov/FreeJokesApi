using Application.Abstract;
using Application.Jokes.Queries.GetJokesWithCategories;
using Application.Jokes.Queries.GetJokesWithCategories.Abstract;
using Application.Jokes.Queries.GetRandomJoke;
using Application.Jokes.Queries.GetRandomJoke.Abstract;
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
            services.AddScoped<IGetAllJokesQuery, GetAllJokesQuery>();
            services.AddScoped<IGetRandomJokeQuery, GetRandomJokeQuery>();

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
