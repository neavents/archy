using System;

namespace Archy.Application.Contracts.Core.IO;

public interface IFileSystemSearch
{
    public void CheckDirectoryExists(string path);
    
}
