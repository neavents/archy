using System;
using System.Threading.Tasks;
using Archy.Application.Contracts.Terminal.Core.Engines;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.CLI.Services;

public class EntryPoint
{
    private readonly IServiceProvider _services;
    public EntryPoint(IServiceProvider services){
        _services = services;
    }

    public async Task Run(){
        IScreenEngine screen = _services.GetRequiredService<IScreenEngine>();
        ITerminalEngine terminal = _services.GetRequiredService<ITerminalEngine>();
        TerminalUI terminalUI = new (terminal, screen);

        await terminalUI.RenderUI();
    }
}
