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
    private const string SEPERATOR_COLOR = "gray";
    private const string SEPERATOR = $"[{SEPERATOR_COLOR}]/[/]";
    private string Mark(string innerText) => $"[{MARK_COLOR}]{innerText}[/]";

    private void EnsureLastElementMarked(bool fullSearch = false){
        if(strings.Count < 1){
            return;
        }

        if(fullSearch){
            for(int i = 0; i < strings.Count; i++){
                strings[i] = strings[i].RemoveMarkup();
            }
        } else if(strings.Count >= 2) {
            strings[^2] = strings[^2].RemoveMarkup();
        } else if(strings.Count == 1){
            strings[0] = strings[0].RemoveMarkup();
        }

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

    public void Remove(string element){
        strings.Remove(element);
        EnsureLastElementMarked(true);
    }

    public string RenderBreadcrumb()
    {
        int j = 0;
        foreach(string i in strings){
            if(j > 0)
                stringBuilder.Append($" {SEPERATOR} ");
            stringBuilder.Append(i);
            
            j++;
        }

        string breadcrumb = stringBuilder.ToString();
        stringBuilder.Clear();

        return breadcrumb;
    }
}
