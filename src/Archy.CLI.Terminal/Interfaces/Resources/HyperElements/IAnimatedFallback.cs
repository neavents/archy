using System;

namespace Archy.CLI.Terminal.Interfaces.Resources.HyperElements;

public interface IAnimatedFallback : IFallback
{
    public Task Animate();
}
