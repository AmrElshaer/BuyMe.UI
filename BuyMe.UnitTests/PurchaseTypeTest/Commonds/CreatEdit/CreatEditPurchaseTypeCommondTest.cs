using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.PurchaseType.Commonds.CreatEdit;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.PurchaseType.Commonds.CreatEdit.CreatEditPurchaseTypeCommond;

namespace BuyMe.UnitTests.PurchaseTypeTest.Commonds.CreatEdit;

public class CreatEditPurchaseTypeCommondTest : CommandTestBase
{
    private readonly CreatEditPurchaseTypeCommondHandler _sut;

    public CreatEditPurchaseTypeCommondTest()
    {
        _sut = new CreatEditPurchaseTypeCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task Handle_AddPurchaseType_Return_Id()
    {
        // Arrange
        var commond = new CreatEditPurchaseTypeCommond {Name = "PurchType", Description = "PurchDes"};
        // Act
        commond.Id = await _sut.Handle(commond, CancellationToken.None);
        // Assert
        var PurchaseType = await buyMeDbContext.PurchaseTypes.FindAsync(commond.Id);
        Assert.NotNull(PurchaseType);
        PurchaseType.Name.Should().Be(commond.Name);
        PurchaseType.Description.Should().Be(commond.Description);
        PurchaseType.Id.Should().Be(commond.Id);
    }

    [Fact]
    public async Task Handle_UpdatePurchaseType_InValidId_ThrowNotFoundException()
    {
        var invalidId = 20;
        var commond = new CreatEditPurchaseTypeCommond {Id = invalidId, Name = "PurchaseType"};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_UpdatePurchaseType_ValidId_PurchaseType()
    {
        var validId = 1;
        var commond = new CreatEditPurchaseTypeCommond {Id = validId, Name = "PurchoType", Description = "PurchDes"};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.PurchaseTypes.FindAsync(validId);
        entity.Name.Should().Be(commond.Name);
        entity.Description.Should().Be(commond.Description);
        entity.Id.Should().Be(commond.Id);
    }
}