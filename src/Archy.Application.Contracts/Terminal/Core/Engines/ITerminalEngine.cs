using System;

namespace Archy.Application.Contracts.Terminal.Core.Engines;

public interface ITerminalEngine
{
    public Task Start();
    public Task Stop();
}
