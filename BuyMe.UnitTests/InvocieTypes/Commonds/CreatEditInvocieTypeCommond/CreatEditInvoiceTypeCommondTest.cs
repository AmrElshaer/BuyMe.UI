using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.InvoiceType.Commonds.CreatEditIInvoiceType;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.InvoiceType.Commonds.CreatEditIInvoiceType.CreatEditInvoiceTypeCommond;

namespace BuyMe.UnitTests.InvocieTypes.Commonds.CreatEditInvocieTypeCommond
{
    public class CreatEditInvoiceTypeCommondTest: CommandTestBase
    {
        private readonly CreatEditInvoiceTypeCommondHandler _sut;
        public CreatEditInvoiceTypeCommondTest()
        {
            _sut = new CreatEditInvoiceTypeCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task Handle_AddInvoiceType_Return_InvoiceTypeId()
        {
            // Arrange
            var commond = new CreatEditInvoiceTypeCommond() { InvoiceTypeName = "InvoType", Description = "InvDes" };
            // Act
            commond.InvoiceTypeId = await _sut.Handle(commond, CancellationToken.None);
            // Assert
            var invoiceType = await buyMeDbContext.InvoiceTypes.FindAsync(commond.InvoiceTypeId);
            Assert.NotNull(invoiceType);
            invoiceType.InvoiceTypeName.ShouldBeEquivalentTo(commond.InvoiceTypeName);
            invoiceType.Description.ShouldBeEquivalentTo(commond.Description);
            invoiceType.InvoiceTypeId.ShouldBeEquivalentTo(commond.InvoiceTypeId);



        }
        [Fact]
        public async Task Handle_UpdateInvoiceType_InValidId_ThrowNotFoundException()
        {
            var invalidId = 20;
            var commond = new CreatEditInvoiceTypeCommond() { InvoiceTypeId = invalidId, InvoiceTypeName = "Invi55" };
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
        }
        [Fact]
        public async Task Handle_UpdateInvoiceType_ValidId_InvoiceType()
        {
            var validId = 1;
            var commond = new CreatEditInvoiceTypeCommond() { InvoiceTypeId = validId, InvoiceTypeName = "InvoType", Description = "InvDes" };
            await _sut.Handle(commond, CancellationToken.None);
            var entity =await buyMeDbContext.InvoiceTypes.FindAsync(validId);
            entity.InvoiceTypeName.ShouldBeEquivalentTo(commond.InvoiceTypeName);
            entity.Description.ShouldBeEquivalentTo(commond.Description);
            entity.InvoiceTypeId.ShouldBeEquivalentTo(commond.InvoiceTypeId);

        }
    }
}
