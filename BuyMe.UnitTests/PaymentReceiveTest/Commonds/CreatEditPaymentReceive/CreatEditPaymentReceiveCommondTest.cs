using System;
using System.Threading;
using System.Threading.Tasks;
using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.PaymentReceive.Commonds.CreatEditPaymentReceive;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Moq;
using Xunit;
using static BuyMe.Application.PaymentReceive.Commonds.CreatEditPaymentReceive.CreatEditPaymentReceiveCommond;

namespace BuyMe.UnitTests.PaymentReceiveTest.Commonds.CreatEditPaymentReceive;

public class CreatEditPaymentReceiveCommondTest : CommandTestBase
{
    private readonly CreatEditPaymentReceiveCommondHandler _sut;
    private readonly INumberSequencyService numberSequencyService;

    public CreatEditPaymentReceiveCommondTest()
    {
        var mock = new Mock<INumberSequencyService>();
        mock.Setup(a => a.GetCurrentNumberSequence(It.IsAny<string>()))
            .Returns(Task.FromResult("00001#PAYRCV"));
        numberSequencyService = mock.Object;
        _sut = new CreatEditPaymentReceiveCommondHandler(buyMeDbContext, numberSequencyService);
    }

    [Fact]
    public async Task AddPayReceive_ValidData_PayReceiveId()
    {
        var commond = await GetCommond();
        commond.InvoiceId = await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.PaymentReceives.FindAsync(commond.InvoiceId);
        Assert.NotNull(entity);
    }

    [Fact]
    public async Task UpdatePayReceive_InValidId_ThrowNotFoundException()
    {
        var inValidId = 30;
        var commond = await GetCommond(inValidId);
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
    }

    [Fact]
    public async Task UpdatePayReceive_ValidId_PayReceiveId()
    {
        var validId = 1;
        var commond = await GetCommond(validId);
        commond.PaymentTypeId = 2;
        await _sut.Handle(commond, CancellationToken.None);
        var entity = await buyMeDbContext.PaymentReceives.FindAsync(validId);
        entity.PaymentTypeId.Should().Be(2);
    }

    private async Task<CreatEditPaymentReceiveCommond> GetCommond(int? id = null)
    {
        return new CreatEditPaymentReceiveCommond
        {
            PaymentReceiveId = id,
            PaymentDate = DateTime.Now,
            PaymentReceiveName = await numberSequencyService.GetCurrentNumberSequence("PAYRCV"),
            PaymentTypeId = 1,
            InvoiceId = 1, IsFullPayment = false
        };
    }
}