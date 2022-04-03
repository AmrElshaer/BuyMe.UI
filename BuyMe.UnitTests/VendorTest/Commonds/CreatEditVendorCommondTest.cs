using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Vendor.Commonds.CreatEdit;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.Vendor.Commonds.CreatEdit.CreatEditVendorCommond;

namespace BuyMe.UnitTests.VendorTest.Commonds;

public class CreatEditVendorCommondTest : CommandTestBase
{
    private readonly CreatEditVendorCommondHandler _sut;

    public CreatEditVendorCommondTest()
    {
        _sut = new CreatEditVendorCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task Handle_AddVendor_Return_Id()
    {
        // Arrange
        var commond = new CreatEditVendorCommond {Name = "Vend", Address = "Address"};
        // Act
        commond.Id = await _sut.Handle(commond, CancellationToken.None);
        // Assert
        var Vendor = await buyMeDbContext.Vendors.FindAsync(commond.Id);
        Assert.NotNull(Vendor);
        Vendor.Name.Should().Be(commond.Name);
        Vendor.Address.Should().Be(commond.Address);
        Vendor.Id.Should().Be(commond.Id);
    }

    [Fact]
    public async Task Handle_UpdateVendor_InValidId_ThrowNotFoundException()
    {
        var invalidId = 20;
        var commond = new CreatEditVendorCommond {Id = invalidId, Name = "Vendor"};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_UpdateVendor_ValidId_Vendor()
    {
        var validId = 1;
        var commond = new CreatEditVendorCommond {Id = validId, Name = "Vendo", Address = "Address"};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.Vendors.FindAsync(validId);
        entity.Name.Should().Be(commond.Name);
        entity.Address.Should().Be(commond.Address);
        entity.Id.Should().Be(commond.Id);
    }
}