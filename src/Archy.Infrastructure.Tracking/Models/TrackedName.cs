using System;
using System.Text.Json;
using Archy.Infrastructure.Core.Models.Tracking;

namespace Archy.Infrastructure.Tracking.Models;

public class TrackedName : TrackedBase
{
    public string CodeName {get; init;}
    public JsonElement RuleJson {get; init;}

    public TrackedName(string name, string codeName, JsonElement ruleJson) : base(name){
        CodeName = codeName;
        RuleJson = ruleJson;
    }
}
