using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.PaymentType.Commonds.CreatEditCommond;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.PaymentType.Commonds.CreatEditCommond.CreatEditPaymentTypeCommond;

namespace BuyMe.UnitTests.PaymentTypeTest.Commonds.CreatEditCommond;

public class CreatEditPaymentTypeCommondTest : CommandTestBase
{
    private readonly CreatEditPaymentTypeCommondHandler _sut;

    public CreatEditPaymentTypeCommondTest()
    {
        _sut = new CreatEditPaymentTypeCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task Handle_AddPaymentType_Return_PaymentTypeId()
    {
        // Arrange
        var commond = new CreatEditPaymentTypeCommond {PaymentTypeName = "PayType", Description = "PayDes"};
        // Act
        commond.PaymentTypeId = await _sut.Handle(commond, CancellationToken.None);
        // Assert
        var PaymentType = await buyMeDbContext.PaymentTypes.FindAsync(commond.PaymentTypeId);
        Assert.NotNull(PaymentType);
        PaymentType.PaymentTypeName.Should().Be(commond.PaymentTypeName);
        PaymentType.Description.Should().Be(commond.Description);
        PaymentType.PaymentTypeId.Should().Be(commond.PaymentTypeId);
    }

    [Fact]
    public async Task Handle_UpdatePaymentType_InValidId_ThrowNotFoundException()
    {
        var invalidId = 20;
        var commond = new CreatEditPaymentTypeCommond {PaymentTypeId = invalidId, PaymentTypeName = "BankTransfer"};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_UpdatePaymentType_ValidId_PaymentType()
    {
        var validId = 1;
        var commond = new CreatEditPaymentTypeCommond
            {PaymentTypeId = validId, PaymentTypeName = "PayoType", Description = "PayDes"};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.PaymentTypes.FindAsync(validId);
        entity.PaymentTypeName.Should().Be(commond.PaymentTypeName);
        entity.Description.Should().Be(commond.Description);
        entity.PaymentTypeId.Should().Be(commond.PaymentTypeId);
    }
}