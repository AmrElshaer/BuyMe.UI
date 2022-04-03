using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.PurchaseType.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.PurchaseType.Queries.GetPurchaseTypesQuery;

namespace BuyMe.UnitTests.PurchaseTypeTest.Queries;

[Collection("QueryCollection")]
public class GetPurchasTypesQueriesTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetPurchasTypesQueriesTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "PurchType")]
    [InlineData(1, "PurchType4")]
    [InlineData(1, "PurchType35")]
    [InlineData(0, "PurchType36")]
    public async Task GetAllPurchaseorTypes(int expect, string value)
    {
        var sut = new GetPurchaseTypesQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetPurchaseTypesQuery {DM = new DataManager {SearchValue = value}}
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}