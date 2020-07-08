using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarSystem.Domain.Entities;

namespace SolarSystem.Persistence.Configuration
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Introduction)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}