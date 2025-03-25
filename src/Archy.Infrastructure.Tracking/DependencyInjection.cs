using System;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.Infrastructure.Tracking;

public static class DependencyInjection
{
    public static IServiceCollection AddTracking(this IServiceCollection services){
        return services;
    }
}
