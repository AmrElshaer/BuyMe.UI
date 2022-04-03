using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Vendor.Commonds.Delete;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.Vendor.Commonds.Delete.DeletVendorCommond;

namespace BuyMe.UnitTests.VendorTest.Commonds;

public class DeletVentoryCommondTest : CommandTestBase
{
    private readonly DeletVendorCommondHandler _sut;

    public DeletVentoryCommondTest()
    {
        _sut = new DeletVendorCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task DeleteVendor_ValidId_Unit()
    {
        var validId = 1;
        var commond = new DeletVendorCommond {VendorId = validId};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.Vendors.FindAsync(validId);
        entity.Should().BeNull();
    }

    [Fact]
    public async Task DeleteVendor_NotValidId_ThrowNotFoundException()
    {
        var inValidId = 54;
        var commond = new DeletVendorCommond {VendorId = inValidId};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }
}