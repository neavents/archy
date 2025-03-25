using System;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.Infrastructure.Selecting;

public static class DependencyInjection
{
    public static IServiceCollection AddSelecting(this IServiceCollection services)
    {
        return services;
    }
}
