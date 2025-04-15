using System;

namespace Archy.Domain.Settings;

public class VersionOptions
{
    public int Major {get; init;}
    public int Minor {get; init;}
    public int Patch {get; init;}
    public string PostFix {get; init;} = string.Empty;

    public override string ToString()
    {
        return $"{Major}.{Minor}.{Patch}{PostFix}";
    }
}
