using MediatR;
using SolarSystem.Common;
using SolarSystem.Common.Models.Planets;

namespace SolarSystem.Application.Planets.Queries
{
    public class GetPlanetsQuery : BaseBasicItem, IRequest<GetPlanetsModel>
    {
        
    }
}