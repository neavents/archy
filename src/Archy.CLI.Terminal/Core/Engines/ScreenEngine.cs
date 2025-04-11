using System;
using Archy.Application.Contracts.Terminal.Core.Engines;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;
using Archy.CLI.Terminal.Resources.ConcreteElements.Screens;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Core.Engines;

public class ScreenEngine : IScreenEngine
{
    private readonly IScreen _homeScreen;
    public ScreenEngine(){
        _homeScreen = new LayoutTestingScreen();
    }
    public async ValueTask<Toplevel> Render()
    {
        Toplevel toplevel = new Toplevel();
        _homeScreen.Init();

        return await _homeScreen.Render(toplevel);
    }
}
