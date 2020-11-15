using Common;
using FreeJokesApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.Configuration;

namespace FreeJokesApi.Configuration
{
    public class AppConfiguration
    {
        public static void AddDependencyResolvers(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IAppSettings>(_ => new AppSettings(configuration));
            DependencyResolver.RegisterTypes(services, configuration);
        }

        public static void AddMvc(IServiceCollection services)
        {
            services.AddMvcCore(
                options =>
                {
                    options.Filters.Add(typeof(GlobalExceptionHandlingFilter));
                })
                .AddApiExplorer();
        }

        public static void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Free Jokes Api",
                    License = new OpenApiLicense { Name = "Hasan Hasanov" }
                });
            });
        }

        public static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyResolver).Assembly);
        }

        public static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Free Jokes Api");
            });
        }

        public static void UseHttpsRedirection(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
        }

        public static void UseRouting(IApplicationBuilder app)
        {
            app.UseRouting();
        }

        public static void UseEndpoints(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
