using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarSystem.Application.Planets;
using SolarSystem.Common.Models.Planets;
using SolarSystem.Infrastructure;

namespace SolarSystem.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlanetsController : BaseController
    {
        private readonly IPlanetsCache<GetPlanetsModel> _cache;

        public PlanetsController(IPlanetsCache<GetPlanetsModel> cache)
        {
            _cache = cache;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllPlanets()
        {
            try
            {
                var planets = _cache.Get("All");
                if (planets != null)
                {
                    return new ObjectResult(planets);
                }
                planets = await Mediator.Send(new GetPlanetsQuery());
                if (planets == null)
                {
                    return NotFound();
                }
                _cache.Set("All", planets);

                return new ObjectResult(planets);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}