using FluentValidation;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planet.Commands.DeletePlanet
{
    public class DeletePlanetCommandValidator : BasePlanetCommandValidator<DeletePlanetCommand>
    {
        public DeletePlanetCommandValidator(SolarSystemDbContext context) : base (context)
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}