using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SolarSystem.Application.Planet.Commands.CreatePlanet;
using SolarSystem.Application.Planet.Commands.DeletePlanet;
using SolarSystem.Application.Planet.Commands.UpdatePlanet;
using SolarSystem.Application.Planet.Queries;
using SolarSystem.Common.Models.Planet;
using SolarSystem.Infrastructure;
using SolarSystem.Server.Controllers;
using Xunit;

namespace SolarSystem.Server.Tests
{
    public class PlanetControllerTests
    {
        private PlanetController _controller;
        private Mock<IPlanetCache> _cache;
        private Mock<IMediator> _mediator;
        private GetPlanetModel _planet;

        public PlanetControllerTests()
        {
            _cache = new Mock<IPlanetCache>();
            _mediator = new Mock<IMediator>();
            _planet = new GetPlanetModel
            {
                Id = Guid.NewGuid(),
                Name = "Planet 1",
                Introduction = "Introduction",
                Description = "Description",
                Density = 1.0,
                Tilt = 1.0,
                ImageUrl = "ImageUrl",
                RotationPeriod = 1.0,
                Period = 1.0,
                Radius = 1,
                Moons = 1,
                Au = 1.1,
                Eccentricity = 1.2,
                Velocity = 1.3,
                Mass = 1.4,
                Inclination = 1.5,
                Type = "PlanetType",
                Ordinal = 1
            };
        }


        [Fact]
        public async Task Get_Planet_Uses_Cache()
        {
            _cache.Setup(c => c.Get(It.IsAny<Guid>())).Returns(_planet);
            _mediator.Setup(m => m.Send(It.IsAny<GetPlanetQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(_planet);
            _controller = new PlanetController(_cache.Object, _mediator.Object);

            var response = await _controller.GetPlanet(It.IsAny<Guid>());
            Assert.IsType<ObjectResult>(response);

            var result = response as ObjectResult;

            if (result == null)
            {
                throw new ArgumentException();
            }

            Assert.IsType<GetPlanetModel>(result.Value);
            _cache.Verify(c => c.Get(It.IsAny<Guid>()), Times.Once);
            _mediator.Verify(m => m.Send(It.IsAny<GetPlanetQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            _cache.Verify(c => c.Set(It.IsAny<GetPlanetModel>()), Times.Never);
        }

        [Fact]
        public async Task  Get_Planet_Does_Not_Use_Cache()
        {
            _cache.Setup(c => c.Get(It.IsAny<Guid>())).Returns((GetPlanetModel)null);
            _mediator.Setup(m => m.Send(It.IsAny<GetPlanetQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(_planet);
            _controller = new PlanetController(_cache.Object, _mediator.Object);

            var response = await _controller.GetPlanet(It.IsAny<Guid>());
            Assert.IsType<ObjectResult>(response);

            var result = response as ObjectResult;

            if (result == null)
            {
                throw new ArgumentException();
            }

            Assert.IsType<GetPlanetModel>(result.Value);
            _cache.Verify(c => c.Get(It.IsAny<Guid>()), Times.Once);
            _mediator.Verify(m => m.Send(It.IsAny<GetPlanetQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            _cache.Verify(c => c.Set(It.IsAny<GetPlanetModel>()), Times.Once);
        }

        [Fact]
        public async Task Post_Planet()
        {
            _cache.Setup(c => c.Get(It.IsAny<Guid>())).Returns(_planet);
            _mediator.Setup(m => m.Send(It.IsAny<CreatePlanetCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(_planet);
            _controller = new PlanetController(_cache.Object, _mediator.Object);

            var response = await _controller.PostPlanet(_planet);
            Assert.IsType<ObjectResult>(response);

            var result = response as ObjectResult;

            if (result == null)
            {
                throw new ArgumentException();
            }

            Assert.IsType<GetPlanetModel>(result.Value);
            _mediator.Verify(m => m.Send(It.IsAny<CreatePlanetCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Put_Planet_Uses_Cache()
        {
            _cache.Setup(c => c.Remove(It.IsAny<Guid>()));
            _mediator.Setup(m => m.Send(It.IsAny<UpdatePlanetCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(_planet);
            _controller = new PlanetController(_cache.Object, _mediator.Object);

            var response = await _controller.PutPlanet(_planet);
            Assert.IsType<ObjectResult>(response);

            var result = response as ObjectResult;

            if (result == null)
            {
                throw new ArgumentException();
            }

            Assert.IsType<GetPlanetModel>(result.Value);
            _mediator.Verify(m => m.Send(It.IsAny<UpdatePlanetCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            _cache.Verify(c => c.Remove(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Put_Planet_Does_Not_Use_Cache()
        {
            _cache.Setup(c => c.Remove(It.IsAny<Guid>()));
            _mediator.Setup(m => m.Send(It.IsAny<UpdatePlanetCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(_planet);
            _controller = new PlanetController(_cache.Object, _mediator.Object);

            var response = await _controller.PutPlanet(_planet);
            Assert.IsType<ObjectResult>(response);

            var result = response as ObjectResult;

            if (result == null)
            {
                throw new ArgumentException();
            }

            Assert.IsType<GetPlanetModel>(result.Value);
            _mediator.Verify(m => m.Send(It.IsAny<UpdatePlanetCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            _cache.Verify(c => c.Remove(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Delete_Planet_Removes_From_Cache()
        {
            _cache.Setup(c => c.Remove(It.IsAny<Guid>()));
            _mediator.Setup(m => m.Send(It.IsAny<DeletePlanetCommand>(), It.IsAny<CancellationToken>()));
            _controller = new PlanetController(_cache.Object, _mediator.Object);

            await _controller.DeletePlanet(It.IsAny<Guid>());
            
            _mediator.Verify(m => m.Send(It.IsAny<DeletePlanetCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            _cache.Verify(c => c.Remove(It.IsAny<Guid>()), Times.Once);
        }
    }
}