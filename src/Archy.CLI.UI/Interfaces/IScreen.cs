using System;

namespace Archy.CLI.UI.Interfaces;

public interface IScreen
{
    public ValueTask Render();
}
