using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Company.Queries;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.Company.Queries.GetCompaniesQuery;

namespace BuyMe.UnitTests.Companys.Queries;

[Collection("QueryCollection")]
public class GetCompaniesQueryTest
{
    private readonly BuyMeDbContext _context;
    private readonly IMapper _mapper;

    public GetCompaniesQueryTest(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }
    [Theory]
    [InlineData(2, "Company")]
    [InlineData(1, "CompanyOne")]
    [InlineData(1, "CompanyTwo")]
    [InlineData(0, "CompanyOne58")]
    public async Task GetAllCompanies(int expect, string value)
    {
        var sut = new GetCompaniesQueryHandler(_context,_mapper);
        var res= await sut.Handle(new GetCompaniesQuery(){ DM = new DataManager() { SearchValue = value }}
            , CancellationToken.None);
        res.count.ShouldBeEquivalentTo(expect);
    }
}

