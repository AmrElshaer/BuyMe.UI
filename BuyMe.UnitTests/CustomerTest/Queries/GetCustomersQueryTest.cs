using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Customer.Queries.GetCustomers;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;

namespace BuyMe.UnitTests.CustomerTest.Queries;
[Collection("QueryCollection")]
public class GetCustomersQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomersQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "Cust")]
    [InlineData(1, "Cust4")]
    [InlineData(1, "Cust35")]
    [InlineData(0, "Cust36")]
    public async Task GetAllCustomers(int expect, string value)
    {
        var sut = new GetCustomersQurery.GetCustomersQureryHandler(_context, _mapper);
        var res = await sut.Handle(new GetCustomersQurery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}