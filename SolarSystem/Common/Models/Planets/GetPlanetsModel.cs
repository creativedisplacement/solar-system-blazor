using System.Collections.Generic;

namespace SolarSystem.Common.Models.Planets
{
    public class GetPlanetsModel
    {
        public IEnumerable<GetPlanetModel> Planets { get; set; }
    }
    
    public class GetPlanetModel : BaseBasicItem
    {
        
    }
}