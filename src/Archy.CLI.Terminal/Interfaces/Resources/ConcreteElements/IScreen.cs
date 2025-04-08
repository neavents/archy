using System;

namespace Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;

public interface IScreen
{
    public int Priority {get; init;}
    public ValueTask Render();
}
