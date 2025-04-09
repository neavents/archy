using System;
using Terminal.Gui;

namespace Archy.Application.Contracts.Terminal.Core.Engines;

public interface ITerminalEngine
{
    public Task Start(Toplevel view);
    public Task Stop();
}
