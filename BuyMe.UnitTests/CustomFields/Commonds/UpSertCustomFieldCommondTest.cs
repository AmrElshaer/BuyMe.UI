using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomField.Commonds.UpSertCustomField;
using BuyMe.UnitTests.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.CustomField.Commonds.UpSertCustomField.UpSertCustomerFieldCommond;

namespace BuyMe.UnitTests.CustomFields.Commonds
{
    public class UpSertCustomFieldCommondTest : CommandTestBase
    {
        private readonly UpSertCustomerFieldCommondHandler _sut;

        public UpSertCustomFieldCommondTest()
        {
            _sut = new UpSertCustomerFieldCommondHandler(buyMeDbContext, new CurrentUserServiceTest());
        }

        [Fact]
        public async Task Handle_AddCustomField_ReturnFieldId()
        {
            // Arrange
            var commond = new UpSertCustomerFieldCommond() { FieldName = "CustomName", FieldType = "Text", Category = CustomCategoryModel.Product };
            // Act
            var result = await _sut.Handle(commond, CancellationToken.None);
            // Assert
            var field = await buyMeDbContext.CustomFields.FindAsync(result);
            Assert.NotNull(field);
        }

        [Fact]
        public async Task Handle_UpdateCustomField_ReturnCustomField()
        {
            // Arrange
            int validId = 1;
            var commond = new UpSertCustomerFieldCommond() { Id = validId, FieldName = "CustomName", FieldType = "number", Category = CustomCategoryModel.Product };
            // Act
            var result = await _sut.Handle(commond, CancellationToken.None);
            // Assert
            Assert.Equal(buyMeDbContext.CustomFields.First(a => a.Id == validId).FieldType, commond.FieldType);
        }

        [Fact]
        public async Task Handle_UpdateCustomField_ReturnNotFoundException()
        {
            // Arrange
            int invalidId = 200;
            var commond = new UpSertCustomerFieldCommond() { Id = invalidId, FieldName = "CustomName", FieldType = "Text", Category = CustomCategoryModel.Product };
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
        }
    }
}