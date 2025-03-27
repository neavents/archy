using System;
using Archy.Application.Contracts.Core.IO;
using DotNet.Globbing;

namespace Archy.Infrastructure.Core.IO.Globbing;

public class GlobFactory : IGlobFactory
{
    public ValueTask<Glob> Create(GlobOptions? opts)
    {
        IGlobBuilder g = new GlobBuilder();
        //https://github.com/dazinator/DotNet.Glob
        
    }
}
