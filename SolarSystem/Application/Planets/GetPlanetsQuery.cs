using MediatR;
using SolarSystem.Common;
using SolarSystem.Common.Models.Planets;

namespace SolarSystem.Application.Planets
{
    public class GetPlanetsQuery : BaseItem, IRequest<GetPlanetsModel>
    {
        
    }
}