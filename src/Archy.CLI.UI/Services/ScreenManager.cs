using System;
using System.Threading.Tasks;
using Archy.Application.Contracts.UI.Services;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Screens;
using Spectre.Console;

namespace Archy.CLI.UI.Services;

public class ScreenManager : IScreenManager
{
    public async ValueTask Render()
    {
        IScreen screen = new WelcomeScreen();
        await screen.Render();
    }

}
