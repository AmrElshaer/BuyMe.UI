using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.InvoiceType.Commonds.DeletInvoiceType;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.InvoiceType.Commonds.DeletInvoiceType.DeleteInvoiceTypeCommond;

namespace BuyMe.UnitTests.InvocieTypes.Commonds.DeleteInvTypeCommond;

public class DeleteInvoiceTypeCommondTest : CommandTestBase
{
    private readonly DeleteInvocieTypeCommondHandler _sut;

    public DeleteInvoiceTypeCommondTest()
    {
        _sut = new DeleteInvocieTypeCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task DeleteInvice_ValidId_Unit()
    {
        var validId = 1;
        var commond = new DeleteInvoiceTypeCommond {InvoiceTypeId = validId};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.InvoiceTypes.FindAsync(validId);
        entity.Should().BeNull();
    }

    [Fact]
    public async Task DeleteInvice_NotValidId_ThrowNotFoundException()
    {
        var validId = 54;
        var commond = new DeleteInvoiceTypeCommond {InvoiceTypeId = validId};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }
}