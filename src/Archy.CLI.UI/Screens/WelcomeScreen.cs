using System;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Models.Progresses;

namespace Archy.CLI.UI.Screens;

public class WelcomeScreen : IScreen
{
    public async ValueTask Render()
    {
        var element = new SearchingProgress();
        await element.Execute();
    }
}
