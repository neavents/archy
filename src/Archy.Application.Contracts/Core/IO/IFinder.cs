using System;
using DotNet.Globbing;
using SharedKernel.Infrastructure.Core.Models.Globbing;

namespace Archy.Application.Contracts.Core.IO;

public interface IFinder
{
    public Task<IEnumerable<string>> FindAsync(string searchKey);
    public IEnumerable<HierarchicalGlobResult> GlobMatchAsync(string relativePattern, string rootDirectory, Glob glob, IEnumerable<string> entries);
    public Task<IEnumerable<string>> FindAndMatchAsync();
}