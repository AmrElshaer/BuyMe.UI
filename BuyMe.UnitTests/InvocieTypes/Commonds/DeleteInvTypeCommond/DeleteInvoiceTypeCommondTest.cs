using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.InvoiceType.Commonds.DeletInvoiceType;
using BuyMe.UnitTests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.InvoiceType.Commonds.DeletInvoiceType.DeleteInvoiceTypeCommond;

namespace BuyMe.UnitTests.InvocieTypes.Commonds.DeleteInvTypeCommond
{
    public class DeleteInvoiceTypeCommondTest:CommandTestBase
    {
        private readonly DeleteInvocieTypeCommondHandler _sut;
        public DeleteInvoiceTypeCommondTest()
        {
            this._sut = new DeleteInvocieTypeCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task DeleteInvice_ValidId_Unit()
        {
            var validId = 1;
            var commond = new DeleteInvoiceTypeCommond { InvoiceTypeId = validId };
            await _sut.Handle(commond, CancellationToken.None);
            var entity =await buyMeDbContext.InvoiceTypes.FindAsync(validId);
            entity.ShouldBeNull();
        }
        [Fact]
        public async Task DeleteInvice_NotValidId_ThrowNotFoundException()
        {
            var validId = 54;
            var commond = new DeleteInvoiceTypeCommond { InvoiceTypeId = validId };
            await Assert.ThrowsAsync<NotFoundException>(()=> _sut.Handle(commond, CancellationToken.None));
          
        }
    }
}
