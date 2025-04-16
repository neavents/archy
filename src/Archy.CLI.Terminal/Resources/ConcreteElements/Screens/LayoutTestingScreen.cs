using System;
using Archy.CLI.Terminal.Core.Services;
using Archy.CLI.Terminal.Core.Services.Adaptors;
using Archy.CLI.Terminal.Interfaces.Core.Services;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;
using Archy.CLI.Terminal.Interfaces.Resources.Elements;
using Archy.CLI.Terminal.Interfaces.Resources.Profiles;
using Archy.CLI.Terminal.Resources.Elements;
using Archy.CLI.Terminal.Resources.Profiles.Frames;
using Archy.Domain.Settings;
using Microsoft.Extensions.Options;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.ConcreteElements.Screens;

public class LayoutTestingScreen : IScreen
{
    public int Priority { get; init; }
    private FrameView _left;
    private FrameView _right;
    private readonly IViewSlicerService _viewSlicer;
    private readonly FrameView _leftFrame;

    private readonly IFrameProfile _leftProfile;
    private readonly IFrameProfile _rightProfile;

    private readonly ListView _travelList;
    private readonly ListView _selectedsList;
    private readonly TreeView _treeView;

    public LayoutTestingScreen(IOptions<VersionOptions> versionOptions, int? priority = null)
    {
        Priority = priority ?? 0;

        _viewSlicer = new ViewSlicerService();

        ISlicer verticalSlicer = new VerticalSlicerAdaptor();
        _viewSlicer.Mount(verticalSlicer).SetCount(2);


        _leftProfile = new LeftFrameProfile(versionOptions);
        _rightProfile = new RightFrameProfile();


        _travelList = new ListView();
        //TODO create a frameview service that get number as input and create evenly positionated and widthed frameview (eg. input 3, width Dim.Percentage(33) and X is previous one's finish);

    }

    public async ValueTask<Toplevel> Init(Toplevel toplevel)
    {

        return toplevel;
    }

    public async ValueTask<Toplevel> Render(Toplevel toplevel)
    {
        var views = _viewSlicer.Slice(toplevel);

        _leftProfile.Configure(views[0]);
        _rightProfile.Configure(views[1]);

        //_left.RenderIn(toplevel);
        //_right.RenderIn(toplevel);
        return toplevel;
    }
}
