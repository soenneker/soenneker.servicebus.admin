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
    /// As Singleton
    /// </summary>
    public static void AddBlobClientUtil(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusAdminUtil, ServiceBusAdminUtil>();
    }
}