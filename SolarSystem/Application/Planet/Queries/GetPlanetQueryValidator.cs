using FluentValidation;

namespace SolarSystem.Application.Planet.Queries
{
    public class GetPlanetQueryValidator : AbstractValidator<GetPlanetQuery>
    {
        public GetPlanetQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }   
    }
}