using System;
using Archy.Application.Contracts.Core;
using Archy.Application.Contracts.Generic;

namespace Archy.Application.Contracts.Execution;

public interface IExecutionPlugin : IPluginRegister<string, IRuleExecutor>
{
    
}
