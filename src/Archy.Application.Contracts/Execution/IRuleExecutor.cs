using System;
using System.Text.Json;
using Archy.Domain.ValueObjects;

namespace Archy.Application.Contracts.Execution;

public interface IRuleExecutor
{
    public string RuleKey {get;}
    public Task ExecuteAsync(RuleContext context, JsonElement ruleData);
}
