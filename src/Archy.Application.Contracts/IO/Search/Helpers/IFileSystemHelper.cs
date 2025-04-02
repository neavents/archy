using System;

namespace Archy.Application.Contracts.IO.Search.Helpers;

public interface IFileSystemHelper
{
    public string ConvertToMatchPath(string rootDirectory, string fullPath);
    public List<string> ExtractMatchingSegments(string[] patternSegments, string[] pathSegments);
    public bool IsDirectoryPatternExists(string path);
    public bool IsFileButInDirectoryFormat(string path);
}
