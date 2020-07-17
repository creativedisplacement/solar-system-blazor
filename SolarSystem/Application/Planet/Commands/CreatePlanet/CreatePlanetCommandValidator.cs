using FluentValidation;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planet.Commands.CreatePlanet
{
    public class CreatePlanetCommandValidator: BaseCommandValidator<CreatePlanetCommand>
    {
        public CreatePlanetCommandValidator(SolarSystemDbContext context) : base (context)
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(x => x.Introduction)
                .MinimumLength(10)
                .MaximumLength(150)
                .NotEmpty();
            RuleFor(x => x.ImageUrl)
                .MinimumLength(10)
                .MaximumLength(150)
                .NotEmpty();
            RuleFor(x => x.Description)
                .MinimumLength(30)
                .MaximumLength(3000)
                .NotEmpty();
            RuleFor(x => x.Type)
                .MinimumLength(5)
                .MaximumLength(20)
                .NotEmpty();
            
            RuleFor(x => x).Must(planet => PlanetExists(planet.Name))
                .WithMessage("The planet already exists in the database.");
        }
    }
}