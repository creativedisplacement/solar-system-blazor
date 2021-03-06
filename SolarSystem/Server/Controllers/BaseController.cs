﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SolarSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
        

        protected IMediator Mediator { get; }
    }
}