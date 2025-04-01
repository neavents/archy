using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedPackage : TrackedBase
{
    public TrackedCategory Category {get; init;}
    public TrackedDomain Domain {get; init;}
    public string Path {get; init;}
    public JsonElement ConfigurationJson {get; init;}

    public TrackedPackage(string name, TrackedCategory trackedCategory, TrackedDomain trackedDomain, string path, JsonElement configurationJson) : base (name){
        Category = trackedCategory;
        Domain = trackedDomain;
        Path = path;
        ConfigurationJson = configurationJson;

        CheckCompatibility();
    }

    private void checkPath(){

    }
    public void CheckCompatibility(){
        Category.CheckDomainCompatibility(Domain);
        checkPath();
    }

    public void CheckCompatibility(TrackedDomain trackedDomain){
        Category.CheckDomainCompatibility(trackedDomain);
        Domain.CheckCompatibility(trackedDomain);
        checkPath();
    }

}
