using System;

namespace SolarSystem.Common
{
    public abstract class BaseItem 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Introduction { get; set; }
        public int Ordinal { get; set; }
    }
}