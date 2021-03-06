﻿using FluentValidation;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Planet.Queries
{
    public class GetPlanetQueryValidator : BaseCommandValidator<GetPlanetQuery>
    {
        public GetPlanetQueryValidator(SolarSystemDbContext context) : base (context)
        {
            RuleFor(v => v.Id).NotEmpty();
        }   
    }
}