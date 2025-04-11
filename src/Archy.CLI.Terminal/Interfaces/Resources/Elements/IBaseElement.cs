using System;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Interfaces.Resources.Elements;

public interface IBaseElement
{
    public void RenderIn(View view);
    public void Add(View view);
}
