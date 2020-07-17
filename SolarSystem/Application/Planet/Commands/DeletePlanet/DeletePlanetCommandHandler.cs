using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SolarSystem.Application.Exceptions;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planet.Commands.DeletePlanet
{
    public class DeletePlanetCommandHandler : BaseCommandHandler, IRequestHandler<DeletePlanetCommand>
    {
        private readonly SolarSystemDbContext _context;

        public DeletePlanetCommandHandler(SolarSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePlanetCommand request, CancellationToken cancellationToken)
        {
            var planet = await _context.Planets.FindAsync(request.Id);

            if (planet == null)
            {
                throw new DeleteFailureException(nameof(Planet), request.Id, "Unable to find planet to delete.");
            }

            planet.DeletePlanet();
            
            SetDomainState(planet);
            
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}