using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.VendorType.Commonds.CreatEdit;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.VendorType.Commonds.CreatEdit.CreatEditVendtorTypeCommond;

namespace BuyMe.UnitTests.VendorTypeTest.Commonds
{
    public class CreatEditVendorTypeCommondTest: CommandTestBase
    {

        private readonly CreatEditVendtorTypeCommondHandler _sut;
        public CreatEditVendorTypeCommondTest()
        {
            _sut = new CreatEditVendtorTypeCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task Handle_AddVendorType_Return_Id()
        {
            // Arrange
            var commond = new CreatEditVendtorTypeCommond() { Name = "VendType", Description = "VendDes" };
            // Act
            commond.Id = await _sut.Handle(commond, CancellationToken.None);
            // Assert
            var VendorType = await buyMeDbContext.VendorTypes.FindAsync(commond.Id);
            Assert.NotNull(VendorType);
            VendorType.Name.ShouldBeEquivalentTo(commond.Name);
            VendorType.Description.ShouldBeEquivalentTo(commond.Description);
            VendorType.Id.ShouldBeEquivalentTo(commond.Id);
        }
        [Fact]
        public async Task Handle_UpdateVendorType_InValidId_ThrowNotFoundException()
        {
            var invalidId = 20;
            var commond = new CreatEditVendtorTypeCommond() { Id = invalidId, Name = "VendorType" };
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
        }
        [Fact]
        public async Task Handle_UpdateVendorType_ValidId_VendorType()
        {
            var validId = 1;
            var commond = new CreatEditVendtorTypeCommond() { Id = validId, Name = "VendoType", Description = "VendDes" };
            await _sut.Handle(commond, CancellationToken.None);
            var entity = await buyMeDbContext.VendorTypes.FindAsync(validId);
            entity.Name.ShouldBeEquivalentTo(commond.Name);
            entity.Description.ShouldBeEquivalentTo(commond.Description);
            entity.Id.ShouldBeEquivalentTo(commond.Id);

        }
    }
}
