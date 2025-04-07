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
        AnsiConsole.Clear(); 
        AnsiConsole.Background = Color.DarkSeaGreen;

        var layout = new Layout("root").SplitColumns(new Layout("left"), new Layout("right"));
        layout["left"].Ratio(3);
        layout["right"].Ratio(1);
        //layout["left"].Size(32);
        

        var figlet = new FigletText("archy")
            .LeftJustified()
            .Color(Color.White);

        var paddedFiglet = new Padder(figlet).PadTop(4).PadBottom(4);

        layout["left"].Update(paddedFiglet.Expand());
        AnsiConsole.Write(layout);

        IScreen screen = new WelcomeScreen(3);
        
        await screen.Render(layout);
    }

}
