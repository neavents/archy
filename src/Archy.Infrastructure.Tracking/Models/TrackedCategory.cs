using System;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedCategory : TrackedBase
{
    public TrackedDomain Domain {get; init;}
    public string Path {get; init;}

    public TrackedCategory(TrackedDomain trackedDomain, string path, string categoryName) : base(categoryName){
        Domain = trackedDomain;
        Path = path;
    }

    public void CheckDomainCompatibility(TrackedDomain trackedDomain){
        Domain.CheckCompatibility(trackedDomain);
    }
}
