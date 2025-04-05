using System;
using System.Text;
using Archy.CLI.UI.Elements;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Interfaces.Elements;
using Archy.CLI.UI.Interfaces.Services;
using Archy.CLI.UI.Models.Contexts;
using Archy.CLI.UI.Models.Elements;
using Archy.CLI.UI.Services;

namespace Archy.CLI.UI.HyperElements;

public class FunctionalMenu : IHyperElement<FuncMenuContext<string>>
{
    public async ValueTask Render(ElementContext<FuncMenuContext<string>> context)
    {
        IElement<List<string>, string> selectable = new Selectable();
        IBreadcrumbService breadcrumb = new BreadcrumbService();

        FuncMenuContext<string>? menuState = context.Value;
        breadcrumb.Add(context.Header);
        
        while (true){
            if (menuState is null){
                break;
            }

            string selected = await selectable.Render(new(){
                Value = menuState?.Childs?.Select(c => c.Value).ToList() ?? [context.Description],
                Header = breadcrumb.RenderBreadcrumb()
            });
            breadcrumb.Add(selected);

            menuState = menuState?.Childs?.FirstOrDefault(f => f.Value == selected);
        }
    }
}
