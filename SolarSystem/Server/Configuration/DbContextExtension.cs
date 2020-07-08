using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarSystem.Persistence;

namespace SolarSystem.Server.Configuration
{
    public static class DbContextExtension
    {
        public static void AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SolarSystemDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SolarSystemDb")));
        }
    }
}