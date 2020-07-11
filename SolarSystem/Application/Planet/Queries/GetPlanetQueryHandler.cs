using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Application.Exceptions;
using SolarSystem.Common.Models.Planet;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planet.Queries
{
    public class GetPlanetQueryHandler : IRequestHandler<GetPlanetQuery, GetPlanetModel>
    {
        private readonly SolarSystemDbContext _context;

        public GetPlanetQueryHandler(SolarSystemDbContext context)
        {
            _context = context;
        }

        public async Task<GetPlanetModel> Handle(GetPlanetQuery request, CancellationToken cancellationToken)
        {
            var planet = await _context.Planets
                .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (planet == null)
            {
                throw new NotFoundException(nameof(Planet), request.Id);
            }

            return new GetPlanetModel
            {
                Id = planet.Id,
                Name = planet.Name,
                ImageUrl = planet.ImageUrl,
                Introduction = planet.Introduction,
                Description = planet.Description,
                Density = planet.Density,
                Tilt = planet.Tilt,
                RotationPeriod = planet.RotationPeriod,
                Period = planet.Period,
                Radius = planet.Radius,
                Moons = planet.Moons,
                Au = planet.Au,
                Eccentricity = planet.Eccentricity,
                Velocity = planet.Velocity,
                Mass = planet.Mass,
                Inclination = planet.Inclination,
                Type = planet.Type,
                Ordinal = planet.Ordinal
            };
        }
    }
}