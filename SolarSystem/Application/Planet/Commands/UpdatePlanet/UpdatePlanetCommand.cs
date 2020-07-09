using MediatR;
using SolarSystem.Common;
using SolarSystem.Common.Models.Planet;

namespace SolarSystem.Application.Planet.Commands.UpdatePlanet
{
    public class UpdatePlanetCommand : BaseDetailedItem, IRequest<GetPlanetModel>
    {
        
    }
}