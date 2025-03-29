using System;

namespace Archy.Domain.Settings;

public class ConfigurationOptions
{
    public string Path {get; init;} = string.Empty;
    public string Wildcard {get; init;} = string.Empty;
}