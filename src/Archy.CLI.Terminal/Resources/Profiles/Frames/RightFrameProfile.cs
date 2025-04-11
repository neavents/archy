using System;
using Archy.CLI.Terminal.Interfaces.Resources.HyperElements;
using Archy.CLI.Terminal.Interfaces.Resources.Profiles;
using Archy.CLI.Terminal.Resources.HyperElements.Frames;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.Profiles.Frames;

public class RightFrameProfile : IFrameProfile
{
    private readonly IHyperElement _languageFrame;
    private readonly IHyperElement _architectureFrame;
    private readonly IHyperElement _selectionFrame;

    private readonly IEnumerable<IHyperElement> _hyperElements;
    public RightFrameProfile(){

        _languageFrame = new LanguageFrame();
        _architectureFrame = new ArchitectureFrame();
        _selectionFrame = new SelectionFrame();

        _hyperElements = [_languageFrame, _architectureFrame, _selectionFrame];
    }

    public void Configure(View view)
    {
        foreach(IHyperElement element in _hyperElements){
            element.RenderIn(view);
        }
    }
}
