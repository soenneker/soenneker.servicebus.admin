using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;

namespace Soenneker.ServiceBus.Admin.Abstract;

/// <summary>
/// Provides lazy access to a shared Azure Service Bus administration client configured from <c>Azure:ServiceBus:ConnectionString</c>.
/// </summary>
public interface IServiceBusAdminUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the lazily initialized administration client. The returned client is owned by this service and should not be disposed by the caller.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested service Bus Administration Client.</returns>
    [Pure]
    ValueTask<ServiceBusAdministrationClient> Get(CancellationToken cancellationToken = default);
}
