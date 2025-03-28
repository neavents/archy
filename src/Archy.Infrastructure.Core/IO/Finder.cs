using System;
using Archy.Application.Contracts.Core.IO;
using Archy.Application.Contracts.Core.IO.Helpers;
using Archy.Infrastructure.Core.Models.Globbing;
using DotNet.Globbing;
using SharedKernel.Infrastructure.Core.Models.Globbing;

namespace Archy.Infrastructure.Core.IO;

public class Finder : IFinder
{
    private readonly IFileSystemHelper _fileSystemHelper;

    public Finder(IFileSystemHelper fileSystemHelper){
        _fileSystemHelper = fileSystemHelper;
    }

    public Task<IEnumerable<string>> FindAndMatchAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> FindAsync(string searchKey)
    {
        string fullRootDirectory = Path.GetFullPath(rootDirectory);
        if (!Directory.Exists(fullRootDirectory))
        {
            // Consider logging this
            yield break;
        }

        // Prepare the relative pattern
        string cleanRelativePattern = relativePattern.TrimStart('/', '\\');

        // Parse the glob pattern
        var globOptions = new GlobOptions
        {
            Evaluation = { CaseInsensitive = !caseSensitive },
            Comparison = { MatchFullPath = true } // Match against the whole relative path
        };
        Glob glob;
        try
        {
            glob = Glob.Parse(cleanRelativePattern, globOptions);
        }
        catch (FormatException ex)
        {
             Console.WriteLine($"Error: Invalid glob pattern '{cleanRelativePattern}'. {ex.Message}");
             yield break; // Stop processing this pattern
        }

        // Determine MatchType based on pattern ending (heuristic)

        var searchOptions = new EnumerationOptions
        {
            IgnoreInaccessible = true,
            RecurseSubdirectories = true, // Necessary for patterns like */impl/*
        };

        IEnumerable<string> entries;
        try
        {
            entries = Directory.EnumerateFileSystemEntries(fullRootDirectory, "*", searchOptions);
        }
        catch (Exception ex) when (ex is DirectoryNotFoundException || ex is UnauthorizedAccessException)
        {
             yield break;
        }
    }

    public IEnumerable<HierarchicalGlobResult> GlobMatchAsync(string relativePattern, string rootDirectory, IEnumerable<string> entries, Glob glob)
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
                    relativePattern, // Use the cleaned pattern
                    fullPath,
                    matchPath, // Use the '/' separated relative path
                    capturedSegments,
                    entryIsDirectory
                );
            }
        }
    }
}
