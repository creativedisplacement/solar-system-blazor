using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SolarSystem.Application.Planets;
using SolarSystem.Common.Models.Planets;
using Xunit;

namespace SolarSystem.Application.Tests.Planets.Queries
{
    public class GetPlanetsQueryHandlerTests : TestBase
    {
        [Fact]
        public async Task Get_All_Planets()
        {
            await using (var context = GetContextWithData())
            {
                var handler = new GetPlanetsQueryHandler(context);
                var result = await handler.Handle(new GetPlanetsQuery(), CancellationToken.None);

                Assert.IsType<GetPlanetsModel>(result);
                Assert.Equal(context.Planets.Count(), result.Planets.Count());
                Assert.Equal(context.Planets.OrderBy(p => p.Ordinal).First().Name,
                    result.Planets.OrderBy(p => p.Ordinal).First().Name);
            }
        }
    }
}