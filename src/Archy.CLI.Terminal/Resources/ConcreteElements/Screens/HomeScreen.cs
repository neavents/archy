using System;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;
using Archy.CLI.Terminal.Resources.Elements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.ConcreteElements.Screens;

public class HomeScreen : IScreen
{
    public int Priority { get; init; }
    private List<string> _directoryList;
    private ListView _listWiew;

    public HomeScreen(int? priority = null)
    {
        Priority = priority ?? 0;
        _directoryList = [];
    }
    public async ValueTask<Toplevel> Init(Toplevel toplevel){
        return toplevel;
    }

    public async ValueTask<Toplevel> Render(Toplevel topLevel)
    {
        Button button = new Button() { Text = "Naber" };

        Window w2 = new Window()
        {
            Title = "Zamazingo",
            Text = "LOloLoloo",
            Width = 16,
            Height = 6,
            X = Pos.AnchorEnd(32),


        };

        var selection = new Selection<string>(_directoryList);

        _listWiew = new ListView(_directoryList) // Start with empty list initially
        {
            X = Pos.AnchorEnd(16),
            Y = 1, // Below path label and button
            Width = 16, // Fill the left pane width
            Height = Dim.Fill(), // Fill the remaining height in the left pane
            AllowsMarking = false, // We use OpenSelectedItem for selection action
            AllowsMultipleSelection = false
        };

        button.Clicked += OnButtonClicked;


        var label1 = new Label() { X = 1, Y = 2, Width = 3, Height = 4, Text = "Absolute" };

        var label2 = new Label()
        {
            Text = "Computed",
            X = Pos.Right(topLevel),
            Y = Pos.Center(),
            Width = Dim.Fill(),
            Height = Dim.Percent(50)
        };
        selection.RenderIn(topLevel);
        topLevel.Add(button);
        topLevel.Add(label1);
        topLevel.Add(label2);
        topLevel.Add(w2);
        topLevel.Add(_listWiew);

        return topLevel;
    }

    private void OnButtonClicked(){
        _directoryList.Add("Random Text");
        _listWiew.SetFocus();
        _listWiew.EnsureSelectedItemVisible();
    }
}
