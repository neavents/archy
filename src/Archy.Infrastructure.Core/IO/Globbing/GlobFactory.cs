using System;
using Archy.Application.Contracts.Core.IO;
using DotNet.Globbing;
using SharedKernel.Infrastructure.Core.Models;

namespace Archy.Infrastructure.Core.IO.Globbing;

public class GlobFactory : IGlobFactory
{
    public ValueTask<Glob> Create(GlobOptions? opts)
    {
        IGlobBuilder g = new GlobBuilder();
        //https://github.com/dazinator/DotNet.Glob
        var glob = new GlobBuilder()
                .PathSeparator(PathSeparato)
                .Literal("foo")
                .AnyCharacter()
                .PathSeparator(PathSeparatorKind.BackwardSlash)
                .Wildcard()
                .OneOf('a', 'b', 'c')
                .NumberNotInRange('1', '3')
                .Literal(".txt")
                .ToGlob();

        // Firstly, parse the string and add it to the glob registry for further use.
        
    }

    public ValueTask<Glob> Create(GlobOptions? opts1, GlobConfig? opts2)
    {
        throw new NotImplementedException();
    }
}
