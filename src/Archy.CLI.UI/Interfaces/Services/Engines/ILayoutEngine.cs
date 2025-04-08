using System;
using Archy.CLI.UI.Models.Contexts;
using Spectre.Console;

namespace Archy.CLI.UI.Interfaces.Services.Engines;

public interface ILayoutEngine
{
    public void Render();
    public void Init(Layout layout);
    public void Add(string layoutName, LayoutItemContext context);
    public void Remove(string layoutName, LayoutItemContext context);
    public Layout Get(string? name = null);
    public void Reset();
    public long Version();
    public bool IsRendered();
}
