using System;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.Infrastructure.Execution;

public static class DependencyInjection
{
    public static IServiceCollection AddExecution(this IServiceCollection services){
        return services;
    }
}
