using System;
using System.Text;
using Archy.CLI.UI.Interfaces.Services;
using Spectre.Console;

namespace Archy.CLI.UI.Services;

public class BreadcrumbService : IBreadcrumbService
{
    private List<string> strings = [];
    private StringBuilder stringBuilder = new();

    private const string MARK_COLOR = "blue";
    private string Mark(string innerText) => $"[{MARK_COLOR}]{innerText}[/]";

    private void EnsureLastElementMarked(){
        if(strings.Count >= 2)
            strings[^2].RemoveMarkup();
        strings[^1] = Mark(strings[^1]);
    }

    public void Add(string pathName)
    {
        strings.Add(pathName);
        EnsureLastElementMarked();
    }

    public void RemoveLast()
    {
        strings.RemoveAt(strings.Count - 1);
        EnsureLastElementMarked();
    }

    public string RenderBreadcrumb()
    {
        foreach(string i in strings){
            stringBuilder.Append(i);
        }

        string breadcrumb = stringBuilder.ToString();
        stringBuilder.Clear();

        return breadcrumb;
    }
}
