using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Common.Models.Planets;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planets.Queries
{
    public class GetPlanetsQueryHandler: IRequestHandler<GetPlanetsQuery, GetPlanetsModel>
    {
        private readonly SolarSystemDbContext _context;

        public GetPlanetsQueryHandler(SolarSystemDbContext context)
        {
            _context = context;
        }

        public async Task<GetPlanetsModel> Handle(GetPlanetsQuery request, CancellationToken cancellationToken)
        {
            return new GetPlanetsModel
            {
                Planets = (await _context.Planets
                    .OrderBy(p => p.Ordinal)
                    .ToListAsync(cancellationToken)).Select(p => new GetPlanetModel
                    {Id = p.Id, Name = p.Name, ImageUrl = p.ImageUrl, Introduction = p.Introduction, Ordinal = p.Ordinal})
            };
        }
    }
}