using System;
using Archy.Application.Contracts.Core;

namespace Archy.Infrastructure.Core.Registry;

public class GenericRegistry<T> : IRegistry<T>
{
    private readonly Dictionary<string, T> _kvps = [];

    public void Add(T item, Func<T, string> keySelector)
    {
        string key = keySelector(item);
        if(_kvps.ContainsKey(key)){
            throw new InvalidOperationException($"Duplicate key found: {key}");
        }

        _kvps.Add(key, item);
    }

    public bool ContainsKey(string key)
    {
        return _kvps.ContainsKey(key);
    }

    public bool ContainsValue(T value)
    {
        return _kvps.ContainsValue(value);
    }

    public T? Get(string key)
    {
        if(_kvps.TryGetValue(key, out T? value)){
            return value;
        }

        return default;
    }

    public IReadOnlyList<T> GetAll()
    {
        return [.. _kvps.Values];
    }
}
