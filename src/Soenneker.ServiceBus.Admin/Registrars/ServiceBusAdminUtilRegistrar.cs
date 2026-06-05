using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ServiceBus.Admin.Abstract;

namespace Soenneker.ServiceBus.Admin.Registrars;

/// <summary>
/// A utility library for Azure Service Bus Administration client accessibility
/// </summary>
public static class ServiceBusAdminUtilRegistrar
{
    /// <summary>
    /// Adds service bus admin util as singleton.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddServiceBusAdminUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusAdminUtil, ServiceBusAdminUtil>();

        return services;
    }

    /// <summary>
    /// Adds service bus admin util as scoped.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddServiceBusAdminUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusAdminUtil, ServiceBusAdminUtil>();

        return services;
    }
}