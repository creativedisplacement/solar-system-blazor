using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SolarSystem.Common.Models.Planets;

namespace SolarSystem.Server.Configuration
{
    public static class FluentValidationExtension
    {
        public static void AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetPlanetsModel>());
        }
    }
}