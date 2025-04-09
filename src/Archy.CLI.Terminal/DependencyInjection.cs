using System;
using Archy.Application.Contracts.Terminal.Core.Engines;
using Archy.CLI.Terminal.Core.Engines;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.CLI.Terminal;

public static class DependencyInjection
{
    public static IServiceCollection AddTerminal(this IServiceCollection services){
        services.AddSingleton<ITerminalEngine, TerminalEngine>();
        services.AddSingleton<IScreenEngine, ScreenEngine>();
        return services;
    }
}
