using FluentValidation;

namespace SolarSystem.Application.Planet.Commands.DeletePlanet
{
    public class DeletePlanetCommandValidator : AbstractValidator<DeletePlanetCommand>
    {
        public DeletePlanetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}