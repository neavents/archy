using System;
using Archy.Application.Contracts.Core.IO;
using Archy.Infrastructure.Tracking.Interfaces;
using Archy.Infrastructure.Tracking.Models;

namespace Archy.Infrastructure.Tracking.Services.Trackers;

public class DomainTracker : IDependencyTracker<TrackedDomain>
{
    private readonly IFinder _finder;

    public DomainTracker (IFinder finder){
        _finder = finder;
    }
    public ValueTask<List<TrackedDomain>> Track()
    {
        
        //Open the configurations directory
        //each subdirectory is domain


    }
}
