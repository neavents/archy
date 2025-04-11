using System;
using Archy.CLI.Terminal.Interfaces.Resources.Elements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.Elements;

public class Selection<T> : IElement
{
    private readonly ListView _listView;
    private readonly FrameView _frameView;
    private readonly List<T> _elements;
    public Selection(List<T> elements){
        _elements = elements;

        _frameView = new FrameView(){
            X = 1,
            Y = 16,
            Width = 16,
            Height = 10,    
        };

        IElement element = new Frame();
        

        _listView = new ListView(_elements){
            X = 0,
            Y = 0, // Below path label and button
            Width = 16, // Fill the left pane width
            Height = 10, // Fill the remaining height in the left pane
            AllowsMarking = false, // We use OpenSelectedItem for selection action
            AllowsMultipleSelection = false,
        };
        element.Add(_listView);
        _frameView.Add(_listView);
    }
    public void RenderIn(View view){
        view.Add(_frameView);
    }
    public void Add(View view){
        _frameView.Add(view);
    }

    public View GetView()
    {
        return _frameView;
    }
}
