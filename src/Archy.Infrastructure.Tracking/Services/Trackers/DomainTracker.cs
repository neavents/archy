using System;
using Archy.Application.Contracts.Core.IO;
using Archy.Domain.Settings;
using Archy.Infrastructure.Tracking.Interfaces;
using Archy.Infrastructure.Tracking.Models;
using Microsoft.Extensions.Options;
using SharedKernel.Infrastructure.Core.Models.Globbing;

namespace Archy.Infrastructure.Tracking.Services.Trackers;

public class DomainTracker : IDependencyTracker<TrackedDomain>
{
    private readonly IFinder _finder;
    private readonly DomainOptions _domainOptions;
    private readonly ConfigurationOptions _configurationOptions;

    public DomainTracker (IFinder finder, IOptions<DomainOptions> domainOptions, IOptions<ConfigurationOptions> configurationOptions){
        _finder = finder;
        _domainOptions = domainOptions.Value;
        _configurationOptions = configurationOptions.Value;
    }
    public ValueTask<List<TrackedDomain>> Track()
    {
        
        //Open the configurations directory
        //each subdirectory is domain

        IEnumerable<HierarchicalGlobResult> results = _finder.FindAndMatchAsync(_configurationOptions.Path, _domainOptions.Pattern, true);

    }
}
