using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SolarSystem.Common.Models.Planet;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planet.Commands.CreatePlanet
{
    public class CreatePlanetCommandHandler  : BaseCommandHandler, IRequestHandler<CreatePlanetCommand, GetPlanetModel>
    {
        private readonly SolarSystemDbContext _context;

        public CreatePlanetCommandHandler(SolarSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetPlanetModel> Handle(CreatePlanetCommand request, CancellationToken cancellationToken)
        { 
            var planet = new Domain.Entities.Planet(request.Id, request.Name, request.Introduction, request.Description, request.Density, 
                request.Tilt, request.ImageUrl, request.RotationPeriod, request.Period, request.Radius, request.Moons,
                request.Au, request.Eccentricity, request.Velocity, request.Mass, request.Inclination, request.Type, request.Ordinal);
            
            SetDomainState(planet);
            
            await _context.SaveChangesAsync(cancellationToken);

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