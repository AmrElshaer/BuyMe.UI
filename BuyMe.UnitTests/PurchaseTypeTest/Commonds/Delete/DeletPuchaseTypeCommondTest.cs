using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.PurchaseType.Commonds.Delete;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.PurchaseType.Commonds.Delete.DeletPurchaseTypeCommond;

namespace BuyMe.UnitTests.PurchaseTypeTest.Commonds.Delete
{
    public class DeletPuchaseTypeCommondTest : CommandTestBase
    {
        private readonly DeletPurchaseTypeCommondHandler _sut;
        public DeletPuchaseTypeCommondTest()
        {
            this._sut = new DeletPurchaseTypeCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task DeletePurchaseType_ValidId_Unit()
        {
            var validId = 1;
            var commond = new DeletPurchaseTypeCommond { PurchaseTypeId = validId };
            await _sut.Handle(commond, CancellationToken.None);
            var entity = await buyMeDbContext.PurchaseTypes.FindAsync(validId);
            entity.ShouldBeNull();
        }
        [Fact]
        public async Task DeletePurchase_NotValidId_ThrowNotFoundException()
        {
            var inValidId = 54;
            var commond = new DeletPurchaseTypeCommond { PurchaseTypeId = inValidId };
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));

        }
    }
}
