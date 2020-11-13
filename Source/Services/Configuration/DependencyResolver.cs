using Adapter.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Configuration
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<FreeJokesContext>(options => options.UseSqlServer(configuration.GetConnectionString("")));

            return services;
        }
    }
}
