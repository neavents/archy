using System;

namespace Archy.Application.Contracts.Generic;

public interface IFactory<T, TOpts>
{
    public T Create(TOpts? opts);
}
