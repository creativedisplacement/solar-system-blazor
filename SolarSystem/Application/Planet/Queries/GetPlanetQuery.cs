using MediatR;
using SolarSystem.Common.Models.Planet;

namespace SolarSystem.Application.Planet.Queries
{
    public class GetPlanetQuery : IRequest<GetPlanetModel>
    {
        public string Name { get; set; }
    }
}