using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Company.Commonds.DeleteCompany;
using BuyMe.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.Company.Commonds.DeleteCompany.DeleteCompanyCommond;

namespace BuyMe.UnitTests.Companys.Commonds
{
    public class DeleteCompanyCommondTest: CommandTestBase
    {
        private readonly DeleteCompanyCommondHandler _sut;
        public DeleteCompanyCommondTest()
        {
            _sut = new DeleteCompanyCommondHandler(buyMeDbContext);
        }
        [Fact]
        public async Task Handle_DeleteCompany_Return_ThrowNotFoundExpception()
        {
            var invalidId = 20;
            var commond = new DeleteCompanyCommond() { CompanyId = invalidId };
            await Assert.ThrowsAsync<NotFoundException>(()=>_sut.Handle(commond,CancellationToken.None));
        }
        [Fact]
        public async Task Handle_DeleteCompany_Return_DeleteSuccess()
        {
            var validId = 2;
            var commond = new DeleteCompanyCommond() { CompanyId = validId };
            await _sut.Handle(commond, CancellationToken.None);
            var company =await buyMeDbContext.Companies.FindAsync(validId);
            Assert.Null(company);
        }
    }
}
