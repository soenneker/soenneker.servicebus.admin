[![](https://img.shields.io/nuget/v/Soenneker.ServiceBus.Admin.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Admin/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.admin/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.admin/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.ServiceBus.Admin.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Admin/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.admin/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.admin/actions/workflows/codeql.yml)

# Soenneker.ServiceBus.Admin

A utility library for Azure Service Bus Administration client accessibility Singleton IoC.

## Install

```bash
dotnet add package Soenneker.ServiceBus.Admin
```

## Quick start

```csharp
using Soenneker.ServiceBus.Admin.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddServiceBusAdminUtilAsSingleton();
```

Registers Service Bus Admin Util with a singleton lifetime.

## What you get

- `IServiceBusAdminUtil` — A utility library for Azure Service Bus Administration client accessibility Singleton IoC.
- `ServiceBusAdminUtilRegistrar` — A utility library for Azure Service Bus Administration client accessibility.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ServiceBusAdminUtilRegistrar.AddServiceBusAdminUtilAsSingleton(services)` | Registers Service Bus Admin Util with a singleton lifetime. | The same service collection, so additional registrations can be chained. |
| `ServiceBusAdminUtilRegistrar.AddServiceBusAdminUtilAsScoped(services)` | Registers Service Bus Admin Util with a scoped lifetime. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
