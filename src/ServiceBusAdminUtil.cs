using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Configuration;
using Soenneker.Extensions.Configuration;
using Soenneker.ServiceBus.Admin.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ServiceBus.Admin;

///<inheritdoc cref="IServiceBusAdminUtil"/>
public class ServiceBusAdminUtil : IServiceBusAdminUtil
{
    private readonly AsyncSingleton<ServiceBusAdministrationClient> _client;

    public ServiceBusAdminUtil(IConfiguration config)
    {
        _client = new AsyncSingleton<ServiceBusAdministrationClient>(() =>
        {
            var connectionString = config.GetValueStrict<string>("Azure:ServiceBus:ConnectionString");

            var client = new ServiceBusAdministrationClient(connectionString);

            return client;
        });
    }

    public ValueTask<ServiceBusAdministrationClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return _client.DisposeAsync();
    }
}