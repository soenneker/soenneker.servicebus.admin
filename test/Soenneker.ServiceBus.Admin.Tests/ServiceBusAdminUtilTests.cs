using Soenneker.ServiceBus.Admin.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.ServiceBus.Admin.Tests;

[Collection("Collection")]
public class ServiceBusAdminUtilTests : FixturedUnitTest
{
    private readonly IServiceBusAdminUtil _util;

    public ServiceBusAdminUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IServiceBusAdminUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
