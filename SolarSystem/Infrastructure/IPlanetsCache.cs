using System;

namespace SolarSystem.Infrastructure
{
    public interface IPlanetsCache<T> where T: class
    {
        T Get(string name);
        void Remove(Guid id);
        void Set(string name, T value);
    }
}