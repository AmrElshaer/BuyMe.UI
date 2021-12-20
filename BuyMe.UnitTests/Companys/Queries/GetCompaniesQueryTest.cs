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

namespace BuyMe.UnitTests.Companys.Queries
{
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
        [Fact]
        public async Task GetAllCompanies()
        {
            var sut = new GetCompaniesQueryHandler(_context,_mapper);
            var result= await sut.Handle(new GetCompaniesQuery(), CancellationToken.None);
            result.ShouldBeOfType<QueryResult<CompanyDto>>();
            result.result.Count.ShouldBeGreaterThanOrEqualTo(1);
        }
    }
}
