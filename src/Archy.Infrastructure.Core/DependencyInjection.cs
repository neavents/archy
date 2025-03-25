using System;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.Infrastructure.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services){
        return services;
    }
}
