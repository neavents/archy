using System;

namespace Archy.Application.Contracts.Generic;

public interface IAsyncFactory<T, TOpts>
{
    public ValueTask<T> Create(TOpts? opts);
}
