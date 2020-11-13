using Common;
using Microsoft.Extensions.Configuration;

namespace FreeJokesApi.Configuration
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("");
    }
}
