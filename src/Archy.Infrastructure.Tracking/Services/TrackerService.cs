using System;
using System.Threading.Tasks;
using Archy.Application.Contracts.Core;
using Archy.Infrastructure.Tracking.Interfaces;
using Archy.Infrastructure.Tracking.Models;

namespace Archy.Infrastructure.Tracking.Services;

public class TrackerService
{
    private readonly IDependencyTracker<TrackedDomain> _domainTracker;
    private readonly IDependencyTracker<TrackedImplementation> _implementationTracker;
    private readonly IDependencyTracker<TrackedName> _nameTracker;
    private readonly IDependencyTracker<TrackedPackage> _packageTracker;
    private readonly IDependencyTracker<TrackedTool> _toolTracker;
    private readonly IDependencyTracker<TrackedCategory> _categoryTracker;

    private readonly IRegistry<TrackedCategory> _trackedCategories;

    public TrackerService(IDependencyTracker<TrackedDomain> domainTracker,
        IDependencyTracker<TrackedImplementation> implementationTracker,
        IDependencyTracker<TrackedName> nameTracker,
        IDependencyTracker<TrackedPackage> packageTracker,
        IDependencyTracker<TrackedTool> toolTracker,
        IDependencyTracker<TrackedCategory> categoryTracker,
        IRegistry<TrackedCategory> trackedCategories
        ) {
            _categoryTracker = categoryTracker;
            _toolTracker = toolTracker;
            _packageTracker = packageTracker;
            _nameTracker = nameTracker;
            _implementationTracker = implementationTracker;
            _domainTracker = domainTracker;
    }

    public async Task TrackAllAsync(){
        _trackedCategories.AddRange(await _categoryTracker.Track(), ks => ks.Name);
    }

    
}
