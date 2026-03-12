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
    private readonly ILogger<ServiceBusAdminUtil> _logger;
    private readonly string _connectionString;

    private readonly AsyncSingleton<ServiceBusAdministrationClient> _client;

    public ServiceBusAdminUtil(IConfiguration config, ILogger<ServiceBusAdminUtil> logger)
    {
        _logger = logger;
        _connectionString = config.GetValueStrict<string>("Azure:ServiceBus:ConnectionString");

        // No closure: method group
        _client = new AsyncSingleton<ServiceBusAdministrationClient>(CreateClient);
    }

    private ValueTask<ServiceBusAdministrationClient> CreateClient(CancellationToken token)
    {
        _logger.LogDebug("Initializing ServiceBus Administration Client...");
        return ValueTask.FromResult(new ServiceBusAdministrationClient(_connectionString));
    }

    public ValueTask<ServiceBusAdministrationClient> Get(CancellationToken cancellationToken = default) =>
        _client.Get(cancellationToken);

    public void Dispose() => _client.Dispose();

    public ValueTask DisposeAsync() => _client.DisposeAsync();
}