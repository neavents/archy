using System;
using Archy.CLI.Terminal.Data.Models;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Data.Constants;

public static class ViewStandards
{
    public static ViewConfig StandardViewConfig = new(){
        X = 0,
        Y = 0,
        Width = Dim.Fill(),
        Height = Dim.Fill()
    };
}
