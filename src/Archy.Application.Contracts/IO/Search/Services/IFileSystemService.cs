using System;

namespace Archy.Application.Contracts.IO.Search.Services;

public interface IFileSystemService
{
    public void CheckDirectoryExists(string path);
    public IEnumerable<string> IterateFileSystem(string path, string pattern, EnumerationOptions enumerationOptions);
    
}
