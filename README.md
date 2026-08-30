[![](https://img.shields.io/nuget/v/Soenneker.ServiceBus.Admin.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Admin/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.admin/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.admin/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.ServiceBus.Admin.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Admin/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.admin/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.admin/actions/workflows/codeql.yml)

# Soenneker.ServiceBus.Admin

A lazily initialized, dependency-injection-friendly `ServiceBusAdministrationClient` for Azure Service Bus entity management.

## Installation

```bash
dotnet add package Soenneker.ServiceBus.Admin
```

## Configuration

Provide the Service Bus connection string at `Azure:ServiceBus:ConnectionString`:

```json
{
  "Azure": {
    "ServiceBus": {
      "ConnectionString": "Endpoint=sb://..."
    }
  }
}
```

Keep the connection string in a protected configuration provider rather than source control or client-visible configuration. Its credential must allow the administration operations your application performs.

## Registration

```csharp
using Soenneker.ServiceBus.Admin.Registrars;

services.AddServiceBusAdminUtilAsSingleton();
```

The client is created on the first `Get` call and reused until the service is disposed.

`AddServiceBusAdminUtilAsScoped()` exists, but this package's implementation currently registers the service as a singleton as well. Use `AddServiceBusAdminUtilAsSingleton()` when you want the lifetime to be unambiguous.

## Usage

Inject `IServiceBusAdminUtil`, obtain the Azure SDK client, and use its administration APIs directly:

```csharp
using Azure.Messaging.ServiceBus.Administration;
using Soenneker.ServiceBus.Admin.Abstract;

public sealed class QueueProvisioner(IServiceBusAdminUtil adminUtil)
{
    public async Task EnsureQueue(CancellationToken cancellationToken)
    {
        ServiceBusAdministrationClient admin =
            await adminUtil.Get(cancellationToken);

        if (!(await admin.QueueExistsAsync("orders", cancellationToken)).Value)
        {
            await admin.CreateQueueAsync(
                new CreateQueueOptions("orders")
                {
                    MaxDeliveryCount = 10
                },
                cancellationToken);
        }
    }
}
```

The utility does not create queues, topics, subscriptions, or rules automatically. It only owns and reuses the configured administration client.

The Azure SDK client is safe to reuse. Do not dispose the object returned by `Get`; its lifetime belongs to `IServiceBusAdminUtil` and the DI container.
