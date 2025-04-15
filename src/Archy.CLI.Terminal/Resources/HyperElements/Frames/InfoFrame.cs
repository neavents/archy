using System;
using Archy.CLI.Terminal.Core.Services;
using Archy.CLI.Terminal.Interfaces.Core.Services;
using Archy.CLI.Terminal.Interfaces.Resources.HyperElements;
using Archy.Domain.Settings;
using Microsoft.Extensions.Options;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.HyperElements.Frames;

public class InfoFrame : IHyperElement
{
    private readonly Label _label;
    private readonly Label _author;
    private readonly Label _company;
    private readonly Label _version;
    private const int LEFT_PADDING = 1;

    private readonly VersionOptions _versionOptions;
    public InfoFrame(IOptions<VersionOptions> versionOptions){
        _versionOptions = versionOptions.Value;

        IFigletService figletService = new FigletService();

        _label = new Label()
        {
            Text = figletService.HeaderFiglet("archy"),
            X = LEFT_PADDING,
            Y = 0,
            
        };

        _version = new Label(){
            Text = $"v{_versionOptions}",
            X = Pos.Right(_label) + 2,
            Y = Pos.Bottom(_label) - 2
        };

        _company = new Label(){
            Text = "from Neavents",
            X = LEFT_PADDING + 2,
            Y = Pos.Bottom(_label)
        };

        _author = new Label(){
            Text = "by Polat Efe Kaya",
            X = Pos.Right(_company) + 2,
            Y = Pos.Bottom(_label),
           
        };


    }
    public void Add(View view)
    {
        _label.Add(view);
    }

    public void RenderIn(View view)
    {
        view.Add(_label);
        view.Add(_version);
        view.Add(_company);
        view.Add(_author);
    }
}
