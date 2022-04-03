using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.UnitOfMeasure.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;

namespace BuyMe.UnitTests.UnitOfMeasureTest.Queries;

[Collection("QueryCollection")]
public class GetUOMQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetUOMQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "UOM")]
    [InlineData(1, "UOM4")]
    [InlineData(1, "UOM35")]
    [InlineData(0, "UOM36")]
    public async Task GetAllUOM(int expect, string value)
    {
        var sut = new GetUOMQuery.GetUOMsQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetUOMQuery {DM = new DataManager {SearchValue = value}}
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}