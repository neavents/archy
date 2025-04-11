using System;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Interfaces.Core.Services;

public interface ISlicer
{
    public List<View> Slice(View toBeSlicedView, int count);
}
