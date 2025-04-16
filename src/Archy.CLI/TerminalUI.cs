using System;
using System.Threading.Tasks;
using Archy.Application.Contracts.Terminal.Core.Engines;

namespace Archy.CLI;

public class TerminalUI
{
    private readonly ITerminalEngine _terminalEngine;
    private readonly IScreenEngine _screenEngine;
    public TerminalUI(ITerminalEngine terminalEngine, IScreenEngine screenEngine){
        _terminalEngine = terminalEngine;
        _screenEngine = screenEngine;
    }
    public async Task RenderUI(){
        await _terminalEngine.Init();
        
        var screen = await _screenEngine.Render();
        
        await _terminalEngine.Start(screen);

        await _terminalEngine.Stop();
    }
}
