using System;
using Archy.Application.Contracts.Generic;
using DotNet.Globbing;
using SharedKernel.Infrastructure.Core.Models;


namespace Archy.Application.Contracts.Core.IO;

public interface IGlobFactory : IAsyncFactory<Glob, GlobOptions, GlobConfig>
{
    
}
