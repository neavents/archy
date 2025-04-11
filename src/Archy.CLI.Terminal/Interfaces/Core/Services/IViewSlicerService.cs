using System;
using Archy.CLI.Terminal.Core.Services;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Interfaces.Core.Services;

public interface IViewSlicerService
{
    public List<View> Slice(View view);
    public ViewSlicerService Mount(ISlicer slicer);
    public ViewSlicerService SetCount(int count);
}
