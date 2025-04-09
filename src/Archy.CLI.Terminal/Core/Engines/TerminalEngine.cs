using System;
using Archy.Application.Contracts.Terminal.Core.Engines;
using Terminal.Gui;
using TerminalUI = Terminal.Gui;

namespace Archy.CLI.Terminal.Core.Engines;

public class TerminalEngine : ITerminalEngine
{
    private List<Toplevel> toBeDisposed = [];

    public async Task Start(Toplevel view)
    {
        TerminalUI.Application.Init();
        TerminalUI.Application.Run(view);

        toBeDisposed.Add(view);

    }

    public async Task Stop()
    {
        foreach(Toplevel view in toBeDisposed){
            view.Dispose();
        }
        
        TerminalUI.Application.Shutdown();
    }
}
