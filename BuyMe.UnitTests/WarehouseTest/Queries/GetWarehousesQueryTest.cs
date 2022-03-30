using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.WarehouseINV.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using Xunit;

namespace BuyMe.UnitTests.WarehouseTest.Queries;
[Collection("QueryCollection")]
public class GetWarehousesQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetWarehousesQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "Warehouse")]
    [InlineData(1, "Warehouse4")]
    [InlineData(1, "Warehouse35")]
    [InlineData(0, "Warehouse36")]
    public async Task GetAllCategories(int expect, string value)
    {
        var sut = new GetWarehousesQuery.GetWarehousesQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetWarehousesQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
        res.count.ShouldBeEquivalentTo(expect);
    }
}