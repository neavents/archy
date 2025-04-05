using System;
using Archy.CLI.UI.Models.Elements;

namespace Archy.CLI.UI.Interfaces.Elements;

public interface IElement{
    public ValueTask Render();
}
public interface IElement<TKey>
{
    public ValueTask Render(ElementContext<TKey> context);
}

public interface IElement<TKey, TOut>{
    public ValueTask<TOut> Render(ElementContext<TKey> context);
}
