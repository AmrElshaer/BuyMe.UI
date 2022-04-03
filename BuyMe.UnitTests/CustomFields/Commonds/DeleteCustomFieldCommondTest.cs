using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomField.Commonds.DeleteCustomField;
using BuyMe.Domain.Entities;
using BuyMe.UnitTests.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.CustomField.Commonds.DeleteCustomField.DeleteCustomFieldCommond;

namespace BuyMe.UnitTests.CustomFields.Commonds
{
    [Collection("QueryCollection")]
    public class DeleteCustomFieldCommondTest : CommandTestBase
    {
        private readonly DeleteCustomFieldCommondHandler _sut;

        public DeleteCustomFieldCommondTest(QueryTestFixture fixture)
        {
            _sut = new DeleteCustomFieldCommondHandler(buyMeDbContext, fixture.Mapper);
        }

        [Fact]
        public async Task DeleteCustomField_InValidId_ThrowNotFoundExpception()
        {
            var invalidId = 20;
            await Assert.ThrowsAsync<NotFoundException>(() => DeleteCustomField(invalidId));
        }

        [Fact]
        public async Task DeleteCustomField_ValidId_DeleteSuccess()
        {
            var validId = 3;
            await DeleteCustomField(validId);
            var field = await GetCustomField(validId);
            field.Should().BeNull();
        }

        [Fact]
        public async Task DeleteCustomFieldWithFieldData_DeleteSuccess()
        {
            var validId = 1;
            var fieldName = (await GetCustomField(validId))?.FieldName;
            await DeleteCustomField(validId);
            var fieldData = buyMeDbContext.CustomFieldDatas.Where(a => a.Category == CustomCategoryModel.Product && a.Value.Contains(fieldName)).ToList();
            fieldData.Should().BeEmpty();
        }

        private async Task DeleteCustomField(int id)
        {
            var commond = new DeleteCustomFieldCommond() { CustomFieldId = id };

            await _sut.Handle(commond, CancellationToken.None);
        }

        private async Task<CustomField> GetCustomField(int fieldId)
        {
            return await buyMeDbContext.CustomFields.FindAsync(fieldId);
        }
    }
}