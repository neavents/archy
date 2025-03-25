using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedPackage : TrackedBase
{
    public required TrackedCategory Category {get; init;}
    public required TrackedDomain Domain {get; init;}
    public required string Path {get; init;}
    public required JsonElement ConfigurationJson {get; init;}

    public TrackedPackage(string name, TrackedCategory trackedCategory, TrackedDomain trackedDomain, string path, JsonElement configurationJson) : base (name){
        Category = trackedCategory;
        Domain = trackedDomain;
        Path = path;
        ConfigurationJson = configurationJson;
    }

    public void CheckCompatibility(){
        
    }

}
