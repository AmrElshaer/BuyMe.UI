using AutoMapper;
using BuyMe.Application.Branch.Queries;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Vendor.Queries;
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
using static BuyMe.Application.Branch.Queries.GetBranchesQuery;
using static BuyMe.Application.Vendor.Queries.GetVendorsQuery;

namespace BuyMe.UnitTests.BranchTest.Queries
{
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
            var res = await sut.Handle(new GetBranchesQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
            res.count.ShouldBeEquivalentTo(expect);
        }
    }
}
