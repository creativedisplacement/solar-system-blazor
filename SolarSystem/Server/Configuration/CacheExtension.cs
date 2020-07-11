using Microsoft.Extensions.DependencyInjection;

namespace SolarSystem.Server.Configuration
{
    public static class CacheExtension
    {
        public static void AddCacheConfig(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}