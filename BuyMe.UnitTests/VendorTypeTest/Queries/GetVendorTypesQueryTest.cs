using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.VendorType.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.VendorType.Queries.GetVendorTypesQuery;

namespace BuyMe.UnitTests.VendorTypeTest.Queries;

[Collection("QueryCollection")]
public class GetVendorTypesQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetVendorTypesQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "VendType")]
    [InlineData(1, "VendType4")]
    [InlineData(1, "VendType35")]
    [InlineData(0, "VendType36")]
    public async Task GetAllVendorTypes(int expect, string value)
    {
        var sut = new GetVendorTypesQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetVendorTypesQuery {DM = new DataManager {SearchValue = value}}
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}