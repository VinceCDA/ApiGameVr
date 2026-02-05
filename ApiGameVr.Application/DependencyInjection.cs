using ApiGameVr.Application.Behavior;
using ApiGameVr.Application.Interfaces.Logging;
using ApiGameVr.Application.Logging;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApiGameVr.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Assembly assembly = typeof(DependencyInjection).Assembly;
            Log.Logger = SerilogConfigurator.Configure();
            services.AddSingleton<ILoggerService, SerilogLoggerService>();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(dispose: true);
            });
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(assembly);
                options.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
            return services;
        }
    }
}
