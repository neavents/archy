using System;
using Archy.Application.Contracts.Core.IO;

namespace Archy.Infrastructure.Core.IO;

public class Finder : IFinder
{
    public Task<IEnumerable<string>> FindAndMatchAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> FindAsync(string searchKey)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> MatchAsync()
    {
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
