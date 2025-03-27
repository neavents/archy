using System;
using DotNet.Globbing;

namespace Archy.Infrastructure.Core.Models.Globbing;

public class GlobWrapper
{
    public required string FinderPath {get; init;}
    public required Glob Glob {get; init;}

    public GlobWrapper(string finderPath, Glob glob){
        FinderPath = finderPath;
        Glob = glob;
    }
}
