using System;
using Microsoft.Extensions.Caching.Memory;
using SolarSystem.Common.Models.Planet;
using SolarSystem.Infrastructure;

namespace SolarSystem.Server.Cache
{
    public class PlanetCache : IPlanetCache
    {
        private MemoryCache _cache { get; set; }

        public PlanetCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 20
            });
        }

        public GetPlanetModel Get(Guid id)
        {
            _cache.TryGetValue(GetCacheKey(id), out GetPlanetModel planet);
            return planet;
        }

        public void Remove(Guid id)
        {
            _cache.Remove(GetCacheKey(id));
        }

        public void Set(GetPlanetModel planet)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1);
            _cache.Set(GetCacheKey(planet.Id), planet, cacheEntryOptions);
            _cache.Set(GetCacheKey(planet.Name), planet, cacheEntryOptions);
        }
        
        private static string GetCacheKey(Guid planetId) =>
            $"Planet-{planetId}";
        
        private static string GetCacheKey(string name) =>
            $"Planet-{name}";
    }
}