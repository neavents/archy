using System;
using Archy.CLI.Terminal.Interfaces.Core.Services;
using Terminal.Gui;

namespace Archy.CLI.Terminal.Core.Services;

public class ViewSlicerService : IViewSlicerService
{   
    private ISlicer? _slicer;
    private int _sliceCount = 0;
    public ViewSlicerService(){
        
    }
    public ViewSlicerService(ISlicer slicer, int sliceCount){
        _slicer = slicer;
        _sliceCount = sliceCount;
    }
    public List<View> Slice(View view)
    {
        if(_slicer is null){
            throw new ArgumentNullException("Slicer can not be null. Mount a ISlicer to continue slicing");
        }

        if(_sliceCount <= 0){
            throw new ArgumentOutOfRangeException("Slice Count can not be equal or less than zero (0).");
        }
        
        return _slicer.Slice(view, _sliceCount);
    }

    public ViewSlicerService Mount(ISlicer slicer){
        _slicer = slicer;
        return this;
    }

    public ViewSlicerService SetCount(int count){
        _sliceCount = count;
        return this;
    }
}
