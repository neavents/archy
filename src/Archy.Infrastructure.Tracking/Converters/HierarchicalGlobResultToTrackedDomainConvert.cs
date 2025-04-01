using System;
using Archy.Application.Contracts.Generic;
using Archy.Infrastructure.Tracking.Models;
using SharedKernel.Infrastructure.Core.Models.Globbing;

namespace Archy.Infrastructure.Tracking.Converters;

public class HierarchicalGlobResultToTrackedDomainConvert : IConvert<HierarchicalGlobResult, IEnumerable<TrackedDomain>>
{
    public IEnumerable<TrackedDomain> From(HierarchicalGlobResult input)
    {
        foreach(string segment in input.MatchedWildcardSegments){
            yield return new TrackedDomain(
                path: input.RelativePath,
                name: segment
            );
        };
    }
}
