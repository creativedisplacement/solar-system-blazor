using System;
using System.Linq;
using FluentValidation;
using SolarSystem.Persistence;

namespace SolarSystem.Application
{
    public abstract class BaseCommandValidator<T> : AbstractValidator<T> where T : class
    {
        private readonly SolarSystemDbContext _context;

        protected BaseCommandValidator(SolarSystemDbContext context)
        {
            _context = context;
        }

        protected bool PlanetExists(string name, Guid planetId)
        {
            var result = _context.Planets.Count(c => c.Name == name && c.Id != planetId);
            return result <= 0;
        }

        protected bool PlanetExists(string name)
        {
            var result = _context.Planets.Count(c => c.Name == name);
            return result <= 0;
        }
    }
}