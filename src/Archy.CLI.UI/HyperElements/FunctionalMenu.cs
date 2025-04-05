using System;
using Archy.CLI.UI.Elements;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Models.Contexts;
using Archy.CLI.UI.Models.Elements;

namespace Archy.CLI.UI.HyperElements;

public class FunctionalMenu : IHyperElement<FuncMenuContext<string>>
{
    public async ValueTask Render(ElementContext<FuncMenuContext<string>> context)
    {
        IElement<List<string>, string> selectable = new Selectable();
        FuncMenuContext<string>? menuState = context.Value;

        while (true){
            if (menuState is null){
                break;
            }

            string selected = await selectable.Render(new(){
                Value = menuState?.Childs?.Select(c => c.Value).ToList() ?? [context.Description],
                Header = context.Header
            });

            menuState = menuState?.Childs?.FirstOrDefault(f => f.Value == selected);
        }
    }
}
