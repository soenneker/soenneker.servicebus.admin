using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ServiceBus.Admin.Abstract;

namespace Soenneker.ServiceBus.Admin.Registrars;

/// <summary>
/// A utility library for Azure Service Bus Administration client accessibility
/// </summary>
public static class ServiceBusAdminUtilRegistrar
{
    public static void AddServiceBusAdminUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusAdminUtil, ServiceBusAdminUtil>();
    }

    public static void AddServiceBusAdminUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusAdminUtil, ServiceBusAdminUtil>();
    }
}