using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using SolarSystem.Application.Infrastructure;
using SolarSystem.Application.Planets;

namespace SolarSystem.Server.Configuration
{
    public static class DiConfigurationExtension
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetPlanetsQueryHandler).GetTypeInfo().Assembly);
        }
    }
}