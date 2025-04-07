using System;

namespace Archy.CLI.UI.Interfaces.Services;

public interface IBreadcrumbService
{
    public void Add(string pathName);
    public void RemoveLast();
    public void Remove(string element);
    public string RenderBreadcrumb();
}
