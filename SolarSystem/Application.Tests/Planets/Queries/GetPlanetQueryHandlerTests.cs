using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Application.Planet.Queries;
using SolarSystem.Common.Models.Planet;
using Xunit;

namespace SolarSystem.Application.Tests.Planets.Queries
{
    public class GetPlanetQueryHandlerTests: TestBase
    {
        [Fact]
        public async Task Get_Planet()
        {
            using (var context = GetContextWithData())
            {
                var handler = new GetPlanetQueryHandler(context);
                var planet = await context.Planets.FirstAsync();

                var result = await handler.Handle(new GetPlanetQuery {Id = planet.Id}, CancellationToken.None);

                Assert.IsType<GetPlanetModel>(result);
                Assert.Equal(planet.Id, result.Id);
                Assert.Equal(planet.Name, result.Name);
                Assert.Equal(planet.Introduction, result.Introduction);
                Assert.Equal(planet.Description, result.Description);
                Assert.Equal(planet.Density, result.Density);
                Assert.Equal( planet.Tilt, result.Tilt);
                Assert.Equal( planet.ImageUrl, result.ImageUrl);
                Assert.Equal( planet.RotationPeriod, result.RotationPeriod);
                Assert.Equal( planet.Period, result.Period);
                Assert.Equal( planet.Radius, result.Radius);
                Assert.Equal( planet.Moons, result.Moons);
                Assert.Equal( planet.Au, result.Au);
                Assert.Equal( planet.Eccentricity, result.Eccentricity);
                Assert.Equal( planet.Velocity, result.Velocity);
                Assert.Equal(planet.Mass, result.Mass);
                Assert.Equal(planet.Inclination, result.Inclination);
                Assert.Equal(planet.Type, result.Type);
            }
        }
    }
}