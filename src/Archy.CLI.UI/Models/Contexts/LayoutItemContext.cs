using System;
using Spectre.Console.Rendering;

namespace Archy.CLI.UI.Models.Contexts;

public class LayoutItemContext
{
    public required string Name;
    public required IRenderable Renderable;
}
