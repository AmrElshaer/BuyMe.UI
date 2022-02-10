using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Invoice.Commonds.CreatEditInvoice;
using BuyMe.UnitTests.Common;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.Invoice.Commonds.CreatEditInvoice.UpSertInvoiceCommond;

namespace BuyMe.UnitTests.InvoiceTest.Commonds.UpSertInvoice
{
    public class UpSertInvoiceCommondTest : CommandTestBase
    {
        private readonly UpSertInvoiceCommondHandler _sut;
        private readonly INumberSequencyService numberSequencyService;
        public UpSertInvoiceCommondTest()
        {

            var mock = new Mock<INumberSequencyService>();
            mock.Setup(a => a.GetCurrentNumberSequence(It.IsAny<string>()))
                .Returns(Task.FromResult("00001#INV"));
            numberSequencyService = mock.Object;
            _sut = new UpSertInvoiceCommondHandler(buyMeDbContext, numberSequencyService);
        }
        [Fact]
        public async Task AddInvoice_ValidData_InvoiceId()
        {
            var commond = await GetCommond();
            commond.InvoiceId = await _sut.Handle(commond, CancellationToken.None);
            var entity = await buyMeDbContext.Invoices.FindAsync(commond.InvoiceId);
            Assert.NotNull(entity);

        }

       

        [Fact]
        public async Task UpdateInvoice_InValidId_ThrowNotFoundException()
        {
            var inValidId = 30;
            var commond = await GetCommond(inValidId);
            await Assert.ThrowsAsync< NotFoundException>(()=>  _sut.Handle(commond, CancellationToken.None));
        }
        [Fact]
        public async Task UpdateInvoice_ValidId_InvoiceId()
        {
            var validId = 1;
            var commond = await GetCommond(validId);
            commond.InvoiceTypeId = 2;
            await _sut.Handle(commond, CancellationToken.None);
            var entity = await buyMeDbContext.Invoices.FindAsync(validId);
            entity.InvoiceTypeId.ShouldBeEquivalentTo(2);


        }
        private async Task<UpSertInvoiceCommond> GetCommond(int? id=null)
        {
            return new UpSertInvoiceCommond()
            {
                InvoiceId=id,
                InvoiceDate = DateTime.Now,
                InvoiceDueDate = DateTime.Now + TimeSpan.FromDays(1),
                InvoiceName = await numberSequencyService.GetCurrentNumberSequence("INV"),
                ShipmentId = 1,
                InvoiceTypeId = 1
            };
        }
    }
}
