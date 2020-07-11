using System;
using SolarSystem.Common.Models.Planet;

namespace SolarSystem.Infrastructure
{
    public interface IPlanetCache
    {
        GetPlanetModel Get(Guid id);
        void Remove(Guid id);
        void Set(GetPlanetModel planet);

    }
}