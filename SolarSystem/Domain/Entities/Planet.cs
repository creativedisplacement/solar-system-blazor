using System;
using SolarSystem.Domain.Entities.Abstract;
using SolarSystem.Domain.Enums;

namespace SolarSystem.Domain.Entities
{
    public class Planet : BaseEntity, IAggregateRoot
    {
        public Planet()
        {
            
        }
        
        public Planet(Guid id, string name, string introduction, string description, double density, 
            double tilt, string imageUrl, double rotationPeriod, double period, int radius, int moons,
            double au, double eccentricity, double velocity, double mass, double inclination, string type, int ordinal)
        {
            Id = id;
            Name = name;
            Introduction = introduction;
            Description = description;
            Density = density;
            Tilt = tilt;
            ImageUrl = imageUrl;
            RotationPeriod = rotationPeriod;
            Period = period;
            Radius = radius;
            Moons = moons;
            Au = au;
            Eccentricity = eccentricity;
            Velocity = velocity;
            Mass = mass;
            Inclination = inclination;
            Type = type;
            Ordinal = ordinal;
            Status = Status.Added;
        }

        public Planet(string name, string introduction, string description, double density, 
            double tilt, string imageUrl, double rotationPeriod, double period, int radius, int moons,
            double au, double eccentricity, double velocity, double mass, double inclination, string type, int ordinal)
        {
            Name = name;
            Introduction = introduction;
            Description = description;
            Density = density;
            Tilt = tilt;
            ImageUrl = imageUrl;
            RotationPeriod = rotationPeriod;
            Period = period;
            Radius = radius;
            Moons = moons;
            Au = au;
            Eccentricity = eccentricity;
            Velocity = velocity;
            Mass = mass;
            Inclination = inclination;
            Type = type;
            Ordinal = ordinal;
            Status = Status.Added;
        }
        public string Name { get; private set; }
        public string Introduction { get; private set; }
        public string Description { get; private set; }
        public double Density { get; private set; }
        public double Tilt { get; private set; }
        public string ImageUrl { get; private set; }
        public double RotationPeriod { get; private set; }
        public double Period { get; private set; }
        public int Radius { get; private set; }
        public int Moons { get; private set; }
        public double Au { get; private set; }
        public double Eccentricity { get; private set; }
        public double Velocity { get; private set; }
        public double Mass { get; private set; }
        public double Inclination { get; private set; }
        public string Type { get; private set; }
        public int Ordinal { get; private set; }

        public void UpdatePlanet(string name, string introduction, string description, double density,
            double tilt, string imageUrl, double rotationPeriod, double period, int radius, int moons,
            double au, double eccentricity, double velocity, double mass, double inclination, string type,
            int ordinal)
        {
            Name = name;
            Introduction = introduction;
            Description = description;
            Density = density;
            Tilt = tilt;
            ImageUrl = imageUrl;
            RotationPeriod = rotationPeriod;
            Period = period;
            Radius = radius;
            Moons = moons;
            Au = au;
            Eccentricity = eccentricity;
            Velocity = velocity;
            Mass = mass;
            Inclination = inclination;
            Type = type;
            Ordinal = ordinal;
            Status = Status.Updated;
        }

        public void DeletePlanet()
        {
            Status = Status.Deleted;
        }
    }
}