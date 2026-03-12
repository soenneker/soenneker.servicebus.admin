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
    [Pure]
    ValueTask<ServiceBusAdministrationClient> Get(CancellationToken cancellationToken = default);
}