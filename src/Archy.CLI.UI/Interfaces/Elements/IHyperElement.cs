using System;

namespace Archy.CLI.UI.Interfaces.Elements;

public interface IHyperElement : IElement
{

}

public interface IHyperElement<TKey> : IElement<TKey>{

}

public interface IHyperElement<TKey, TOut> : IElement<TKey, TOut>{

} 