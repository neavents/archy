using System;

namespace Archy.Application.Contracts.Generic;

public interface IFactory<T, TOpts>
{
    public T Create(TOpts? opts);
}

public interface IFactory<T, TOpts1, TOpts2>
{
    public T Create(TOpts1? opts1, TOpts2? opts2);
}

public interface IFactory<T, TOpts1, TOpts2, TOpts3>
{
    public T Create(TOpts1? opts1, TOpts2? opts2, TOpts3? opts3);
}