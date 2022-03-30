using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Currency.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using Xunit;

namespace BuyMe.UnitTests.CurrencyTest.Queries;
[Collection("QueryCollection")]
public class GetCurrenciesQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetCurrenciesQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "Curriency")]
    [InlineData(1, "Curriency4")]
    [InlineData(1, "Curriency35")]
    [InlineData(0, "Curriency36")]
    public async Task GetAllCurriences(int expect, string value)
    {
        var sut = new GetCurrenciesQuery.GetCurrenciesQueryHandler(_context, _mapper);
        var res = await sut.Handle(new GetCurrenciesQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
        res.count.ShouldBeEquivalentTo(expect);
    }
}