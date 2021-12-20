using AutoMapper;
using BuyMe.Application.Company.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.Company.Queries.GetCompanyQuery;

namespace BuyMe.UnitTests.Companys.Queries
{
    [Collection("QueryCollection")]
    public class GetCompanyQueryTest
    {
        private readonly BuyMeDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetCompany()
        {
            var companyId = 1;
            var sut = new GetCompanyQueryHandler(_context, _mapper);
            var result = await sut.Handle(new GetCompanyQuery(companyId), CancellationToken.None);
            result.ShouldBeOfType<CompanyDto>();
            result.ShouldNotBeNull();
        }
    }
}
