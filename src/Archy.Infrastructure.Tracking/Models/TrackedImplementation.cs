using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedImplementation : TrackedBase
{
    public required TrackedDomain Domain {get; init;}
    public required TrackedCategory Category {get; init;}
    public required string Path {get; init;}
    public required JsonElement ImplementationJson {get; init;}

    public TrackedImplementation(TrackedDomain trackedDomain, TrackedCategory trackedCategory, string path, JsonElement implementationJson){
        Domain = trackedDomain;
        Category = trackedCategory;
        Path = path;
        ImplementationJson = implementationJson;
    
    }

    public void CheckDomainCompatibility(TrackedDomain? trackedDomain = null){
        if(trackedDomain is not null){
            bool comp = trackedDomain.Name == Domain.Name;
            if(!comp) throw new InvalidOperationException();
        }
    }
}
