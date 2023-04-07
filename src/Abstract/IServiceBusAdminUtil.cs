using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;

namespace Soenneker.ServiceBus.Admin.Abstract;

/// <summary>
/// A utility library for Azure Service Bus Administration client accessibility <para/>
/// Singleton IoC
/// </summary>
public interface IServiceBusAdminUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Lets try to pass all service bus traffic over this one client
    /// </summary>
    [Pure]
    ValueTask<ServiceBusAdministrationClient> GetClient();
}