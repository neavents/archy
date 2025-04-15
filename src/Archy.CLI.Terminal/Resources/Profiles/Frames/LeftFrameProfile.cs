using System;
using Archy.CLI.Terminal.Interfaces.Resources.HyperElements;
using Archy.CLI.Terminal.Interfaces.Resources.Profiles;
using Archy.CLI.Terminal.Resources.HyperElements.Frames;
using Archy.Domain.Settings;
using Microsoft.Extensions.Options;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.Profiles.Frames;

public class LeftFrameProfile : IFrameProfile
{   
    private readonly IHyperElement _infoFrame;
    private readonly IHyperElement _searchFrame;

    private readonly IEnumerable<IHyperElement> _hyperElements;
    public LeftFrameProfile(IOptions<VersionOptions> versionOptions){
        _infoFrame = new InfoFrame(versionOptions);
        _searchFrame = new SearchFrame();

        _hyperElements = [_infoFrame, _searchFrame];
    }
    public void Configure(View view)
    {
        foreach(IHyperElement element in _hyperElements){
            element.RenderIn(view);
        }
    }
}
