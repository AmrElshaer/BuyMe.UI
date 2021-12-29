using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds.DeleteCompany;
using BuyMe.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BuyMe.Application.Company.Commonds.DeleteCompany.DeleteCompanyCommond;
using Xunit;
using static BuyMe.Application.CustomField.Commonds.DeleteCustomField.DeleteCustomFieldCommond;
using BuyMe.UnitTests.Common;
using BuyMe.Application.CustomField.Commonds.DeleteCustomField;
using BuyMe.Application.Common.Models;
using Shouldly;
using BuyMe.Domain.Entities;

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
        public async Task Handle_DeleteCustomField_Return_ThrowNotFoundExpception()
        {
            var invalidId = 20;
            var commond = new DeleteCustomFieldCommond() { CustomFieldId = invalidId };
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(commond, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_DeleteCustomField_Return_DeleteSuccess()
        {
            // arrange
            var validId = 1;
            var fieldName = (await GetCustomField(validId))?.FieldName;
            var commond = new DeleteCustomFieldCommond() { CustomFieldId = validId };
            // act
            await _sut.Handle(commond, CancellationToken.None);
            var field = await GetCustomField(validId);
            var fieldData = buyMeDbContext.CustomFieldDatas.Where(a => a.Category == CustomCategoryModel.Product && a.Value.Contains(fieldName)).ToList();
            // assert
            fieldData.ShouldBeEmpty();
            field.ShouldBeNull();
        }

        private async Task<CustomField> GetCustomField(int fieldId)
        {
            return await buyMeDbContext.CustomFields.FindAsync(fieldId);
        }
    }
}