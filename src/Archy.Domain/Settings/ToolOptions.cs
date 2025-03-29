using System;

namespace Archy.Domain.Settings;

public class ToolOptions
{
    public ToolPatterns Patterns {get; init;} = new();

}

public class ToolPatterns {
    public string Configuration {get; init;} = string.Empty;
    public string Actual {get; init;} = string.Empty;
    public string Usage {get; init;} = string.Empty;
}