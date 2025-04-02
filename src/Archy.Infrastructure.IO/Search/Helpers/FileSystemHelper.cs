using System;
using Archy.Application.Contracts.IO.Search.Globbing;
using Archy.Application.Contracts.IO.Search.Helpers;
using DotNet.Globbing;

namespace Archy.Infrastructure.IO.Search.Helpers;

public class FileSystemHelper : IFileSystemHelper
{
    private readonly IGlobFactory _globFactory;

    public FileSystemHelper(IGlobFactory globFactory){
        _globFactory = globFactory;
    }

    public string ConvertToMatchPath(string rootDirectory, string fullPath)
    {
        string relativePath = Path.GetRelativePath(rootDirectory, fullPath);
        return relativePath.Replace(Path.DirectorySeparatorChar, '/');
    }

    public List<string> ExtractMatchingSegments(string[] patternSegments, string[] pathSegments)
    {
        List<string> captured = [];

        int maxDepth = Math.Min(patternSegments.Length, pathSegments.Length);
        for (int i = 0; i < maxDepth; i++)
        {
            if (patternSegments[i].Contains('*') || patternSegments[i].Contains('?'))
            {
                // Perform a quick check that this path segment actually matches the pattern segment
                // This adds robustness, e.g., ensures "*.json" only captures ".json" files.
                Glob glob = _globFactory.Create(new(){Evaluation = {CaseInsensitive = true}}, patternSegments[i]);
        
                if(glob.IsMatch(pathSegments[i]))
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

    public bool IsDirectoryPatternExists(string path)
    {
        throw new NotImplementedException();
    }

    public bool IsFileButInDirectoryFormat(string path)
    {
        throw new NotImplementedException();
    }
}
