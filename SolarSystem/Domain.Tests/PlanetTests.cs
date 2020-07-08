using System;
using SolarSystem.Domain.Entities;
using SolarSystem.Domain.Enums;
using Xunit;

namespace SolarSystem.Domain.Tests
{
    public class PlanetTests
    {
        private readonly Guid _id;
        private readonly string _name;
        private readonly string _introduction;
        private readonly string _description;
        private readonly double _density;
        private readonly double _tilt;
        private readonly string _imageUrl;
        private readonly double _rotationPeriod;
        private readonly double _period;
        private readonly int _radius;
        private readonly int _moons;
        private readonly double _au;
        private readonly double _eccentricity;
        private readonly double _velocity;
        private readonly double _mass;
        private readonly double _inclination;
        private readonly string _type;
        private readonly int _ordinal;

        public PlanetTests()
        {
            _id = Guid.NewGuid();
            _name = "Planet 1";
            _introduction = "Introduction";
            _description = "Description";
            _density = 1.0;
            _tilt = 1.0;
            _imageUrl = "ImageUrl";
            _rotationPeriod = 1.0;
            _period = 1.0;
            _radius = 1;
            _moons = 1;
            _au = 1.1;
            _eccentricity = 1.2;
            _velocity = 1.3;
            _mass = 1.4;
            _inclination = 1.5;
            _type = "PlanetType";
            _ordinal = 1;
        }

        [Fact]
        public void Create_Planet()
        {
            var planet = new Planet(_name, _introduction, _description, _density, 
            _tilt, _imageUrl, _rotationPeriod, _period, _radius, _moons,
            _au, _eccentricity, _velocity, _mass, _inclination, _type, _ordinal);
            
            Assert.Equal(_name, planet.Name);
            Assert.Equal(_introduction, planet.Introduction);
            Assert.Equal(_description, planet.Description);
            Assert.Equal(_density, planet.Density);
            Assert.Equal(_tilt, planet.Tilt);
            Assert.Equal(_imageUrl, planet.ImageUrl);
            Assert.Equal(_rotationPeriod, planet.RotationPeriod);
            Assert.Equal(_period, planet.Period);
            Assert.Equal(_radius, planet.Radius);
            Assert.Equal(_moons, planet.Moons);
            Assert.Equal(_au, planet.Au);
            Assert.Equal(_eccentricity, planet.Eccentricity);
            Assert.Equal(_velocity, planet.Velocity);
            Assert.Equal(_mass, planet.Mass);
            Assert.Equal(_inclination, planet.Inclination);
            Assert.Equal(_type, planet.Type);
            Assert.Equal(_ordinal, planet.Ordinal);
            Assert.Equal(Status.Added, planet.Status);
        }
        
        [Fact]
        public void Create_Planet_With_Id()
        {
            var planet = new Planet(_id, _name, _introduction, _description, _density, 
                _tilt, _imageUrl, _rotationPeriod, _period, _radius, _moons,
                _au, _eccentricity, _velocity, _mass, _inclination, _type, _ordinal);
            
            Assert.Equal(_id, planet.Id);
            Assert.Equal(_name, planet.Name);
            Assert.Equal(_introduction, planet.Introduction);
            Assert.Equal(_description, planet.Description);
            Assert.Equal(_density, planet.Density);
            Assert.Equal(_tilt, planet.Tilt);
            Assert.Equal(_imageUrl, planet.ImageUrl);
            Assert.Equal(_rotationPeriod, planet.RotationPeriod);
            Assert.Equal(_period, planet.Period);
            Assert.Equal(_radius, planet.Radius);
            Assert.Equal(_moons, planet.Moons);
            Assert.Equal(_au, planet.Au);
            Assert.Equal(_eccentricity, planet.Eccentricity);
            Assert.Equal(_velocity, planet.Velocity);
            Assert.Equal(_mass, planet.Mass);
            Assert.Equal(_inclination, planet.Inclination);
            Assert.Equal(_type, planet.Type);
            Assert.Equal(_ordinal, planet.Ordinal);
            Assert.Equal(Status.Added, planet.Status);
        }
        
        [Fact]
        public void Update_Planet()
        {
            const string name = "Planet updated";
            const string introduction = "Introduction updated";
            const string description = "Description updated";
            const double density = 2.0;
            const double tilt = 2.0;
            const string imageUrl = "ImageUrl updated";
            const double rotationPeriod = 2.0;
            const double period = 2.0;
            const int radius = 2;
            const int moons = 2;
            const double au = 2.1;
            const double eccentricity = 2.2;
            const double velocity = 2.3;
            const double mass = 2.4;
            const double inclination = 2.5;
            const string type = "PlanetType updated";
            const int ordinal = 2;
            
            var planet = new Planet(_id, _name, _introduction, _description, _density, 
                _tilt, _imageUrl, _rotationPeriod, _period, _radius, _moons,
                _au, _eccentricity, _velocity, _mass, _inclination, _type, _ordinal);
            
            planet.UpdatePlanet(name, introduction, description, density, 
                tilt, imageUrl, rotationPeriod, period, radius, moons,
                au, eccentricity, velocity, mass, inclination, type, ordinal);
            
            Assert.Equal(_id, planet.Id);
            Assert.Equal(name, planet.Name);
            Assert.Equal(introduction, planet.Introduction);
            Assert.Equal(description, planet.Description);
            Assert.Equal(density, planet.Density);
            Assert.Equal(tilt, planet.Tilt);
            Assert.Equal(imageUrl, planet.ImageUrl);
            Assert.Equal(rotationPeriod, planet.RotationPeriod);
            Assert.Equal(period, planet.Period);
            Assert.Equal(radius, planet.Radius);
            Assert.Equal(moons, planet.Moons);
            Assert.Equal(au, planet.Au);
            Assert.Equal(eccentricity, planet.Eccentricity);
            Assert.Equal(velocity, planet.Velocity);
            Assert.Equal(mass, planet.Mass);
            Assert.Equal(inclination, planet.Inclination);
            Assert.Equal(type, planet.Type);
            Assert.Equal(ordinal, planet.Ordinal);
            Assert.Equal(Status.Updated, planet.Status);
        }
        
        [Fact]
        public void Delete_Planet()
        {
            var planet = new Planet(_id, _name, _introduction, _description, _density, 
                _tilt, _imageUrl, _rotationPeriod, _period, _radius, _moons,
                _au, _eccentricity, _velocity, _mass, _inclination, _type, _ordinal);
            
            planet.DeletePlanet();
            
            Assert.Equal(Status.Deleted, planet.Status);
        }
    }
}