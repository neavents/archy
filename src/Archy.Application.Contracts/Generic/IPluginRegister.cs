using System;
using Archy.Application.Contracts.Core;

namespace Archy.Application.Contracts.Generic;

public interface IPluginRegister<T>
{
    public void Register(IRegistry<T> registry);
}
