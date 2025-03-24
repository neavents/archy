using System;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedCategory : TrackedBase
{
    public required TrackedDomain Domain {get; init;}
    public required string Path {get; init;}
}
