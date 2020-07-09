using System;
using Microsoft.EntityFrameworkCore;
using SolarSystem.Persistence;

namespace SolarSystem.Application.Tests
{
    public abstract class TestBase
    {
        protected SolarSystemDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<SolarSystemDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new SolarSystemDbContext(options);

            context.Database.EnsureCreated();
            
            SolarSystemInitialiser.Initialise(context);

            return context;
        }
    }
}