using System;
using Archy.Application.Contracts.Core;
using Archy.Infrastructure.Core.Models.Globbing;
using DotNet.Globbing;

namespace Archy.Infrastructure.Core.Registry;

public class GlobRegistry : IRegistry<GlobWrapper>
{
    private readonly Dictionary<string, GlobWrapper> _kvp = [];

    public void Add(GlobWrapper item, Func<GlobWrapper, string> keySelecto)
    {
        if(_kvp.ContainsKey(item.FinderPath)){
            throw new InvalidOperationException($"Duplicate key found: {item.FinderPath}");
        }

        _kvp.Add(item.FinderPath, item);
    }
    public void Addv(GlobWrapper item, Func<GlobWrapper, string> keySelector)
    {
        
        if(_kvp.ContainsKey(keySelector(item))){
            throw new InvalidOperationException($"Duplicate key found: {item.FinderPath}");
        }

        _kvp.Add(item.FinderPath, item);
    }
    public bool ContainsKey(string key)
    {
        return _kvp.ContainsKey(key);
    }

    public bool ContainsValue(GlobWrapper value)
    {
        return _kvp.ContainsValue(value);
    }

    public GlobWrapper? Get(string key)
    {
        if(_kvp.TryGetValue(key, out GlobWrapper? value)){
            return value;
        }

        return null;
    }

    public IReadOnlyList<GlobWrapper> GetAll()
    {
        return [.. _kvp.Values];
    }
}
