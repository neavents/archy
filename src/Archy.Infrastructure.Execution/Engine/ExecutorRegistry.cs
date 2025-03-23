using System;
using Archy.Application.Contracts.Execution;
using Archy.Application.Contracts.Core;

namespace Archy.Infrastructure.Execution.Engine;

public class ExecutorRegistry : IRegistry<IRuleExecutor>
{
    private readonly Dictionary<string, IRuleExecutor> _executors = [];
    public void Add(IRuleExecutor item)
    {
        if(_executors.ContainsKey(item.RuleKey)){
            throw new InvalidOperationException($"Duplicate rule found: {item.RuleKey}");
        }

        _executors.Add(item.RuleKey, item);
    }

    public IRuleExecutor? Get(string key)
    {
        if (_executors.TryGetValue(key, out IRuleExecutor? executor)){
             return executor;
        }

        return null;
    }

    public IReadOnlyList<IRuleExecutor> GetAll()
    {
        return _executors.Values.ToList();
    }
}
