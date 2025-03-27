using System;
using DotNet.Globbing;

namespace SharedKernel.Infrastructure.Core.Models;

public class GlobConfig
{
    public PathSeparatorKind? PathSeparator {get; init;}
    public string? Literal {get; init;}
    public bool HasAnyCharacter {get; init;}
}
