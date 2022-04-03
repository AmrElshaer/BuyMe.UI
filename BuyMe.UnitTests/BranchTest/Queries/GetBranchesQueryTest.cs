using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Models;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.Branch.Queries.GetBranchesQuery;

namespace BuyMe.UnitTests.BranchTest.Queries;

[Collection("QueryCollection")]
public class GetBranchesQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetBranchesQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "Branch")]
    [InlineData(1, "Branch4")]
    [InlineData(1, "Branch35")]
    [InlineData(0, "Branch36")]
    public async Task GetAllBranches(int expect, string value)
    {
        var sut = new GetBranchesQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetBranchesQuery {DM = new DataManager {SearchValue = value}}
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}