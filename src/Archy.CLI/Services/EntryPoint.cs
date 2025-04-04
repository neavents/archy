using System;
using System.Threading.Tasks;
using Archy.Application.Contracts.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.CLI.Services;

public class EntryPoint
{
    private readonly IServiceProvider _services;
    public EntryPoint(IServiceProvider services){
        _services = services;
    }

    public async Task Run(){
        var screenManager = _services.GetRequiredService<IScreenManager>();
        await screenManager.Render();
    }
}
