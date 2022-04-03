using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.VendorType.Commonds.Delete;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.VendorType.Commonds.Delete.DeletVendorTypeCommond;

namespace BuyMe.UnitTests.VendorTypeTest.Commonds;

public class DeletVentoryTypeCommondTest : CommandTestBase
{
    private readonly DeletVendorTypeCommondHandler _sut;

    public DeletVentoryTypeCommondTest()
    {
        _sut = new DeletVendorTypeCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task DeleteVendorType_ValidId_Unit()
    {
        var validId = 1;
        var commond = new DeletVendorTypeCommond {VendorTypeId = validId};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.VendorTypes.FindAsync(validId);
        entity.Should().BeNull();
    }

    [Fact]
    public async Task DeleteVendor_NotValidId_ThrowNotFoundException()
    {
        var inValidId = 54;
        var commond = new DeletVendorTypeCommond {VendorTypeId = inValidId};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }
}