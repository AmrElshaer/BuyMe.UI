using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.CustomField.Queries.GetCustomFields;
using BuyMe.Application.InvoiceType.Queries;
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
using static BuyMe.Application.CustomField.Queries.GetCustomFields.GetCustomFieldQuery;
using static BuyMe.Application.InvoiceType.Queries.GetAllInvoiceTypeQueries;

namespace BuyMe.UnitTests.InvocieTypes.Queries
{
    [Collection("QueryCollection")]
    public class GetAllInvoiceTypeQueryTest
    {
        private readonly BuyMeDbContext _context;
        private readonly IMapper _mapper;

        public GetAllInvoiceTypeQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(2,"Inv")]
        [InlineData(1, "Inv34")]
        [InlineData(1, "Inv35")]
        [InlineData(0, "Inv39")]
        public async Task GetAllInvoiceTypes(int expect ,string value)
        {
            var sut = new GetAllInvoiceTypeQueriesHandler(_context, _mapper);
            var res = await sut.Handle(new GetAllInvoiceTypeQueries() {DM= new DataManager() { SearchValue = value } }
            , CancellationToken.None);
            res.count.ShouldBeEquivalentTo(expect);
        }
    }
}
