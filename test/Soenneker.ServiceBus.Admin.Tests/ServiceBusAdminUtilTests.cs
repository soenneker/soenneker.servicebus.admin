using Soenneker.ServiceBus.Admin.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.ServiceBus.Admin.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ServiceBusAdminUtilTests : HostedUnitTest
{
    private readonly IServiceBusAdminUtil _util;

    public ServiceBusAdminUtilTests(Host host) : base(host)
    {
        _util = Resolve<IServiceBusAdminUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
