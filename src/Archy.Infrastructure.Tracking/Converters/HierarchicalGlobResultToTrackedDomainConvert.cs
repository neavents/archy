using System;
using Archy.Application.Contracts.Generic;
using Archy.Infrastructure.Tracking.Models;
using SharedKernel.Infrastructure.IO.Models.Globbing;

namespace Archy.Infrastructure.Tracking.Converters;

public class HierarchicalGlobResultToTrackedDomainConvert : IConvert<IEnumerable<HierarchicalGlobResult>, IEnumerable<TrackedDomain>>
{
    public IEnumerable<TrackedDomain> From(IEnumerable<HierarchicalGlobResult> input)
    {
        foreach(HierarchicalGlobResult result in input){
            yield return new TrackedDomain(
                path: result.FullPath,
                name: result.MatchedWildcardSegments[0]
            );
        };
    }
}
