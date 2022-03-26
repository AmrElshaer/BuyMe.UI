using AutoMapper;
using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Models;
using BuyMe.Persistence;
using BuyMe.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BuyMe.Application.Category.Queries.GetCategoriesQuery;

namespace BuyMe.UnitTests.CategoryTest.Queries
{
    [Collection("QueryCollection")]
    public class GetCategoriesQueryTest
    {
        private readonly BuyMeDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(2, "Categ")]
        [InlineData(1, "Categ4")]
        [InlineData(1, "Categ35")]
        [InlineData(0, "Categ36")]
        public async Task GetAllCategories(int expect, string value)
        {
            var sut = new GetCategoriesQueryHandler(_context, _mapper);
            var res = await sut.Handle(new GetCategoriesQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
            res.count.ShouldBeEquivalentTo(expect);
        }
    }
}
