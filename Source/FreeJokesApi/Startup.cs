using FreeJokesApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeJokesApi
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddJsonFile("appSettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AppConfiguration.AddMvc(services);
            AppConfiguration.AddDependencyResolvers(services, _configuration);
            AppConfiguration.AddMediatR(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            AppConfiguration.UseHttpsRedirection(app);
            AppConfiguration.UseRouting(app);
            AppConfiguration.UseEndpoints(app);
        }
    }
}
