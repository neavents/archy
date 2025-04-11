using System;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Interfaces.Resources.Elements;

public interface IElement : IBaseElement
{
    public View GetView();
}