using System;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;

public interface IScreen
{
    public int Priority {get; init;}
    public ValueTask<Toplevel> Render(Toplevel toplevel);
    public void Init();
}
