using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.SalesOrder.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using Xunit;

namespace BuyMe.UnitTests.SalesOrderTest.Queries;
[Collection("QueryCollection")]
public class GetSalesOrdersQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetSalesOrdersQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(1, "00000#1")]
    [InlineData(1, "00000#2")]
    [InlineData(0, "00000#3")]
    public async Task GetAllSalesOrders(int expect, string value)
    {
        var sut = new GetSalesOrdersQuery.GetSalesOrderQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetSalesOrdersQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
        res.count.ShouldBeEquivalentTo(expect);
    }
}