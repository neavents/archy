using System;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.ConcreteElements.Screens;

public class HomeScreen : IScreen
{
    public int Priority { get; init; }

    public HomeScreen(int? priority = null){
        Priority = priority ?? 0;
    }

    public async ValueTask<Toplevel> Render()
    {
        Window window = new Window(){
            Text = "Hello Everyone",
        };

        return window;
    }
}
