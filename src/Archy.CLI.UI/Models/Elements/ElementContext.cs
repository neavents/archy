using System;

namespace Archy.CLI.UI.Models.Elements;

public class ElementContext<TKey>
{
    public required TKey Value;
    public string Header = string.Empty;
    public string Description = string.Empty;
    public string[]? StringExtras;
    public int? IntegerValue;
    public int[]? IntegerExtras;
}
