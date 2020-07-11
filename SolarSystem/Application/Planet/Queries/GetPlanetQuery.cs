using MediatR;
using SolarSystem.Common;
using SolarSystem.Common.Models.Planet;

namespace SolarSystem.Application.Planet.Queries
{
    public class GetPlanetQuery : BaseItem, IRequest<GetPlanetModel>
    {
    }
}