using System;
using Archy.CLI.UI.Interfaces.Services.Engines;
using Archy.CLI.UI.Models.Contexts;
using Spectre.Console;

namespace Archy.CLI.UI.Services.Engines;

public class LayoutEngine : ILayoutEngine
{
    private Layout _layout;
    private bool _isRendered;
    private long _version;

    public LayoutEngine(Layout? layout = null){
        _isRendered = false;
        _version = 0;

        _layout = layout ?? Builder();
    }
    private Layout Builder(){
        Layout layout = new Layout("root").SplitColumns(
            new Layout("left").Ratio(3).SplitRows(
                new Layout("header").Ratio(2),
                new Layout("info").Ratio(1),
                new Layout("content").Ratio(5)
            ), 
            new Layout("right").Ratio(1));
        
        return layout;
    }

    private void IncrementVersion(bool reset = false){
        _version = reset ? 0 : _version + 1;
        _isRendered = false;
    }

    public void Add(string layoutName, LayoutItemContext context)
    {
        Layout selectedLayout = SplitAndGet(layoutName);

        selectedLayout.Update(context.Renderable);

        IncrementVersion();
    }

    private Layout SplitAndGet(string layoutName){
        string[] splitted = layoutName.Split(":");
        int layoutCount = splitted.Length;
        Layout selectedLayout;

        if(layoutCount > 7){
            throw new ArgumentException("Layout depth greater than 7 is not supported");
        }

        switch(layoutCount){
            case 1:
            selectedLayout = _layout[splitted[0]];
            break;
            case 2:
            selectedLayout = _layout[splitted[0]][splitted[1]];
            break;
            case 3:
            selectedLayout = _layout[splitted[0]][splitted[1]][splitted[2]];
            break;
            case 4:
            selectedLayout = _layout[splitted[0]][splitted[1]][splitted[2]][splitted[3]];
            break;
            case 5:
            selectedLayout = _layout[splitted[0]][splitted[1]][splitted[2]][splitted[3]][splitted[4]];
            break;
            case 6:
            selectedLayout = _layout[splitted[0]][splitted[1]][splitted[2]][splitted[3]][splitted[4]][splitted[5]];
            break;
            case 7:
            selectedLayout = _layout[splitted[0]][splitted[1]][splitted[2]][splitted[3]][splitted[4]][splitted[5]][splitted[6]];
            break;
            default:
            selectedLayout = _layout;
            break;
        }
        return selectedLayout;
    }

    public void Remove(string layoutName, LayoutItemContext context)
    {
        IncrementVersion();
    }

    public void Init(Layout layout)
    {
        _layout = layout;
        IncrementVersion();
    }

    public void Render()
    {
        AnsiConsole.Write(_layout);
        _isRendered = true;
    }

    public void Reset()
    {
        IncrementVersion(reset: true);
    }

    public bool IsRendered() => _isRendered;
    public long Version() => _version;

    public Layout Get(string? name = null)
    {
        if(name is not null){
            return _layout[name];
        }

        return _layout;
    }
}
