using System;

namespace Archy.Domain.Settings;

public class NamingOptions
{
    public NamingPatterns Patterns {get; init;} = new();
}

public class NamingPatterns{
    public string Domain {get; init;} = string.Empty;
    public string General {get; init;} = string.Empty;
}
