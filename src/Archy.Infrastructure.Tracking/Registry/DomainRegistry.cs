using System;
using Archy.Application.Contracts.Core;
using Archy.Infrastructure.Tracking.Models;

namespace Archy.Infrastructure.Tracking.Registry;

public class DomainRegistry : IRegistry<TrackedDomain>
{
    private readonly Dictionary<string, TrackedDomain> _trackeds = [];

    public void Add(TrackedDomain item)
    {
        
    }

    public bool ContainsKey(string key)
    {
        throw new NotImplementedException();
    }

    public TrackedDomain? Get(string key)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<TrackedDomain> GetAll()
    {
        throw new NotImplementedException();
    }
}
