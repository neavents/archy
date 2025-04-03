using System;

namespace Archy.Infrastructure.Tracking.Interfaces;

public interface IDependencyTracker<T>
{
    public ValueTask<IEnumerable<T>> Track();
}
