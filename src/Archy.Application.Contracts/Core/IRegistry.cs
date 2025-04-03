using System;

namespace Archy.Application.Contracts.Core;

public interface IRegistry<T>
{
    public void Add(T item, Func<T, string> keySelector);
    public void AddRange(IEnumerable<T> items, Func<T, string> keySelector);
    public T? Get(string key);
    public IReadOnlyList<T> GetAll();
    public bool ContainsKey(string key);
    public bool ContainsValue(T value);
}
