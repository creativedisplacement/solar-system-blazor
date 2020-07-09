using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Application.Planet.Commands.DeletePlanet;
using Xunit;

namespace SolarSystem.Application.Tests.Planets.Commands
{
    public class DeletePlanetCommandTests : TestBase
    {
        [Fact]
        public async Task Delete_Planet()
        {
            using (var context = GetContextWithData())
            {
                var handler = new DeletePlanetCommandHandler(context);
                var command = new DeletePlanetCommand
                {
                    Id = (await context.Planets.FirstOrDefaultAsync()).Id
                };

                await handler.Handle(command, CancellationToken.None);
                Assert.Null(await context.Planets.FindAsync(command.Id));
            }
        }

        [Fact]
        public void Delete_Planet_With_No_Id_Throws_Exception()
        {
            var validator = new DeletePlanetCommandValidator();
            validator.ShouldHaveValidationErrorFor(x => x.Id, Guid.Empty);
        }
    }
}