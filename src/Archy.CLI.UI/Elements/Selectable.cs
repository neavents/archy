using System;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Interfaces.Elements;
using Archy.CLI.UI.Models.Elements;
using Spectre.Console;

namespace Archy.CLI.UI.Elements;

public class Selectable : IElement<List<string>, string>
{
    private const int PAGE_SIZE = 10;
    private const string MORE_CHOICES_TEXT = "[grey](Move up and down to reveal more items)[/]";
    public async ValueTask<string> Render(ElementContext<List<string>> context, Layout? layout = null)
    {
        var prompt = new SelectionPrompt<string>()
            .Title(context.Header)
            .PageSize(context.IntegerValue ?? PAGE_SIZE)
            .MoreChoicesText(context.Description ?? MORE_CHOICES_TEXT)
            .EnableSearch()
            .AddChoices(context.Value);

        if(layout is not null){
            layout.Update(prompt);
        }
        return AnsiConsole.Prompt(prompt);
    }
}
