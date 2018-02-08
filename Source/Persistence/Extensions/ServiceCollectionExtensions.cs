using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileSystem, FileSystem>();
        }
    }
}
