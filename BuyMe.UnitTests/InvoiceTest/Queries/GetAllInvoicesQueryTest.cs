using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Invoice.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.Invoice.Queries.GetAllInvoicesQuery;

namespace BuyMe.UnitTests.InvoiceTest.Queries;

[Collection("QueryCollection")]
public class GetAllInvoicesQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;
    private readonly GetAllInvoicesQueryHandler _sut;

    public GetAllInvoicesQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
        _sut = new GetAllInvoicesQueryHandler(_context, _mapper);
    }

    [Theory]
    [InlineData(1, "00001#INV")]
    [InlineData(3, "INV")]
    [InlineData(0, "00005#INV")]
    [InlineData(2, "00001#ship")]
    public async Task GetAllInvoiceTypes(int expect, string value)
    {
        var res = await _sut.Handle(new GetAllInvoicesQuery {DM = new DataManager {SearchValue = value}}
            , CancellationToken.None);
        res.count.Should().Be(expect);
    }
}