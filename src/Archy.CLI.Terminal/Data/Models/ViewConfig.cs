using System;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Data.Models;

public class ViewConfig
{   
    public required Pos X {get; set;}
    public required Pos Y {get; set;}

    public required Dim Width {get; set;}
    public required Dim Height {get; set;} 
}
