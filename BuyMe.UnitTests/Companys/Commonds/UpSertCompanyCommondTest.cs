using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds;
using BuyMe.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace BuyMe.UnitTests.Companys.Commonds
{
    public class UpSertCompanyCommondTest : CommandTestBase
    {
       
        private readonly CreateEditCompanyCommondHandler _sut;
        public UpSertCompanyCommondTest()
        {
            _sut = new CreateEditCompanyCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task Handle_AddCompany_Return_CompanyId()
        {
            // Arrange
            var commond = new CreateEditCompanyCommond() { Name="CompanyThree",Country="Egypt"};
            // Act
            var result=  await _sut.Handle(commond, CancellationToken.None);
            // Assert
            var company =await buyMeDbContext.Companies.FindAsync(result);
            Assert.NotNull(company);

        }
        [Fact]
        public async Task Handle_UpdateComapny_Return_ThrowNotFoundException()
        {
            var invalidId = 20;
            var commond = new CreateEditCompanyCommond() { Id = invalidId, Name = "CompanyOne_1" };
            await Assert.ThrowsAsync<NotFoundException>(()=> _sut.Handle(commond,CancellationToken.None));
        }
        [Fact]
        public async Task Handle_UpdateComapny_Return_CompanyId()
        {
            var validId = 1;
            var commond =new  CreateEditCompanyCommond() { Id = validId, Name = "CompanyOne_1" };
            var result = await _sut.Handle(commond, CancellationToken.None);
            Assert.Equal(buyMeDbContext.Companies.First(a => a.Id == validId).Name, commond.Name);

        }

    }
}
