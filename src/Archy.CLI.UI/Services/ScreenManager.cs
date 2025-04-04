using System;
using System.Threading.Tasks;
using Archy.Application.Contracts.UI.Services;
using Archy.CLI.UI.Compare;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Screens;
using Spectre.Console;

namespace Archy.CLI.UI.Services;

public class ScreenManager : IScreenManager
{
    private readonly List<IScreen> _screens = [];
    public ScreenManager(IEnumerable<IScreen> screens){
        _screens = [.. screens];
        _screens.Sort(new ScreenCompareByPriority());
    }
    public async ValueTask Render()
    {
        IScreen screen = new WelcomeScreen(3);
        
        await screen.Render();
    }

}
