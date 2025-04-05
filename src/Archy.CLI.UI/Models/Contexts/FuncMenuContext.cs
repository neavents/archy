using System;

namespace Archy.CLI.UI.Models.Contexts;

public class FuncMenuContext<T>
{
    public FuncMenuContext<T>? Parent;
    public required T Value;
    public List<FuncMenuContext<T>>? Childs;
}
