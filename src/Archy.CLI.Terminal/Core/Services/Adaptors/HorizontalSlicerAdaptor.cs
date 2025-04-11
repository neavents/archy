using System;
using Archy.CLI.Terminal.Data.Models;
using Archy.CLI.Terminal.Interfaces.Core.Services;
using Archy.CLI.Terminal.Interfaces.Resources.Elements;
using Archy.CLI.Terminal.Resources.Elements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Core.Services.Adaptors;

public class HorizontalSlicerAdaptor : ISlicer
{
    private readonly List<View> _views;
    public HorizontalSlicerAdaptor(){
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
                X = 0,
                Y = i == 0 ? 0 : Pos.Bottom(_views[i-1]),
                Height = Dim.Percent(perViewPercent),
                Width = Dim.Fill()
            };

            IElement frame = new Frame(config: config, parentView: toBeSlicedView);
            
            _views.Add(frame.GetView());
        }    

        return _views;
    }
}
