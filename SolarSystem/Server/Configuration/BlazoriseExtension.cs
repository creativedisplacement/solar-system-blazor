using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.Extensions.DependencyInjection;

namespace SolarSystem.Server.Configuration
{
    public static class BlazoriseExtension
    {
        public static void AddBlazoriseConfig(this IServiceCollection services)
        {
            services
                .AddBlazorise( options =>
                {
                    options.ChangeTextOnKeyPress = true;
                } )
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
        }
    }
}