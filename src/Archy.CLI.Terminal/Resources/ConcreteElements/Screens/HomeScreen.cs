using System;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;

namespace Archy.CLI.Terminal.Resources.ConcreteElements.Screens;

public class HomeScreen : IScreen
{
    public int Priority { get; init; }

    public HomeScreen(int? priority = null){
        Priority = priority ?? 0;
    }

    public async ValueTask Render()
    {
        
    }
}
