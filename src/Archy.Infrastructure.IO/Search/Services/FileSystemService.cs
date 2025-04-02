using System;
using Archy.Application.Contracts.IO.Search.Services;
using Microsoft.Extensions.Logging;

namespace Archy.Infrastructure.IO.Search.Services;

public class FileSystemService : IFileSystemService
{
    private readonly ILogger<FileSystemService> _logger;

    public FileSystemService(ILogger<FileSystemService> logger){
        _logger = logger;
    }
    public void CheckDirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            var ex = new DirectoryNotFoundException();
            _logger.LogError(ex, "Can not find directory at {path}", path);
            throw ex;
        }
    }

    public IEnumerable<string> IterateFileSystem(string path, string pattern, EnumerationOptions enumerationOptions)
    {
        try
        {
            return Directory.EnumerateFileSystemEntries(path, pattern, enumerationOptions);
        }
        catch (Exception ex)
        {
             _logger.LogError(ex, "Error while Enumerating filesystem entries");
             throw;
        }
    }
}
