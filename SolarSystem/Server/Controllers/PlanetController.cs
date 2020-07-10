﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarSystem.Application.Planet.Commands.CreatePlanet;
using SolarSystem.Application.Planet.Commands.DeletePlanet;
using SolarSystem.Application.Planet.Commands.UpdatePlanet;
using SolarSystem.Application.Planet.Queries;
using SolarSystem.Common.Models.Planet;

namespace SolarSystem.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlanetController : BaseController
    {
        [HttpGet("{name}")]
        public async Task<IActionResult> GetPlanet(string name)
        {
            try
            {
                var planet = await Mediator.Send(new GetPlanetQuery{ Name = name });

                return new ObjectResult(planet);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(GetPlanetModel planet)
        {
            try
            {
                var createdPlanet = await Mediator.Send(new CreatePlanetCommand
                {
                    Id = Guid.NewGuid(),
                    Name = planet.Name,
                    Introduction = planet.Introduction,
                    Description = planet.Description,
                    Density = planet.Density,
                    Tilt = planet.Tilt,
                    ImageUrl = planet.ImageUrl,
                    RotationPeriod = planet.RotationPeriod,
                    Period = planet.Period,
                    Radius = planet.Radius,
                    Moons = planet.Moons,
                    Au = planet.Au,
                    Eccentricity = planet.Eccentricity,
                    Velocity = planet.Velocity,
                    Mass = planet.Mass,
                    Inclination = planet.Inclination,
                    Type = planet.Type,
                    Ordinal = planet.Ordinal
                });

                return new ObjectResult(createdPlanet);
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(GetPlanetModel planet)
        {
            try
            {
                var updatedPlanet = await Mediator.Send(new UpdatePlanetCommand
                {
                    Id = planet.Id,
                    Name = planet.Name,
                    Introduction = planet.Introduction,
                    Description = planet.Description,
                    Density = planet.Density,
                    Tilt = planet.Tilt,
                    ImageUrl = planet.ImageUrl,
                    RotationPeriod = planet.RotationPeriod,
                    Period = planet.Period,
                    Radius = planet.Radius,
                    Moons = planet.Moons,
                    Au = planet.Au,
                    Eccentricity = planet.Eccentricity,
                    Velocity = planet.Velocity,
                    Mass = planet.Mass,
                    Inclination = planet.Inclination,
                    Type = planet.Type,
                    Ordinal = planet.Ordinal
                });

                return new ObjectResult(updatedPlanet);
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
               await Mediator.Send(new DeletePlanetCommand { Id = id });

               return NoContent();
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }
    }
}