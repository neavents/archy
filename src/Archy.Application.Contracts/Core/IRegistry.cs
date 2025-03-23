using System;

namespace Archy.Application.Contracts.Core;

public interface IRegistry<T>
{
    public void Add(T item);
    public T? Get(string key);
    public IReadOnlyList<T> GetAll();
}
