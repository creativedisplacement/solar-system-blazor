using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Application.Planet.Commands.CreatePlanet;
using Xunit;

namespace SolarSystem.Application.Tests.Planets.Commands
{
    public class CreatePlanetCommandTests : TestBase
    {
        private const string Name = "Planet created";
        private const string Introduction = "Introduction created";
        private const string Description = "Description created";
        private const double Density = 2.0;
        private const double Tilt = 2.0;
        private const string ImageUrl = "ImageUrl created";
        private const double RotationPeriod = 2.0;
        private const double Period = 2.0;
        private const int Radius = 2;
        private const int Moons = 2;
        private const double Au = 2.1;
        private const double Eccentricity = 2.2;
        private const double Velocity = 2.3;
        private const double Mass = 2.4;
        private const double Inclination = 2.5;
        private const string Type = "PlanetType created";
        private const int Ordinal = 2;
        
        [Fact]
        public async Task Create_New_Planet()
        {
            using (var context = GetContextWithData())
            {
                var handler = new CreatePlanetCommandHandler(context);
                var planetId = Guid.NewGuid();

                var command = new CreatePlanetCommand
                {
                   Id = planetId,
                   Name = Name,
                   Introduction = Introduction,
                   Description = Description,
                   Density = Density,
                   Tilt = Tilt,
                   ImageUrl = ImageUrl,
                   RotationPeriod = RotationPeriod,
                   Period = Period,
                   Radius = Radius,
                   Moons = Moons,
                   Au = Au,
                   Eccentricity = Eccentricity,
                   Velocity = Velocity,
                   Mass = Mass,
                   Inclination = Inclination,
                   Type = Type,
                   Ordinal = Ordinal
                };

                await handler.Handle(command, CancellationToken.None);

                var planet = await context.Planets.SingleOrDefaultAsync(p => p.Id == command.Id);

                Assert.Equal(command.Id, planet.Id);
                Assert.Equal(command.Name, planet.Name);
                Assert.Equal(command.Introduction, planet.Introduction);
                Assert.Equal(command.Description, planet.Description);
                Assert.Equal(command.Density, planet.Density);
                Assert.Equal(command.Tilt, planet.Tilt);
                Assert.Equal(command.ImageUrl, planet.ImageUrl);
                Assert.Equal(command.RotationPeriod, planet.RotationPeriod);
                Assert.Equal(command.Period, planet.Period);
                Assert.Equal(command.Radius, planet.Radius);
                Assert.Equal(command.Moons, planet.Moons);
                Assert.Equal(command.Au, planet.Au);
                Assert.Equal(command.Eccentricity, planet.Eccentricity);
                Assert.Equal(command.Velocity, planet.Velocity);
                Assert.Equal(command.Mass, planet.Mass);
                Assert.Equal(command.Inclination, planet.Inclination);
                Assert.Equal(command.Type, planet.Type);
                Assert.Equal(command.Ordinal, planet.Ordinal);
            }
        }

        [Fact]
        public void Create_Planet_With_No_Name_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new CreatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Name, string.Empty);
            }
        }

        [Fact]
        public void Create_Planet_With_No_Introduction_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new CreatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Introduction, string.Empty);
            }
        }
        
        
        [Fact]
        public void Create_Planet_With_No_Description_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new CreatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Description, string.Empty);
            }
        }
        
        [Fact]
        public void Create_Planet_With_No_ImageUrl_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new CreatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.ImageUrl, string.Empty);
            }
        }
        
        [Fact]
        public void Create_Planet_With_No_Type_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new CreatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Type, string.Empty);
            }
        }

        [Fact]
        public void Create_Planet_With_Name_That_Already_Exists_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new CreatePlanetCommandValidator(context);
                var result = validator.TestValidate(new CreatePlanetCommand
                {
                    Id = new Guid(),
                    Name = context.Planets.FirstOrDefault()?.Name
                });
                result.ShouldHaveValidationErrorFor(x => x);
                
            }
        }

        [Fact]
        public void Create_Planet_With_Title_That_Does_Not_Already_Exists()
        {
            using (var context = GetContextWithData())
            {
                var validator = new CreatePlanetCommandValidator(context);
                var result = validator.TestValidate(new CreatePlanetCommand
                {
                    Id = new Guid(),
                    Name = Name
                });
                result.ShouldNotHaveValidationErrorFor(x => x.Name);
                
            }
        }
    }
}