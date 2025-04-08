using System;

namespace Archy.Application.Contracts.Terminal.Core.Engines;

public interface IScreenEngine
{
    public ValueTask Render();
}
