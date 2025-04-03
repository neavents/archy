using System;
using Archy.Domain.Interfaces.Markers;

namespace Archy.Infrastructure.Core.Models.Tracking;

public class TrackedBase : ITracked
{
    public string Name {get; set;}

    public TrackedBase(string name){
        Name = name;
    }
}
