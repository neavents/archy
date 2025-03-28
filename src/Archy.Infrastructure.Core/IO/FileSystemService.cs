using System;
using Archy.Application.Contracts.Core.IO;

namespace Archy.Infrastructure.Core.IO;

public class FileSystemService : IFileSystemService
{
    public void CheckDirectoryExists(string path)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> IterateFileSystem(string path, string pattern, EnumerationOptions enumerationOptions)
    {
        IEnumerable<string> entries;
        try
        {
            entries = Directory.EnumerateFileSystemEntries(path, pattern, enumerationOptions);
        }
        catch (Exception ex) when (ex is DirectoryNotFoundException || ex is UnauthorizedAccessException)
        {
             yield break;
        }
        return entries;
    }
}
