using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedName : TrackedBase
{
    public required string CodeName {get; init;}
    public required JsonElement RuleJson {get; init;}

    public TrackedName(string name, string codeName, JsonElement ruleJson) : base(name){
        CodeName = codeName;
        RuleJson = ruleJson;
    }
}
