using System;
using Archy.CLI.Terminal.Interfaces.Resources.Elements;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Interfaces.Resources.Profiles;

public interface IFrameProfile
{
    public void Configure(View view);
}
