using System;
using Archy.Application.Contracts.IO.Search.UseCases;
using Archy.Application.Contracts.Generic;
using Archy.Domain.Settings;
using Archy.Infrastructure.Tracking.Interfaces;
using Archy.Infrastructure.Tracking.Models;
using Microsoft.Extensions.Options;
using SharedKernel.Infrastructure.IO.Models.Globbing;

namespace Archy.Infrastructure.Tracking.Services.Trackers;

public class DomainTracker : IDependencyTracker<TrackedDomain>
{
    private readonly IFinder _finder;
    private readonly DomainOptions _domainOptions;
    private readonly ConfigurationOptions _configurationOptions;
    private readonly IConvert<IEnumerable<HierarchicalGlobResult>, IEnumerable<TrackedDomain>> _convert;

    public DomainTracker (IFinder finder, IOptions<DomainOptions> domainOptions, IOptions<ConfigurationOptions> configurationOptions, IConvert<IEnumerable<HierarchicalGlobResult>, IEnumerable<TrackedDomain>> convert){
        _finder = finder;
        _domainOptions = domainOptions.Value;
        _configurationOptions = configurationOptions.Value;
        _convert = convert;
    }
    public async ValueTask<IEnumerable<TrackedDomain>> Track()
    {
        IEnumerable<HierarchicalGlobResult> results = _finder.FindAndMatchAsync(_configurationOptions.Path, _domainOptions.Pattern, true);
        return _convert.From(results);
    }
}
