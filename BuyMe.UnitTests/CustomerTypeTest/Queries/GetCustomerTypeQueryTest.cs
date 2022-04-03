using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomerType.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;

namespace BuyMe.UnitTests.CustomerTypeTest.Queries;
[Collection("QueryCollection")]
public class GetCustomerTypeQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerTypeQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "CustomerType")]
    [InlineData(1, "CustomerType4")]
    [InlineData(1, "CustomerType35")]
    [InlineData(0, "CustomerType36")]
    public async Task GetAllCustomerTypes(int expect, string value)
    {
        var sut = new GetCustomersTypeQuery.GetCustomersTypeQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetCustomersTypeQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}