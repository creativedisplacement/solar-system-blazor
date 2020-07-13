using System;
using SolarSystem.Domain.Entities.Abstract;
using SolarSystem.Domain.Enums;
using SolarSystem.Persistence;

namespace SolarSystem.Application
{
    public abstract class BaseCommandHandler
    {
        private readonly SolarSystemDbContext _context;

        protected BaseCommandHandler(SolarSystemDbContext context)
        {
            _context = context;
        }

        public void SetDomainState(BaseEntity entity)
        {
            switch (entity.Status)
            {
                case Status.Added:
                    _context.Add(entity);
                    break;
                case Status.Updated:
                    _context.Update(entity);
                    break;
                case Status.Deleted:
                    _context.Remove(entity);
                    break;
                case Status.Unchanged:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}