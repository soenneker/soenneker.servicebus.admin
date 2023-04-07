using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Configuration;
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
            var connectionString = config.GetValue<string>("Azure:ServiceBus:ConnectionString");

            if (connectionString == null)
                throw new Exception("Azure:ServiceBus:ConnectionString is required");

            var client = new ServiceBusAdministrationClient(connectionString);

            return client;
        });
    }

    public ValueTask<ServiceBusAdministrationClient> GetClient()
    {
        return _client.Get();
    }
}