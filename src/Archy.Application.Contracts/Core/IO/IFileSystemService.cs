using System;

namespace Archy.Application.Contracts.Core.IO;

public interface IFileSystemService
{
    public void CheckDirectoryExists(string path);
    
}
