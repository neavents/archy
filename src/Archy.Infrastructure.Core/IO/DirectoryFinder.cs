using System;
using Archy.Application.Contracts.Core.IO;
using System.Collections.Generic;
using System.Linq;
using DotNet.Globbing;
using DotNet.Globbing.Token;
using Archy.Application.Contracts.Core;
using Archy.Infrastructure.Core.Models.Globbing;

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

    public static IEnumerable<HierarchicalGlobResult> FindPathsAndSegments(
        string rootDirectory,
        string relativePattern,
        bool caseSensitive = true)
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

        // Split pattern for segment extraction logic
        // Note: This simple split works well for patterns like */*/*.json
        // but wouldn't handle more complex globs like ** correctly for extraction.
        var patternSegments = cleanRelativePattern.TrimEnd('/').Split('/');


        // --- Filter and Extract ---
        foreach (string fullPath in entries)
        {
            bool entryIsDirectory = Directory.Exists(fullPath); // Check actual type

            // Basic type filtering based on pattern intention
            if (expectedType == MatchType.Directories && !entryIsDirectory) continue;
            // If pattern doesn't end in '/' but we found a directory, skip if user likely wants files
            // This is slightly ambiguous, adjust if needed. Maybe add explicit File/Directory mode?
            // Let's assume non-'/' patterns primarily target files.
            if (!cleanRelativePattern.EndsWith('/') && entryIsDirectory)
            {
                 // Exception: If the very last segment is just "*", allow directory match
                 if (!(patternSegments.LastOrDefault() == "*"))
                 {
                     continue;
                 }
            }

            string relativePath = Path.GetRelativePath(fullRootDirectory, fullPath);
            string matchPath = relativePath.Replace(Path.DirectorySeparatorChar, '/');

            if (glob.IsMatch(matchPath))
            {
                // --- Segment Extraction ---
                var pathSegments = matchPath.TrimEnd('/').Split('/');
                var capturedSegments = ExtractMatchingSegments(patternSegments, pathSegments);

                yield return new HierarchicalGlobResult(
                    cleanRelativePattern, // Use the cleaned pattern
                    fullPath,
                    matchPath, // Use the '/' separated relative path
                    capturedSegments,
                    entryIsDirectory
                );
            }
        }
    }

    /// <summary>
    /// Extracts segments from the path that correspond to wildcard segments in the pattern.
    /// Assumes pattern uses '*' to match single directory/file names.
    /// </summary>
    private static List<string> ExtractMatchingSegments(string[] patternSegments, string[] pathSegments)
    {
        var captured = new List<string>();
        int maxCommonDepth = Math.Min(patternSegments.Length, pathSegments.Length);

        for (int i = 0; i < maxCommonDepth; i++)
        {
            // If the pattern segment at this position contains a wildcard
            // capture the corresponding path segment.
            // This simple check works for '*' and '*.json'.
            if (patternSegments[i].Contains('*') || patternSegments[i].Contains('?'))
            {
                // Perform a quick check that this path segment actually matches the pattern segment
                // This adds robustness, e.g., ensures "*.json" only captures ".json" files.
                var segmentGlob = Glob.Parse(patternSegments[i], new GlobOptions{ Comparison = { MatchFullPath = true }});
                if(segmentGlob.IsMatch(pathSegments[i]))
                {
                    captured.Add(pathSegments[i]);
                }
                // If segmentGlob doesn't match, something is wrong with assumptions,
                // but the full glob matched, so maybe skip capture? Or log warning?
                // For robustness with simple '*' case, let's capture anyway if it's just '*'
                else if (patternSegments[i] == "*")
                {
                    captured.Add(pathSegments[i]);
                }
            }
            // NOTE: This logic does NOT correctly handle "**" capture. It assumes
            // wildcards like "*" map to exactly one path segment.
        }
        return captured;
    }
}
