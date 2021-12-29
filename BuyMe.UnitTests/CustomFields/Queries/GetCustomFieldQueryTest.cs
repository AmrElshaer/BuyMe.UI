using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.CustomField.Queries.GetCustomFields;
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
using static BuyMe.Application.Company.Queries.GetCompanyQuery;
using static BuyMe.Application.CustomField.Queries.GetCustomFields.GetCustomFieldQuery;

namespace BuyMe.UnitTests.CustomFields.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomFieldQueryTest
    {
        private readonly BuyMeDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomFieldQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllCustomFields()
        {
            var sut = new GetCustomFieldQueryHandler(_context, new CurrentUserServiceTest(), _mapper);
            var result = await sut.Handle(new GetCustomFieldQuery(CustomCategoryModel.Product), CancellationToken.None);
            result.ShouldNotBeEmpty();
        }
    }
}