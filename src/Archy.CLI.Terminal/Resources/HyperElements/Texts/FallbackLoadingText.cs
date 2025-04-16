using System;
using Archy.CLI.Terminal.Interfaces.Resources.HyperElements;
using Figgle;
using term = Terminal.Gui;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Resources.HyperElements.Texts;

public class FallbackLoadingText : IAnimatedFallback
{
    private readonly Label _label;
    private bool _running;
    private readonly IEnumerable<FiggleFont> _figgleFonts;
    private const int DELAY = 200;
    private string _innerText = string.Empty;
    
    public FallbackLoadingText() {
        _label = new Label() {
            TextAlignment = TextAlignment.Centered,
            VerticalTextAlignment = VerticalTextAlignment.Middle,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        _figgleFonts = [FiggleFonts.Acrobatic, FiggleFonts.Alligator, FiggleFonts.Alpha, FiggleFonts.Alphabet, FiggleFonts.AmcNeko, FiggleFonts.AsciiNewroman, FiggleFonts.Avatar, FiggleFonts.B1FF, FiggleFonts.Banner,FiggleFonts.Banner3D, FiggleFonts.BarbWire, FiggleFonts.Bell, FiggleFonts.Benjamin, FiggleFonts.Big, FiggleFonts.BigChief, FiggleFonts.Binary, FiggleFonts.Bright, FiggleFonts.Broadway, FiggleFonts.Bubble, FiggleFonts.Bulbhead, FiggleFonts.Caligraphy, FiggleFonts.Cards, FiggleFonts.CatWalk, FiggleFonts.Chiseled, FiggleFonts.Chunky, FiggleFonts.Coinstak, FiggleFonts.Cola];
    }

    public void Add(View view)
    {
        _label.Add(view);
    }

    public async Task Animate()
    {
        await Task.Run(async () =>
        {
            
            int innerTextLength = _innerText.Length;
            
            while (_running){
                foreach(FiggleFont fFont in _figgleFonts){
                    if(!_running) break;
            
                        for(int i = 0; i < innerTextLength; i++){
                            term.Application.MainLoop.Invoke(() => {
                                _label.Text = fFont.Render(_innerText[i].ToString());
                            });

                            await Task.Delay(DELAY);
                        }
                    
                }
        }});
        
    }

    public void RenderIn(View view)
    {
        view.Add(_label);
    }

    public void Start(string text)
    {
        if(_running){
            return;
        }
        _running = true;
        _innerText = text;

        //_label.Text = FiggleFonts.Alpha.Render(text);

    }

    public void Stop()
    {
        _running = false;
    }

    public void Reset(){
        _running = false;
        _innerText = string.Empty;
    }
}
