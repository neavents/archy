using System;
using Archy.Application.Contracts.UI.Services;
using Archy.CLI.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.CLI.UI;

public static class DependencyInjection
{
    public static IServiceCollection AddUI(this IServiceCollection services){
        services.AddSingleton<IScreenManager, ScreenManager>();
        return services;
    }
}
