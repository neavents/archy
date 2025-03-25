using System;
using Archy.Application.Contracts.Core;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Core.Registry;

public class TrackedsGenericRegistry<T> : IRegistry<T> where T : TrackedBase
{
    private readonly Dictionary<string, T> _kps = [];

    public void Add(T item)
    {
        if(_kps.ContainsKey(item.Name)){
            throw new InvalidOperationException($"Duplicate key found: {item.Name}");
        }

        _kps.Add(item.Name, item);
    }

    public T? Get(string key)
    {
        if(_kps.TryGetValue(key, out T? value)){
            return value;
        }

        return default;
    }

    public IReadOnlyList<T> GetAll()
    {
        return [.. _kps.Values];
    }

    public bool ContainsKey(string key){
        return _kps.ContainsKey(key);
    }

    public bool ContainsValue(T value){
        return _kps.ContainsValue(value);
    }
}
