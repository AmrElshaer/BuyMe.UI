using BuyMe.Application.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.VendorType.Commonds.Delete.DeletVendorTypeCommond;
using BuyMe.UnitTests.Common;
using BuyMe.Application.VendorType.Commonds.Delete;
using Shouldly;

namespace BuyMe.UnitTests.VendorTypeTest.Commonds
{
    public class DeletVentoryTypeCommondTest: CommandTestBase
    {
        private readonly DeletVendorTypeCommondHandler _sut;
        public DeletVentoryTypeCommondTest()
        {
            this._sut = new DeletVendorTypeCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task DeleteVendorType_ValidId_Unit()
        {
            var validId = 1;
            var commond = new DeletVendorTypeCommond { VendorTypeId = validId };
            await _sut.Handle(commond, CancellationToken.None);
            var entity = await buyMeDbContext.VendorTypes.FindAsync(validId);
            entity.ShouldBeNull();
        }
        [Fact]
        public async Task DeleteVendor_NotValidId_ThrowNotFoundException()
        {
            var inValidId = 54;
            var commond = new DeletVendorTypeCommond { VendorTypeId = inValidId };
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));

        }
    }
}
