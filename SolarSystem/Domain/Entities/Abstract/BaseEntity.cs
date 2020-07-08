using System;
using SolarSystem.Domain.Enums;

namespace SolarSystem.Domain.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; } = Status.Unchanged;
    }
}