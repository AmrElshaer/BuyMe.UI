using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.PaymentType.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.PaymentType.Queries.GetAllPaymentTypeQuery;

namespace BuyMe.UnitTests.PaymentTypeTest.Queries.GetAllPaymentTypesTest;

[Collection("QueryCollection")]
public class GetAllPaymentTypeQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPaymentTypeQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Theory]
    [InlineData(2, "Pay")]
    [InlineData(1, "Pay4")]
    [InlineData(1, "Pay35")]
    [InlineData(0, "Pay36")]
    public async Task GetAllPaymentTypes(int expect, string value)
    {
        var sut = new GetAllPaymemntTypeQueriesHandler(_context, _mapper);
        var res = await sut.Handle(new GetAllPaymentTypeQuery {DM = new DataManager {SearchValue = value}}
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}