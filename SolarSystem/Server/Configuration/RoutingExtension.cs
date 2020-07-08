using Microsoft.AspNetCore.Builder;

namespace SolarSystem.Server.Configuration
{
    public static class RoutingExtension
    {
        public static void UseRoutingConfig(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}