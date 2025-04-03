using System;

namespace Archy.Application.Contracts.Generic;


public interface IAsyncPlugin
{
    public ValueTask ExecuteAsync();
}

public interface IAsyncPlugin<T>{
    public ValueTask ExecuteAsync(T input);
}

public interface IAsyncPlugin<TIn, TOut>{
    public ValueTask<TOut> ExecuteAsync(TIn input);
}

