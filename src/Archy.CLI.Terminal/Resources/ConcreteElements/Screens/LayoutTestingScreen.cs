using System;
using Archy.CLI.Terminal.Interfaces.Resources.ConcreteElements;
using Archy.CLI.Terminal.Interfaces.Resources.Elements;
using Archy.CLI.Terminal.Interfaces.Resources.Profiles;
using Archy.CLI.Terminal.Resources.Elements;
using Archy.CLI.Terminal.Resources.Profiles.Frames;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.ConcreteElements.Screens;

public class LayoutTestingScreen : IScreen
{
    public int Priority { get; init; }
    private readonly IElement _left;
    private readonly IElement _right;
    private readonly FrameView _leftFrame;

    private readonly IFrameProfile _leftProfile;
    private readonly IFrameProfile _rightProfile;

    private readonly ListView _travelList;
    private readonly ListView _selectedsList;
    private readonly TreeView _treeView;

    public LayoutTestingScreen(int? priority = null){
        Priority = priority ?? 0;

        _left = new Frame();
        _right = new Frame();

        _leftProfile = new LeftFrameProfile();
        _rightProfile = new RightFrameProfile();

        _leftProfile.Configure(_left.GetView());
        _rightProfile.Configure(_right.GetView());

        _travelList = new ListView();
        //TODO create a frameview service that get number as input and create evenly positionated and widthed frameview (eg. input 3, width Dim.Percentage(33) and X is previous one's finish);
    }

    public void Init(){

    }

    public async ValueTask<Toplevel> Render(Toplevel toplevel)
    {
        _left.RenderIn(toplevel);
        //_right.RenderIn(toplevel);
        return toplevel;
    }
}
