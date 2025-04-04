using System;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Models.Elements;
using Spectre.Console;

namespace Archy.CLI.UI.Elements;

public class Selectables : IElement<List<string>, List<string>>
{
    private const int PAGE_SIZE = 10;
    private const string MORE_CHOICES_TEXT = "[grey](Move up and down to reveal more items)[/]";
    private const string INSTRUCTIONS_TEXT = "[grey](Press [blue]<space>[/] to toggle a item, " + 
            "[green]<enter>[/] to accept)[/]";
    public async ValueTask<List<string>> Render(ElementContext<List<string>> context)
    {
        return AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title(context.Header)
        .NotRequired() 
        .PageSize(context.IntegerValue ?? PAGE_SIZE)
        .MoreChoicesText(context.StringExtras?[0] ?? MORE_CHOICES_TEXT)
        .InstructionsText(context.StringExtras?[1] ?? INSTRUCTIONS_TEXT)
        .AddChoices(context.Value));
    }

}
