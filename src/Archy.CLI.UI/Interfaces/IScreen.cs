using System;
using Spectre.Console;

namespace Archy.CLI.UI.Interfaces;

public interface IScreen
{
    public int Priority {get; init;}
    public ValueTask Render(Layout layout);
}
