using System;

namespace Archy.Application.Contracts.Generic;

public interface IPlugin
{
    public void Execute();
}

public interface IPlugin<T>{
    public void Execute(T input);
}

public interface IPlugin<TIn, TOut>{
    public TOut Execute(TIn input);
}
