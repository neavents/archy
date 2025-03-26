using System;
using Archy.Infrastructure.Tracking.Interfaces;
using Archy.Infrastructure.Tracking.Models;

namespace Archy.Infrastructure.Tracking.Services.Trackers;

public class DomainTracker : IDependencyTracker<TrackedDomain>
{
    public ValueTask<List<TrackedDomain>> Track()
    {
        
        //Open the configurations directory
        //each subdirectory is domain
    }
}
