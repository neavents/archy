using System;
using Archy.Application.Contracts.Terminal.Core.Engines;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;
using Archy.CLI.Terminal.Resources.ConcreteElements.Screens;
using Archy.Domain.Settings;
using Microsoft.Extensions.Options;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Core.Engines;

public class ScreenEngine : IScreenEngine
{
    private readonly IScreen _homeScreen;

    public ScreenEngine(IOptions<VersionOptions> versionOptions){
        _homeScreen = new LayoutTestingScreen(versionOptions);
    }
    public async ValueTask<Toplevel> Render()
    {
        Toplevel toplevel = new Toplevel();
        await _homeScreen.Init(toplevel);

        return await _homeScreen.Render(toplevel);
    }
}
