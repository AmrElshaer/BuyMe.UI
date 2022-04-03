using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Invoice.Commonds.DeleteInvoice;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.Invoice.Commonds.DeleteInvoice.DeleteInvoiceCommond;

namespace BuyMe.UnitTests.InvoiceTest.Commonds.DeleteInvoice;

public class DeleteInvoiceCommondTest : CommandTestBase
{
    private readonly DeleteInvoiceCommondHandler _sut;

    public DeleteInvoiceCommondTest()
    {
        _sut = new DeleteInvoiceCommondHandler(buyMeDbContext);
    }

    [Fact]
    public async Task DeleteInvice_ValidId_Unit()
    {
        var validId = 1;
        var commond = new DeleteInvoiceCommond {InvoiceId = validId};
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.Invoices.FindAsync(validId);
        entity.Should().BeNull();
    }

    [Fact]
    public async Task DeleteInvice_NotValidId_ThrowNotFoundException()
    {
        var validId = 54;
        var commond = new DeleteInvoiceCommond {InvoiceId = validId};
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }
}