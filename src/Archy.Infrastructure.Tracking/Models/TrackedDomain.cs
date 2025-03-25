using System;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedDomain : TrackedBase
{
    public required string Path {get; init;}

    public TrackedDomain(string path, string name) : base(name){
        Path = path;
    }

    public void CheckCompatibility(TrackedDomain trackedDomain){
        if(Name != trackedDomain.Name){
            throw new ArgumentException($"Domain ({Name}) is not compatible with given domain ({trackedDomain.Name})");
        }
    }
}
