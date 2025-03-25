using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedTool : TrackedBase
{
    public required TrackedCategory Category {get; init;}
    public required TrackedDomain Domain {get; init;}
    public required string Path {get; init;}
    public required TrackedPackage Package {get; init;}
    public required JsonElement UsageJson {get; init;}

    public required List<TrackedImplementation> Implementations {get; init;}

    public TrackedTool(string toolName, TrackedCategory trackedCategory, TrackedDomain trackedDomain, string path, TrackedPackage trackedPackage, JsonElement usageJson, List<TrackedImplementation> trackedImplementations) : base(toolName){
        Category = trackedCategory;
        Domain = trackedDomain;
        Path = path;
        UsageJson = usageJson;
        Implementations = trackedImplementations;
        Package = trackedPackage;

        CheckCompatibility();
    }

    private void CheckPath(){

    }

    private void checkImplementationsCompatibilty(){
        foreach(TrackedImplementation implementation in Implementations){
            implementation.CheckCompatibility(Domain);
        }
    }

    private void checkImplementationsCompatibilty(TrackedDomain trackedDomain){
        foreach(TrackedImplementation implementation in Implementations){
            implementation.CheckCompatibility(trackedDomain);
        }
    }

    private void checkNamingCompatibility(){

    }

    public void CheckCompatibility(){
        Category.CheckDomainCompatibility(Domain);
        Package.CheckCompatibility(Domain);
        CheckPath();
        checkImplementationsCompatibilty();
        checkNamingCompatibility();
    }

}
