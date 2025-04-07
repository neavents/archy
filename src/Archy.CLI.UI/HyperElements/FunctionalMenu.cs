using System;
using System.Text;
using Archy.CLI.UI.Constants.Menu;
using Archy.CLI.UI.Elements;
using Archy.CLI.UI.Interfaces;
using Archy.CLI.UI.Interfaces.Elements;
using Archy.CLI.UI.Interfaces.Services;
using Archy.CLI.UI.Models.Contexts;
using Archy.CLI.UI.Models.Elements;
using Archy.CLI.UI.Services;
using Spectre.Console;

namespace Archy.CLI.UI.HyperElements;

public class FunctionalMenu : IHyperElement<FuncMenuContext<string>>
{
    private Stack<FuncMenuContext<string>> _stateStack;
    private readonly IBreadcrumbService _breadcrumb;
    private readonly IElement<List<string>, string> _selectable;
    private FuncMenuContext<string>? _menuState;

    public FunctionalMenu(){
        _stateStack = [];
        _breadcrumb = new BreadcrumbService();
        _selectable = new Selectable();
        _menuState = null;
    }

    public async ValueTask Render(ElementContext<FuncMenuContext<string>> context)
    {
        _stateStack.Push(context.Value);
        _menuState = context.Value;
        _breadcrumb.Add(context.Header);
        
        while (_stateStack.Count > 0){
            if (_menuState is null){
                break;
            }

            FuncMenuContext<string> currContext = _stateStack.Peek(); 
            List<FuncMenuContext<string>>? currChilds = currContext.Childs;

            if(currChilds is null){
                break;
            }

            string selected = await _selectable.Render(new(){
                Value = currContext.Childs?.Select(c => c.Value).ToList() ?? [context.Description],
                Header = _breadcrumb.RenderBreadcrumb()
            });

            if(string.Equals(selected, MenuCommands.MenuBackSignal, StringComparison.Ordinal)){
                _stateStack.Pop();
                _breadcrumb.RemoveLast();
            } else {
                FuncMenuContext<string>? selectedContext = currContext.Childs?.FirstOrDefault(f => f.Value == selected); 
                
                if(selectedContext is null){
                    AnsiConsole.WriteException(new ArgumentNullException($"There is no inner child named {selected}"));
                    break;
                }

                _stateStack.Push(selectedContext);
                _breadcrumb.Add(selected);
            }
        }
    }
}
