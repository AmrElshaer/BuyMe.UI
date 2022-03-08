using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Vendor.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.Vendor.Queries.GetVendorsQuery;

namespace BuyMe.UnitTests.VendorTest.Queries
{
    [Collection("QueryCollection")]
    public class GetVendorsQueryTest
    {
        private readonly BuyMeDbContext _context;
        private readonly IMapper _mapper;

        public GetVendorsQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(2, "Vend")]
        [InlineData(1, "Vend4")]
        [InlineData(1, "Vend35")]
        [InlineData(0, "Vend36")]
        public async Task GetAllVendors(int expect, string value)
        {
            var sut = new GetVendorsQueryHandler(_context, _mapper);
            var res = await sut.Handle(new GetVendorsQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
            res.count.ShouldBeEquivalentTo(expect);
        }
    }
}
