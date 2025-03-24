using System;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedDomain : TrackedBase
{
    public required string Path {get; init;}
}
