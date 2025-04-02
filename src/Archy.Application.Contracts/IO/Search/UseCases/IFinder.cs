using System;
using DotNet.Globbing;
using SharedKernel.Infrastructure.IO.Models.Globbing;

namespace Archy.Application.Contracts.IO.Search.UseCases;

public interface IFinder
{
    public IEnumerable<string> FindAsync(string rootPath);
    public IEnumerable<HierarchicalGlobResult> GlobMatchAsync(string relativePattern, string rootDirectory, Glob glob, IEnumerable<string> entries);
    public IEnumerable<HierarchicalGlobResult> FindAndMatchAsync(string rootPath, string pattern, bool caseSensitive);
}