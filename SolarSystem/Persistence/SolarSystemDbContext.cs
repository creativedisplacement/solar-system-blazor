using Microsoft.EntityFrameworkCore;
using SolarSystem.Domain.Entities;

namespace SolarSystem.Persistence
{
    public class SolarSystemDbContext : DbContext
    {
        public SolarSystemDbContext(DbContextOptions<SolarSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }
    }
}