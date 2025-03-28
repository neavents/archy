using System;

namespace Archy.Application.Contracts.Core.IO;

public interface IFileSystemService
{
    public void CheckDirectoryExists(string path);
    public IEnumerable<string> IterateFileSystem(string path, string pattern, EnumerationOptions enumerationOptions);
    
}
