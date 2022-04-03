using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BuyMe.Application.Company.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using FluentAssertions;
using Xunit;
using static BuyMe.Application.Company.Queries.GetCompanyByNameQuery;

namespace BuyMe.UnitTests.Companys.Queries;

[Collection("QueryCollection")]
public class GetCompanyByNameQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetCompanyByNameQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetAllCompanies()
    {
        var sut = new GetCompanyByNameQueryHandler(_context, _mapper);
        var result = await sut.Handle(new GetCompanyByNameQuery("CompanyTwo"), CancellationToken.None);
        result.Should().NotBeNull();
    }
}