using BuyMe.Application.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.Vendor.Commonds.Delete.DeletVendorCommond;
using BuyMe.UnitTests.Common;
using BuyMe.Application.Vendor.Commonds.Delete;
using Shouldly;

namespace BuyMe.UnitTests.VendorTest.Commonds
{
    public class DeletVentoryCommondTest: CommandTestBase
    {
        private readonly DeletVendorCommondHandler _sut;
        public DeletVentoryCommondTest()
        {
            this._sut = new DeletVendorCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task DeleteVendor_ValidId_Unit()
        {
            var validId = 1;
            var commond = new DeletVendorCommond { VendorId = validId };
            await _sut.Handle(commond, CancellationToken.None);
            var entity = await buyMeDbContext.Vendors.FindAsync(validId);
            entity.ShouldBeNull();
        }
        [Fact]
        public async Task DeleteVendor_NotValidId_ThrowNotFoundException()
        {
            var inValidId = 54;
            var commond = new DeletVendorCommond { VendorId = inValidId };
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));

        }
    }
}
