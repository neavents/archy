using System;

namespace Archy.Infrastructure.Core.Models.Tracking;

public class TrackedBase
{
    public string Name {get; set;}

    public TrackedBase(string name){
        Name = name;
    }
}
