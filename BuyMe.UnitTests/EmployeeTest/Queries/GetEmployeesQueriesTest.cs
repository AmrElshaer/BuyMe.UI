using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Employee.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using Xunit;

namespace BuyMe.UnitTests.EmployeeTest.Queries;
[Collection("QueryCollection")]
public class GetEmployeesQueriesTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeesQueriesTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "firstName")]
    [InlineData(1, "lastName2")]
    [InlineData(1, "firstName2")]
    [InlineData(0, "nikof")]
    public async Task GetAllEmployeeies(int expect, string value)
    {
        var sut = new GetEmployeesQuery.GetEmployeesQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetEmployeesQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
        res.count.ShouldBeEquivalentTo(expect);
    }
}