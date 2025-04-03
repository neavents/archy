using System;
using System.Collections;
using Archy.Domain.Interfaces.Markers;
using Archy.Infrastructure.Tracking.Interfaces.Markers;


namespace Archy.Infrastructure.Tracking.Interfaces;

public interface IDependencyTracker : ITracker
{
    public Type TrackerType {get;}
    public ValueTask<IEnumerable<ITracked>> GenericTrack();
}
public interface IDependencyTracker<T> : IDependencyTracker
{
    public ValueTask<IEnumerable<T>> Track();
}
