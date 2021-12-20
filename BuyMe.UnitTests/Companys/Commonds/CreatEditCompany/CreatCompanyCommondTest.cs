using BuyMe.Application.Company.Commonds;
using BuyMe.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BuyMe.UnitTests.Companys.Commonds.CreatEditCompany
{
    public class CreatCompanyCommondTest:CommandTestBase
    {
        // nameing GetById_UnknowId_ReturnsNotFoundResult
        private readonly CreateEditCompanyCommondHandler _sut;
        public CreatCompanyCommondTest()
        {
            _sut = new CreateEditCompanyCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task Handle_GivenValidData_CompanyId()
        {
            // Arrange
            var commond = new CreateEditCompanyCommond() { Name="Elshaer",Country="Egypt"};
            // Act
            var result=  await _sut.Handle(commond, CancellationToken.None);
            // Assert
            Assert.True(result!=0);

        }
    }
}
