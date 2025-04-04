using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Archy.CLI;

public static class ConfigurationLoader
{
    public static void Load(HostApplicationBuilder builder)
    {
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true )
            .AddEnvironmentVariables();;

        ExternalConfigurationSettingsJson(builder);
        ExternalProfileSettings(builder);
    }

    private static void ExternalConfigurationSettingsJson(HostApplicationBuilder builder){
        string? selectedPathForExternalConfigurationSettingsJsonPath = builder.Configuration["ConfigurationSettings:Path"];

        if(string.IsNullOrWhiteSpace(selectedPathForExternalConfigurationSettingsJsonPath)){
            throw new ArgumentNullException("Selected Path For External configurationsettings.json Path is null. It can not be null, process terminated.");
        }

        string externalConfigurationSettingsJsonPath = Path.Combine(AppContext.BaseDirectory, selectedPathForExternalConfigurationSettingsJsonPath);

        builder.Configuration.AddJsonFile(externalConfigurationSettingsJsonPath, optional: false, reloadOnChange: true);
    }

    private static void ExternalProfileSettings(HostApplicationBuilder builder){
        string? selectedPathForExternalProfileSettingsJsonpath = builder.Configuration["ProfileSettings:Path"];

        if(string.IsNullOrWhiteSpace(selectedPathForExternalProfileSettingsJsonpath)){
            throw new ArgumentNullException("Selected Path For External profilesettins.json Path is null. It can not be null, process terminated.");
        }

        string externalProfileSettingsJsonPath = Path.Combine(AppContext.BaseDirectory, selectedPathForExternalProfileSettingsJsonpath);

        builder.Configuration.AddJsonFile(externalProfileSettingsJsonPath, optional: false, reloadOnChange: true);
    }
}
