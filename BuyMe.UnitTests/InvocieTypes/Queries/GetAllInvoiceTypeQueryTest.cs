using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.InvoiceType.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.InvoiceType.Queries.GetAllInvoiceTypeQueries;

namespace BuyMe.UnitTests.InvocieTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetAllInvoiceTypeQueryTest
    {
        private readonly BuyMeDbContext _context;
        private readonly IMapper _mapper;

        public GetAllInvoiceTypeQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(2,"Pay")]
        [InlineData(1, "Pay34")]
        [InlineData(1, "Pay35")]
        [InlineData(0, "Pay39")]
        public async Task GetAllInvoiceTypes(int expect ,string value)
        {
            var sut = new GetAllInvoiceTypeQueriesHandler(_context, _mapper);
            var res = await sut.Handle(new GetAllInvoiceTypeQueries() {DM= new DataManager() { SearchValue = value } }
            , CancellationToken.None);
            res.count.ShouldBeEquivalentTo(expect);
        }
    }
}
