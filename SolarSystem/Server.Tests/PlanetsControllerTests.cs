using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SolarSystem.Application.Planets.Queries;
using SolarSystem.Common.Models.Planets;
using SolarSystem.Server.Controllers;
using Xunit;

namespace SolarSystem.Server.Tests
{
    public class PlanetsControllerTests
    {
        private PlanetsController? _controller;
        private readonly Mock<IMediator> _mediator;
        private readonly GetPlanetsModel _planets;

        public PlanetsControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _planets = new GetPlanetsModel
            {
                Planets = new List<GetPlanetModel>
                {
                    new GetPlanetModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Planet 1",
                        Introduction = "Introduction 1",
                        ImageUrl = "ImageUrl 1",
                        Ordinal = 1
                    },
                    new GetPlanetModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Planet 2",
                        Introduction = "Introduction 2",
                        ImageUrl = "ImageUrl 2",
                        Ordinal = 2
                    }
                }
            };
        }

        [Fact]
        public async Task Get_Planets()
        {
            _mediator.Setup(m => m.Send(It.IsAny<GetPlanetsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(_planets);
            _controller = new PlanetsController(_mediator.Object);

            var response = await _controller.GetAllPlanets();
            Assert.IsType<ObjectResult>(response);

            if (!(response is ObjectResult result))
            {
                throw new ArgumentException();
            }

            Assert.IsType<GetPlanetsModel>(result.Value);
            _mediator.Verify(m => m.Send(It.IsAny<GetPlanetsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}