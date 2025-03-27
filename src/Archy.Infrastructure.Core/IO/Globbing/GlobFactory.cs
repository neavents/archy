using System;
using Archy.Application.Contracts.Core.IO.Globbing;
using DotNet.Globbing;
using SharedKernel.Infrastructure.Core.Models;

namespace Archy.Infrastructure.Core.IO.Globbing;

public class GlobFactory : IGlobFactory
{
    public async ValueTask<Glob> Create(GlobOptions? opts1, string? finderPattern)
    {
        return Glob.Parse(finderPattern, opts1);
    }
}
