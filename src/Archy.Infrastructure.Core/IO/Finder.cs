using System;
using Archy.Application.Contracts.Core.IO;
using Archy.Application.Contracts.Core.IO.Globbing;
using Archy.Application.Contracts.Core.IO.Helpers;
using Archy.Infrastructure.Core.Models.Globbing;
using DotNet.Globbing;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.Core.Models.Globbing;

namespace Archy.Infrastructure.Core.IO;

public class Finder : IFinder
{
    private readonly IFileSystemHelper _fileSystemHelper;
    private readonly IFileSystemService _fileSystemService;
    private readonly IGlobFactory _globFactory;
    private readonly ILogger<Finder> _logger;

    public Finder(IFileSystemHelper fileSystemHelper, IFileSystemService fileSystemService, IGlobFactory globFactory, ILogger<Finder> logger)
    {
        _fileSystemHelper = fileSystemHelper;
        _fileSystemService = fileSystemService;
        _globFactory = globFactory;
        _logger = logger;
    }

    public IEnumerable<HierarchicalGlobResult> FindAndMatchAsync(string rootPath, string pattern, bool caseSensitive)
    {
        string cleanRelativePattern = pattern.TrimStart('/', '\\');

        Glob glob = _globFactory.Create(new() { Evaluation = { CaseInsensitive = !caseSensitive } }, cleanRelativePattern);
        
        IEnumerable<string> entries = FindAsync(rootPath);

        return GlobMatchAsync(pattern, rootPath, glob, entries);
    }

    public IEnumerable<string> FindAsync(string rootPath)
    {
        string fullRootDirectory = Path.GetFullPath(rootPath);

        _fileSystemService.CheckDirectoryExists(fullRootDirectory);

        IEnumerable<string> entries = _fileSystemService.IterateFileSystem(fullRootDirectory, "*", new() { IgnoreInaccessible = true, RecurseSubdirectories = true });
        return entries;
    }

    public IEnumerable<HierarchicalGlobResult> GlobMatchAsync(string relativePattern, string rootDirectory, Glob glob, IEnumerable<string> entries)
    {
        var patternSegments = relativePattern.TrimEnd('/').Split('/');

        foreach (string fullPath in entries)
        {
            bool entryIsDirectory = Directory.Exists(fullPath); // Check actual type

            // Basic type filtering based on pattern intention
            //if (expectedType == MatchType.Directories && !entryIsDirectory) continue;

            // If pattern doesn't end in '/' but we found a directory, skip if user likely wants files
            // This is slightly ambiguous, adjust if needed. Maybe add explicit File/Directory mode?
            // Let's assume non-'/' patterns primarily target files.
            if (!relativePattern.EndsWith('/') && entryIsDirectory)
            {
                // Exception: If the very last segment is just "*", allow directory match
                if (!(patternSegments.LastOrDefault() == "*"))
                {
                    continue;
                }
            }

            string matchPath = _fileSystemHelper.ConvertToMatchPath(rootDirectory, fullPath);

            if (glob.IsMatch(matchPath))
            {
                var pathSegments = matchPath.TrimEnd('/').Split('/');

                List<string> capturedSegments = _fileSystemHelper.ExtractMatchingSegments(patternSegments, pathSegments);

                yield return new HierarchicalGlobResult(
                    relativePattern,
                    fullPath,
                    matchPath,
                    capturedSegments,
                    entryIsDirectory
                );
            }
        }
    }
}
