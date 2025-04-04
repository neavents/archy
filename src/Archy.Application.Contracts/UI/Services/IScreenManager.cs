using System;

namespace Archy.Application.Contracts.UI.Services;

public interface IScreenManager
{
    public ValueTask Render();
}
