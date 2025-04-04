using System;
using Archy.CLI.UI.Elements;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Models.Progresses;
using SharedKernel.Extensions;

namespace Archy.CLI.UI.Screens;

public class WelcomeScreen : IScreen
{
    public int Priority {get; init;}
    public WelcomeScreen(int priority = 0){
        Priority = priority
    }

    public async ValueTask Render()
    {
        string selectionName = "domain";
        List<string> domains = ["database", "messaging", "security", "auth", "blabla"];

        var element = new SearchingProgress();
        await element.Execute();

        IElement<List<string>,List<string>> element1 = new Selectables();
        await element1.Render(new(){
            Value = domains, 
            Header = $"[blue]{selectionName.CapitalizeFirst()}s[/] to be configured",
            StringExtras = [$"[grey](Move up and down to reveal more {selectionName}s)[/]",$"[grey](Press [blue]<space>[/] to toggle a {selectionName}, " + 
            "[green]<enter>[/] to accept)[/]"]
            });

        IElement<List<string>, string> element2 = new Selectable();
        await element2.Render(new(){
            Value = domains,
            Header = $"[blue]{selectionName.CapitalizeFirst()}s[/] to be configured",
            StringExtras = [$"[grey](Move up and down to reveal more {selectionName}s)[/]",$"[grey](Press [blue]<space>[/] to toggle a {selectionName}, " + 
            "[green]<enter>[/] to accept)[/]"]
        });
    }
}
