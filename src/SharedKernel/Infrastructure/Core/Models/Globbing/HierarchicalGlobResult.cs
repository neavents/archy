using System;

namespace SharedKernel.Infrastructure.Core.Models.Globbing;

public class HierarchicalGlobResult
{
    public string Pattern { get; }
    public string FullPath { get; }
    public string RelativePath { get; }
    public IReadOnlyList<string> MatchedWildcardSegments { get; }
    public bool IsDirectory { get; }

    public HierarchicalGlobResult(string pattern, string fullPath, string relativePath, List<string> matchedSegments, bool isDirectory)
    {
        Pattern = pattern;
        FullPath = fullPath;
        RelativePath = relativePath;
        MatchedWildcardSegments = matchedSegments?.AsReadOnly() ?? (IReadOnlyList<string>)new List<string>().AsReadOnly(); 
        IsDirectory = isDirectory;
    }

    public string? GetSegment(int index) =>
        (index >= 0 && index < MatchedWildcardSegments.Count) ? MatchedWildcardSegments[index] : null;

    public override string ToString()
    {
        return $"Match: '{RelativePath}' (Pattern: '{Pattern}', Segments: [{string.Join(", ", MatchedWildcardSegments)}], IsDir: {IsDirectory})";
    }
}
