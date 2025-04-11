using System;
using Archy.CLI.Terminal.Data.Models;
using Archy.CLI.Terminal.Interfaces.Core.Services;
using Archy.CLI.Terminal.Interfaces.Resources.Elements;
using Archy.CLI.Terminal.Resources.Elements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Core.Services.Adaptors;

public class VerticalSlicerAdaptor : ISlicer
{
    private readonly List<View> _views;
    public VerticalSlicerAdaptor(){
        _views = [];
    }

    public List<View> Slice(View toBeSlicedView, int count = 1)
    {
        if(count == 1){
            IElement frame = new Frame(parentView: toBeSlicedView);
            _views.Add(frame.GetView());
            return _views;
        }

        int perViewPercent = 100 / count;

        for(int i = 0; i < count; i++){
            ViewConfig config = new ViewConfig(){
                X = i == 0 ? 0 : Pos.Right(_views[i-1]),
                Y = 0,
                Height = Dim.Fill(),
                Width = Dim.Percent(perViewPercent)
            };

            IElement frame = new Frame(config: config, parentView: toBeSlicedView);
            
            _views.Add(frame.GetView());
        }    

        return _views;
    }
}
