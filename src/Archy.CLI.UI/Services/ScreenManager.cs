using System;
using System.Threading.Tasks;
using Archy.Application.Contracts.Terminal.Core.Engines;
using Archy.CLI.UI.Compare;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Interfaces.Services.Engines;
using Archy.CLI.UI.Screens;
using Archy.CLI.UI.Services.Engines;
using Spectre.Console;

namespace Archy.CLI.UI.Services;

public class ScreenManager : Application.Contracts.Terminal.Core.Engines.IScreenEngine
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

        ILayoutEngine layoutEngine = new LayoutEngine();
        
        //layout["left"].Size(32);
        

        var figlet = new FigletText("archy")
            .LeftJustified()
            .Color(Color.White);
        var figlet2 = new FigletText("neavents")
            .LeftJustified()
            .Color(Color.White);

        var grid = new Grid();
        grid.AddColumn();
        grid.AddColumn();

        var infoText = new Text("by Neavents", Color.MediumPurple);
        var versionText = new Text("v0.0.1", Color.Grey30);
        var authorNameText = new Text("Polat Efe Kaya", Color.Grey50);
        grid.AddRow(infoText, authorNameText);
        grid.AddRow(versionText);

        var paddedFiglet = new Padder(figlet).PadTop(1).PadBottom(1);
        var paddedGrid = new Padder(grid).PadTop(0).PadBottom(2).PadLeft(5);

        var langTree = new Tree("[blue]Language[/]");
        langTree.AddNode("C# [grey](dotnet)[/]");

        var archTree = new Tree("[blue]Architecture[/]");
        archTree.AddNode("complex");

        var tree = new Tree("[blue]Domains[/]");
        var db = tree.AddNode("[mediumpurple]database[/]");
        var msg = tree.AddNode("[mediumpurple]messaging[/]");
        var auth = tree.AddNode("[mediumpurple]auth[/]");
        var sc = tree.AddNode("[mediumpurple]security[/]");

        var postgresql = db.AddNode("postgresql");
        var mysql = db.AddNode("mysql");

        var rabbitmq = msg.AddNode("rabbit-mq");

        var selectionGrid = new Grid();
        selectionGrid.AddColumn();
        selectionGrid.AddRow(langTree);
        selectionGrid.AddEmptyRow();
        selectionGrid.AddRow(archTree);
        selectionGrid.AddEmptyRow();
        selectionGrid.AddRow(tree);
        
        var selectionPanel = new Panel(selectionGrid).Header(new PanelHeader(" Selections ", Justify.Center)).Border(BoxBorder.Rounded);
        // selectionPanel.Height = 60;

        layoutEngine.Add("left:header", new() {Name = "HeaderFiglet",Renderable = paddedFiglet.Expand()});
        //layoutEngine.Render();
        layoutEngine.Add("left:info", new() {Name = "OtherFiglet",Renderable = paddedGrid.Expand()});
        layoutEngine.Add("right", new(){Name="Panel", Renderable = selectionPanel.Expand()});
        
        layoutEngine.Render();

        IScreen screen = new WelcomeScreen(3);
        
        await screen.Render();
    }

}
