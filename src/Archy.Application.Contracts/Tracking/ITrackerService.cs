using System;

namespace Archy.Application.Contracts.Tracking;

public interface ITrackerService
{
    public Task TrackAllAsync();
}
