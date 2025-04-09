using System;
using Terminal.Gui;

namespace Archy.Application.Contracts.Terminal.Core.Engines;

public interface IScreenEngine
{
    public ValueTask<Toplevel> Render();
}
