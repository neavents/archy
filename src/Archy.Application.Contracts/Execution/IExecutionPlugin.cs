using System;
using Archy.Application.Contracts.Core;

namespace Archy.Application.Contracts.Execution;

public interface IExecutionPlugin
{
    public void Register(IRegistry<IRuleExecutor> ruleRegistry);
}
