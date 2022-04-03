using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.PaymentType.Commonds.DeletCommond;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.PaymentType.Commonds.DeletCommond.DeletePaymentTypeCommond;

namespace BuyMe.UnitTests.PaymentTypeTest.Commonds.DeletCommond;

public class DeletePaymentTypeCommondTest : CommandTestBase
{
    private readonly DeletePaymentTypeCommondHandler _sut;

    public DeletePaymentTypeCommondTest()
    {
        _sut = new DeletePaymentTypeCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task DeletePaymentType_ValidId_Unit()
    {
        var validId = 1;
        var commond = new DeletePaymentTypeCommond {PaymentTypeId = validId};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.PaymentTypes.FindAsync(validId);
        entity.Should().BeNull();
    }

    [Fact]
    public async Task DeletePayment_NotValidId_ThrowNotFoundException()
    {
        var inValidId = 54;
        var commond = new DeletePaymentTypeCommond {PaymentTypeId = inValidId};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }
}