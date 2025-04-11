using System;
using Archy.CLI.Terminal.Interfaces.Resources.HyperElements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.HyperElements.Frames;

public class InfoFrame : IHyperElement
{
    private readonly Label _label;
    public InfoFrame(){
        _label = new Label("NABERSINIZ DENEME");
    }
    public void Add(View view)
    {
        _label.Add(view);
    }

    public void RenderIn(View view)
    {
        view.Add(_label);
    }
}
