using System;

namespace Archy.Application.Contracts.Core;

public interface IRegistry{
    public Type RegistryType {get;}
}
public interface IRegistry<TKey, TValue> : IRegistry
{
    public void Add(TValue item, Func<TValue, TKey> keySelector);
    public void AddRange(Func<TKey> keySelector, Func<TValue> appendRule);
    public void AddRange(IEnumerable<TValue> items, Func<IEnumerable<TValue>, TKey> keySelector, Func<TValue> appendRule);
    public TValue? Get(TKey key);
    public bool TryGetValue(TKey key, out TValue? value);
    public IReadOnlyList<TValue> GetAll();
    public bool ContainsKey(TKey key);
    public bool ContainsValue(TValue value);
}
