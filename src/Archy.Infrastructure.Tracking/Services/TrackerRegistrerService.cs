using System;
using Archy.Application.Contracts.Core;
using Archy.Domain.Interfaces.Markers;
using Archy.Infrastructure.Tracking.Models;

namespace Archy.Infrastructure.Tracking.Services;

public class TrackerRegistrerService
{
    private readonly IRegistry<TrackedDomain> _trackedDomainRegistry;
    private readonly IRegistry<TrackedImplementation> _trackedImplementationRegistry;
    private readonly IRegistry<TrackedName> _trackedNameRegistry;
    private readonly IRegistry<TrackedPackage> _trackedPackageRegistry;
    private readonly IRegistry<TrackedTool> _trackedToolRegistry;
    private readonly IRegistry<TrackedCategory> _trackedCategoryRegistry;
    private readonly Dictionary<Type, IEnumerable<ITracked>> _trackeds = [];
    private readonly IRegistry<Type, ITracked> registry;

    public TrackerRegistrerService(
        IRegistry<TrackedDomain> trackedDomainRegistry,
        IRegistry<TrackedImplementation> trackedImplementationRegistry,
        IRegistry<TrackedName> trackedNameRegistry,
        IRegistry<TrackedPackage> trackedPackageRegistry,
        IRegistry<TrackedTool> trackedToolRegistry,
        IRegistry<TrackedCategory> trackedCategoryRegistry)
    {
            _trackedDomainRegistry = trackedDomainRegistry;
            _trackedImplementationRegistry = trackedImplementationRegistry;
            _trackedNameRegistry = trackedNameRegistry;
            _trackedPackageRegistry = trackedPackageRegistry;
            _trackedToolRegistry = trackedToolRegistry;
            _trackedCategoryRegistry = trackedCategoryRegistry;
    }

    public void something<T>(IEnumerable<T> cat){
        registry.Add(new TrackedCategory(), ks => typeof(TrackedCategory));
        registry.AddRange()
    }
}
