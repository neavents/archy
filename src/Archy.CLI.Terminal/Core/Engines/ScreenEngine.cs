using System;
using Archy.Application.Contracts.Terminal.Core.Engines;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;
using Archy.CLI.Terminal.Resources.ConcreteElements.Screens;

namespace Archy.CLI.Terminal.Core.Engines;

public class ScreenEngine : IScreenEngine
{
    private readonly IScreen _homeScreen;
    public ScreenEngine(){
        _homeScreen = new HomeScreen();
    }
    public async ValueTask Render()
    {
        await _homeScreen.Render();
    }
}
