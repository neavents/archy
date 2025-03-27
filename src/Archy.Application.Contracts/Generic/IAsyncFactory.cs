using System;

namespace Archy.Application.Contracts.Generic;

public interface IAsyncFactory<T, TOpts>
{
    public ValueTask<T> Create(TOpts? opts);
}

public interface IAsyncFactory<T, TOpts1, TOpts2>
{
    public ValueTask<T> Create(TOpts1? opts1, TOpts2? opts2);
}

public interface IAsyncFactory<T, TOpts1, TOpts2, TOpts3>
{
    public ValueTask<T> Create(TOpts1? opts1, TOpts2? opts2, TOpts3? opts3);
}
