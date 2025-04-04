using System;
using Archy.Application.Contracts.Core;

namespace Archy.Application.Contracts.Generic;

public interface IPluginRegister<TKey, TValue>
{
    public void Register(IRegistry<TKey, TValue> registry);
}
