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
    /// Registers Service Bus Admin Util with a singleton lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddServiceBusAdminUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusAdminUtil, ServiceBusAdminUtil>();

        return services;
    }

    /// <summary>
    /// Registers Service Bus Admin Util with a scoped lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddServiceBusAdminUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusAdminUtil, ServiceBusAdminUtil>();

        return services;
    }
}
