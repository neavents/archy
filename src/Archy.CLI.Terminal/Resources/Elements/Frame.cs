using System;
using Archy.CLI.Terminal.Data.Constants;
using Archy.CLI.Terminal.Data.Models;
using Archy.CLI.Terminal.Interfaces.Resources.Elements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.Elements;

public class Frame : IElement
{
    private readonly FrameView _frameView;

    public Frame(string? name = null, View? parentView = null){
        _frameView = new FrameView(title: name){
            X = ViewStandards.StandardViewConfig.X,
            Y = ViewStandards.StandardViewConfig.Y,
            Height = ViewStandards.StandardViewConfig.Height,
            Width = ViewStandards.StandardViewConfig.Width
        };

        if(parentView is not null){
            parentView.Add(_frameView);
        }
    }
    public Frame(ViewConfig config, string? name = null,  View? parentView = null){
        _frameView = new FrameView(title: name){
            X = config.X,
            Y = config.Y,
            Height = config.Height,
            Width = config.Width
        };

        if(parentView is not null){
            parentView.Add(_frameView);
        }
    }
    public void RenderIn(View view)
    {
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
