using Common;
using FreeJokesApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddMvcCore(options => { options.Filters.Add(typeof(GlobalExceptionHandlingFilter)); });
        }

        public static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyResolver).Assembly);
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
