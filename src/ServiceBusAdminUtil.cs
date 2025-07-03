using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.ServiceBus.Admin.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ServiceBus.Admin;

///<inheritdoc cref="IServiceBusAdminUtil"/>
public sealed class ServiceBusAdminUtil : IServiceBusAdminUtil
{
    private readonly AsyncSingleton<ServiceBusAdministrationClient> _client;

    public ServiceBusAdminUtil(IConfiguration config, ILogger<ServiceBusAdminUtil> logger)
    {
        _client = new AsyncSingleton<ServiceBusAdministrationClient>(() =>
        {
            var connectionString = config.GetValueStrict<string>("Azure:ServiceBus:ConnectionString");

            logger.LogDebug("Initializing ServiceBus Administration Client...");

            return new ServiceBusAdministrationClient(connectionString);
        });
    }

    public ValueTask<ServiceBusAdministrationClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}