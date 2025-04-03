using System;
using System.Collections;
using Archy.Application.Contracts.Core;

namespace Archy.Infrastructure.Core.Registry;

public class GenericRegistry<TKey, TValue> : IRegistry<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _kvps = [];

    public Type RegistryType => typeof(TValue);

    public void Add(TValue item, Func<TValue, TKey> keySelector)
    {
        TKey key = keySelector(item);
        if(_kvps.ContainsKey(key)){
            throw new InvalidOperationException($"Duplicate key found: {key}");
        }

        _kvps.Add(key, item);
    }

    public void AddRange(Func<TKey> keySelector, Func<TValue> appendRule)
    {
        TKey key = keySelector();

        if(_kvps.ContainsKey(key)){
            _kvps[key] = appendRule();
            return; 
        }

        _kvps.Add(key, appendRule());
    }
    public void AddRange(IEnumerable<TValue> items, Func<IEnumerable<TValue>, TKey> keySelector, Func<TValue> appendRule)
    {
        TKey key = keySelector(items);

        if(_kvps.ContainsKey(key)){
            _kvps[key] = appendRule();
            return; 
        }

        _kvps.Add(key, appendRule());
    }

    public bool ContainsKey(TKey key)
    {
        return _kvps.ContainsKey(key);
    }

    public bool ContainsValue(TValue value)
    {
        return _kvps.ContainsValue(value);
    }

    public TValue? Get(TKey key)
    {
        if(_kvps.TryGetValue(key, out TValue? value)){
            return value;
        }

        return default;
    }

    public IReadOnlyList<TValue> GetAll()
    {
        return [.. _kvps.Values];
    }

    public bool TryGetValue(TKey key, out TValue? value)
    {
        return _kvps.TryGetValue(key, out value);
    }
}
