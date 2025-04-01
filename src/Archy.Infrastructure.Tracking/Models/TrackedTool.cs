using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedTool : TrackedBase
{
    public TrackedCategory Category {get; init;}
    public TrackedDomain Domain {get; init;}
    public string Path {get; init;}
    public TrackedPackage Package {get; init;}
    public JsonElement UsageJson {get; init;}

    public List<TrackedImplementation> Implementations {get; init;}

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
