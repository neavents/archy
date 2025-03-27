using System;
using Archy.Application.Contracts.Generic;
using DotNet.Globbing;


namespace Archy.Application.Contracts.Core.IO;

public interface IGlobFactory : IAsyncFactory<Glob, GlobOptions>
{

}
