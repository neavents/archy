using System;

namespace Archy.CLI.Terminal.Interfaces.Resources.HyperElements;

public interface IFallback : IHyperElement
{
    public void Start(string text);
    public void Stop();
}
