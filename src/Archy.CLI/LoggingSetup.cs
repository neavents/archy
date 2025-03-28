using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace Archy.CLI;

public static class LoggingSetup
{
    public static Logger SerilogConfiguration(ConfigurationManager configuration){
        return new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }

    public static IServiceCollection AddSerilogSetup(this IServiceCollection services){
        services.AddLogging(loggingBuilder => {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });
        return services;
    }
}
