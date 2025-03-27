using System;

namespace Archy.Application.Contracts.Core.IO;

public interface IFinder
{
    public Task Find(string searchKey);
    public Task Match();
    public Task FindAndMatch();
}
