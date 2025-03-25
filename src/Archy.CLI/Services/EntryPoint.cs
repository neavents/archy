using System;

namespace Archy.CLI.Services;

public class EntryPoint
{
    private readonly IServiceProvider _services;
    public EntryPoint(IServiceProvider services){
        _services = services;
    }

    public void Run(){
        
    }
}
