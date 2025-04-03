using System;
using Archy.Application.Contracts.Core;
using Archy.Infrastructure.Core.Models.Globbing;
using Archy.Infrastructure.Core.Registry;
using Microsoft.Extensions.DependencyInjection;

namespace Archy.Infrastructure.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services){

        services.AddSingleton<IRegistry<string, GlobWrapper>, GenericRegistry<string, GlobWrapper>>();

        return services;
    }
}
