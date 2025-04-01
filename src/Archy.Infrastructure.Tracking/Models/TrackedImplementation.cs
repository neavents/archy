using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedImplementation : TrackedBase
{
    public TrackedDomain Domain {get; init;}
    public TrackedCategory Category {get; init;}
    public string Path {get; init;}
    public JsonElement ImplementationJson {get; init;}

    public TrackedImplementation(string implementationName, TrackedDomain trackedDomain, TrackedCategory trackedCategory, string path, JsonElement implementationJson) : base(implementationName){
        Domain = trackedDomain;
        Category = trackedCategory;
        Path = path;
        ImplementationJson = implementationJson;

        CheckCompatibility();
    }

    private void checkDomainCompatibility(TrackedDomain? trackedDomain = null){
        if(trackedDomain is not null){
            Domain.CheckCompatibility(trackedDomain);
        }
    }

    private void checkCategoryDomainCompatibility(TrackedDomain? trackedDomain = null){
        if(trackedDomain is not null) {
            Category.CheckDomainCompatibility(trackedDomain);
        }

        Category.CheckDomainCompatibility(Domain);
    }
    
    public void CheckCompatibility(TrackedDomain? trackedDomain = null){
        checkDomainCompatibility(trackedDomain);
        checkCategoryDomainCompatibility(trackedDomain);
    }
}
