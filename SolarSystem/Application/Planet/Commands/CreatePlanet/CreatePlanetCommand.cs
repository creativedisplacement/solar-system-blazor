using MediatR;
using SolarSystem.Common;
using SolarSystem.Common.Models.Planet;

namespace SolarSystem.Application.Planet.Commands.CreatePlanet
{
    public class CreatePlanetCommand : BaseDetailedItem, IRequest<GetPlanetModel>
    {
        
    }
}