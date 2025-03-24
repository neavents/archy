using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedTool : TrackedBase
{
    public required TrackedCategory Category {get; init;}
    public required TrackedDomain Domain {get; init;}
    public required string Path {get; init;}

    public required JsonElement UsageJson {get; init;}

    public required List<TrackedImplementation> Implementations {get; init;}

    public TrackedTool(TrackedCategory trackedCategory, TrackedDomain trackedDomain, string path, JsonElement usageJson, List<TrackedImplementation> trackedImplementations){
        Category = trackedCategory;
        Domain = trackedDomain;
        Path = path;
        UsageJson = usageJson;
        Implementations = trackedImplementations;

        CheckCompatibility();
    }

    private void CheckCategoryCompatibility(){

    }

    private void CheckPath(){

    }

    private void CheckImplementationsCompatibilty(){

    }

    private void CheckNamingCompatibility(){

    }

    public void CheckCompatibility(){
        CheckCategoryCompatibility();
        CheckPath();
        CheckImplementationsCompatibilty();
        CheckNamingCompatibility();
    }

}
