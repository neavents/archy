using System;
using Archy.CLI.UI.Interfaces;

namespace Archy.CLI.UI.Compare;

public class ScreenCompareByPriority : IComparer<IScreen>
{
    public int Compare(IScreen? x, IScreen? y)
    {
        if(x is null || y is null){
            return 0;
        }

        return x.Priority.CompareTo(y.Priority);
    }
}
