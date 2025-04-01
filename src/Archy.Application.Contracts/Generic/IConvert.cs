using System;

namespace Archy.Application.Contracts.Generic;

public interface IConvert<TIn, TOut>
{
    public TOut From(TIn input); 
}
