using System;
using Archy.CLI.Terminal.Interfaces.Core.Services;
using Figgle;

namespace Archy.CLI.Terminal.Core.Services;

public class FigletService : IFigletService
{
    public string HeaderFiglet(string text)
    {
        return FiggleFonts.Standard.Render(text);
    }
}
