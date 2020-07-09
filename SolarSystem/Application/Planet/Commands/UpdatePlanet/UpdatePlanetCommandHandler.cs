using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Application.Exceptions;
using SolarSystem.Common.Models.Planet;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planet.Commands.UpdatePlanet
{
    public class UpdatePlanetCommandHandler : BaseCommandHandler, IRequestHandler<UpdatePlanetCommand, GetPlanetModel>
    {
        private readonly SolarSystemDbContext _context;

        public UpdatePlanetCommandHandler(SolarSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetPlanetModel> Handle(UpdatePlanetCommand request, CancellationToken cancellationToken)
        {
            var planet = await _context.Planets
                .SingleAsync(c => c.Id == request.Id, cancellationToken);

            if (planet == null)
            {
                throw new NotFoundException(nameof(Planet), request.Id);
            }

            planet.UpdatePlanet(request.Name, request.Introduction, request.Description, request.Density, 
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
