using System;
using Archy.Application.Contracts.Generic;
using DotNet.Globbing;
using SharedKernel.Infrastructure.IO.Models;


namespace Archy.Application.Contracts.IO.Search.Globbing;

public interface IGlobFactory : IFactory<Glob, GlobOptions, string>
{
    
}
