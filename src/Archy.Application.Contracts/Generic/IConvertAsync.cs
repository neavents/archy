using System;

namespace Archy.Application.Contracts.Generic;

public interface IAsyncConvert<TIn, TOut>
{
    public ValueTask<TOut> FromAsync(TIn input);
}
