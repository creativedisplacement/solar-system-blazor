using System;
using Microsoft.Extensions.Caching.Memory;
using SolarSystem.Infrastructure;

namespace SolarSystem.Server.Cache
{
    public class PlanetsCache<T> : IPlanetsCache<T> where T : class
    {
        private MemoryCache Cache { get; set; }

        public PlanetsCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 20
            });
        }

        public T Get(string name)
        {
            Cache.TryGetValue(GetCacheKey(name), out T value);
            return value;
        }

        public void Remove(Guid id)
        {
            Cache.Remove(GetCacheKey(id.ToString()));
        }

        public void Set(string name, T value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1);
            Cache.Set(GetCacheKey(name), value, cacheEntryOptions);
        }
        
        private string GetCacheKey(string name) =>
            $"Planets-{name}";
    }
}