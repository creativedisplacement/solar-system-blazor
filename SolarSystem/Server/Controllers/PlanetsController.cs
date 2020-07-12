using System;
using System.Threading.Tasks;
using MediatR;
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
        public PlanetsController(IMediator mediator) : base(mediator) { }
        
        [HttpGet]
        public async Task<IActionResult> GetAllPlanets()
        {
            try
            {
                var planets = await Mediator.Send(new GetPlanetsQuery());
                return new ObjectResult(planets);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}