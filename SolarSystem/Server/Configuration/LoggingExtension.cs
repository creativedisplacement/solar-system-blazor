﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace SolarSystem.Server.Configuration
{
    public static class LoggingExtension
    {
        public static void UseLoggingConfig(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //TODO: enable logging
            //loggerFactory.AddFile("Logs/SolarSystem-{Date}.txt");
        }
    }
}