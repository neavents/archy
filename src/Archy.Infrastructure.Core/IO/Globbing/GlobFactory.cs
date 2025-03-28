using System;
using Archy.Application.Contracts.Core.IO.Globbing;
using DotNet.Globbing;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Core.Models;

namespace Archy.Infrastructure.Core.IO.Globbing;

public class GlobFactory : IGlobFactory
{
    private readonly ILogger<GlobFactory> _logger;

    public GlobFactory(ILogger<GlobFactory> logger){
        _logger = logger;
    }
    public Glob Create(GlobOptions? opts1, string? finderPattern)
    {
        try{
            return Glob.Parse(finderPattern, opts1);
        } catch (Exception ex){
            _logger.LogError(ex, "Can not parse Glob with this pattern: {pattern}", finderPattern);
            throw;
        }
    }
}
