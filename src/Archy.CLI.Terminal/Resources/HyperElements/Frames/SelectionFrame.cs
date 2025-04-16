using System;
using Archy.CLI.Terminal.Interfaces.Resources.HyperElements;
using Archy.CLI.Terminal.Resources.HyperElements.Texts;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.HyperElements.Frames;

public class SelectionFrame : IHyperElement
{   
    private readonly FrameView _frame;
    private readonly IAnimatedFallback _animatedFallback;
    public SelectionFrame(){
        _animatedFallback = new FallbackLoadingText();
        _frame = new FrameView(){
            Height = Dim.Fill(),
            Width = Dim.Fill()
        };

        
    }

    public void Add(View view)
    {
        _frame.Add(view);
    }

    private async void AnimateFallback(){
        await _animatedFallback.Animate();
    }

    public void RenderIn(View view)
    {
        _animatedFallback.Start("archy");
        _animatedFallback.RenderIn(_frame);
        AnimateFallback();
        view.Add(_frame);
    }
}
