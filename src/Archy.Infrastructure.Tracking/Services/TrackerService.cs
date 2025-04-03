using System;
using System.Collections;
using System.Threading.Tasks;
using Archy.Application.Contracts.Core;
using Archy.Application.Contracts.Tracking;
using Archy.Domain.Interfaces.Markers;
using Archy.Infrastructure.Core.Models.Tracking;
using Archy.Infrastructure.Tracking.Interfaces;
using Archy.Infrastructure.Tracking.Models;

namespace Archy.Infrastructure.Tracking.Services;

public class TrackerService : ITrackerService
{
    private readonly IEnumerable<IDependencyTracker> _dependencyTrackers;
    private readonly IRegistry<Type, IEnumerable<ITracked>> _trackedsRegistry;

    public TrackerService(IEnumerable<IDependencyTracker> dependencyTrackers, IRegistry<Type, IEnumerable<ITracked>> trackedsRegistry) {
        _dependencyTrackers = dependencyTrackers;
        _trackedsRegistry = trackedsRegistry;
    }

    public async Task TrackAllAsync(){
        await Task.Run(async () => {
            foreach(IDependencyTracker dependencyTracker in _dependencyTrackers){
                IEnumerable<ITracked> result = await dependencyTracker.GenericTrack();

                if(_trackedsRegistry.TryGetValue(dependencyTracker.TrackerType, out var value)){
                    _trackedsRegistry.AddRange(() => dependencyTracker.TrackerType, () => [.. value ?? [], .. result]);
                    continue;
                }

                _trackedsRegistry.Add(result, ks => dependencyTracker.TrackerType);
            }
        });
    }

    
}
