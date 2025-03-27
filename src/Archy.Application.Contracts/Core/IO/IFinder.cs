using System;
using DotNet.Globbing;

namespace Archy.Application.Contracts.Core.IO;

public interface IFinder
{
    public Task<IEnumerable<string>> FindAsync(string searchKey);
    public Task<IEnumerable<string>> MatchAsync(string relativePattern, string rootDirectory, Glob glob);
    public Task<IEnumerable<string>> FindAndMatchAsync();
}
