using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Application.Planet.Commands.UpdatePlanet;
using Xunit;

namespace SolarSystem.Application.Tests.Planets.Commands
{
    public class UpdatePlanetCommandTests : TestBase
    {
        private const string Name = "Planet updated";
        private const string Introduction = "Introduction updated";
        private const string Description = "Description has been updated updated";
        private const double Density = 3.0;
        private const double Tilt = 3.0;
        private const string ImageUrl = "ImageUrl updated";
        private const double RotationPeriod = 3.0;
        private const double Period = 3.0;
        private const int Radius = 3;
        private const int Moons = 3;
        private const double Au = 3.1;
        private const double Eccentricity = 3.2;
        private const double Velocity = 3.3;
        private const double Mass = 3.4;
        private const double Inclination = 3.5;
        private const string Type = "PlanetType updated";
        private const int Ordinal = 3;
        
        [Fact]
        public async Task Update_Planet()
        {
            using (var context = GetContextWithData())
            {
                var handler = new UpdatePlanetCommandHandler(context);
                var command = new UpdatePlanetCommand
                {
                    Id = (await context.Planets.FirstOrDefaultAsync()).Id,
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

                var planet = await context.Planets
                    .Where(p => p.Id == command.Id)
                    .FirstOrDefaultAsync();

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
        public void Update_Planet_With_No_Id_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new UpdatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Id, Guid.Empty);
            }
        }

        [Fact]
        public void Update_Planet_With_No_Name_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new UpdatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Name, string.Empty);
            }
        }
        
        [Fact]
        public void Update_Planet_With_No_Introduction_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new UpdatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Introduction, string.Empty);
            }
        }
        
        
        [Fact]
        public void Update_Planet_With_No_Description_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new UpdatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Description, string.Empty);
            }
        }
        
        [Fact]
        public void Update_Planet_With_No_ImageUrl_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new UpdatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.ImageUrl, string.Empty);
            }
        }
        
        [Fact]
        public void Update_Planet_With_No_Type_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var validator = new UpdatePlanetCommandValidator(context);
                validator.ShouldHaveValidationErrorFor(x => x.Type, string.Empty);
            }
        }

        [Fact]
        public void Update_Planet_With_Name_That_Already_Exists_Throws_Exception()
        {
            using (var context = GetContextWithData())
            {
                var planet = context.Planets.FirstOrDefault();

                if (planet != null)
                {
                    var validator = new UpdatePlanetCommandValidator(context);
                    var result = validator.TestValidate(new UpdatePlanetCommand
                    {
                        
                        Id = planet.Id,
                        Name = "Venus",
                        ImageUrl = ImageUrl,
                        Introduction = Introduction,
                        Description = Description,
                        Type = Type
                    });
                    result.ShouldHaveValidationErrorFor(x => x);
                }
            }
        }
    }
}