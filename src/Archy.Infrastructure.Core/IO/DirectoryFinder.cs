using System;
using Archy.Application.Contracts.Core.IO;
using System.Collections.Generic;
using System.Linq;
using DotNet.Globbing;
using DotNet.Globbing.Token;

namespace Archy.Infrastructure.Core.IO;

public class DirectoryFinder : IDirectoryFinder
{
    public Task Find(string searchKey)
    {
        
    }

    public IEnumerable<string> FindPaths(
        string rootDirectory,
        string relativePattern,
        MatchType matchType = MatchType.FileSystemEntries, // Default to finding both files and dirs
        bool caseSensitive = true)
    {
        string fullRootDirectory = Path.GetFullPath(rootDirectory);

        if (!Directory.Exists(fullRootDirectory))
        {
            // Log warning or simply return empty if root doesn't exist
            // Console.WriteLine($"Warning: Root directory not found: {fullRootDirectory}");
            yield break;
        }

        // 1. Prepare the relative pattern (trim leading slashes for clean matching)
        string cleanRelativePattern = relativePattern.TrimStart('/', '\\');

        // 2. Parse the relative glob pattern ONCE.
        //    MatchFullPath ensures the relative pattern matches the whole relative path.
        var globOptions = new GlobOptions
        {
            Evaluation = { CaseInsensitive = !caseSensitive },
            Comparison = { MatchFullPath = true }
        };
        Glob glob;
        try
        {
            glob = Glob.Parse(cleanRelativePattern, globOptions);
        }
        catch (FormatException ex)
        {
             Console.WriteLine($"Error: Invalid glob pattern '{cleanRelativePattern}'. {ex.Message}");
             yield break; // Or throw?
        }


        // 3. Set up enumeration options. Always recurse; glob filters depth.
        var searchOptions = new EnumerationOptions
        {
            IgnoreInaccessible = true, // Important for stability
            RecurseSubdirectories = true, // Let glob handle depth matching
            MatchType = matchType,
            // MatchCasing can be set based on caseSensitive, but glob handles it anyway
            // MatchCasing = caseSensitive ? MatchCasing.CaseSensitive : MatchCasing.CaseInsensitive
        };

        // 4. Enumerate entries using simple OS pattern "*"
        IEnumerable<string> entries;
        try
        {
            // Use specific Directory.EnumerateFiles/Directories if MatchType is specific,
            // potentially slightly faster if OS can pre-filter type.
            // But EnumerateFileSystemEntries with MatchType option is clear and works well.
            entries = Directory.EnumerateFileSystemEntries(fullRootDirectory, "*", searchOptions);
        }
        catch (Exception ex) when (ex is DirectoryNotFoundException || ex is UnauthorizedAccessException)
        {
             // Log enumeration errors if needed
             // Console.WriteLine($"Warning: Error enumerating {fullRootDirectory}. {ex.Message}");
             yield break;
        }

        // 5. Filter using the parsed Glob object against relative paths
        foreach (string fullPath in entries)
        {
            string relativePath = Path.GetRelativePath(fullRootDirectory, fullPath);

            // Convert to forward slashes for consistent matching
            string matchPath = relativePath.Replace(Path.DirectorySeparatorChar, '/');

            // Handle patterns ending in '/' which imply directories
            // If the pattern ends with '/' and the entry isn't actually a directory, skip it.
            // This check is mainly needed if MatchType is FileSystemEntries.
            // If MatchType is Directories, this is implicitly handled.
            if (cleanRelativePattern.EndsWith('/') && !Directory.Exists(fullPath)) // Use File.Exists/Directory.Exists for concrete check
            {
                 continue;
            }
             // A less common case: pattern DOESN'T end with '/' but matches a directory path string
             if (!cleanRelativePattern.EndsWith('/') && matchType == MatchType.Files && Directory.Exists(fullPath))
             {
                 continue;
             }


            if (glob.IsMatch(matchPath))
            {
                yield return fullPath;
            }
        }
    }
}
