using System;

namespace Archy.Domain.Settings;

public class ConfigurationOptions
{
    public string Pattern {get; init;} = string.Empty;
    public string Wildcard {get; init;} = string.Empty;
}