using System;
using Archy.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.CLI;

public static class OptionsSetup
{
    public static void Configure(IServiceCollection services, ConfigurationManager configurations){
        static string merge(params string[] strings){
            string rootName = "Configurations";
            string seperator = ":";
            string[] mStrings = [rootName, ..strings];
            
            return string.Join(seperator, mStrings);
        }

        services.Configure<ConfigurationOptions>(configurations.GetSection(merge("Root")));
        services.Configure<DomainOptions>(configurations.GetSection(merge("Domain")));
        services.Configure<ImplementationOptions>(configurations.GetSection(merge("Implementation")));
        services.Configure<NamingOptions>(configurations.GetSection(merge("Naming")));
        services.Configure<PackageOptions>(configurations.GetSection(merge("Package")));
        services.Configure<ToolOptions>(configurations.GetSection(merge("Tool")));

        services.Configure<VersionOptions>(configurations.GetSection("Versioning:Core"));
    }

}
