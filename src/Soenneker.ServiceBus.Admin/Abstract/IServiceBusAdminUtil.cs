using System;
using System.Diagnostics.Contracts;
using System.Threading;
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
    /// Returns the configured service Bus Administration Client used by the Service Bus Admin.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested service Bus Administration Client.</returns>
    [Pure]
    ValueTask<ServiceBusAdministrationClient> Get(CancellationToken cancellationToken = default);
}
