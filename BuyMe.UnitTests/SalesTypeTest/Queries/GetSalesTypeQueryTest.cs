using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.SalesType.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using Xunit;

namespace BuyMe.UnitTests.SalesTypeTest.Queries;
[Collection("QueryCollection")]
public class GetSalesTypeQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetSalesTypeQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "SalesType")]
    [InlineData(1, "SalesType4")]
    [InlineData(1, "SalesType35")]
    [InlineData(0, "SalesType36")]
    public async Task GetAllSalesType(int expect, string value)
    {
        var sut = new GetSalesTypeQuery.GetSalesTypeQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetSalesTypeQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
        res.count.ShouldBeEquivalentTo(expect);
    }
}