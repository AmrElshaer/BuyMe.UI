using AutoMapper;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Invoice.Queries;
using BuyMe.Application.PaymentReceive.Queries;
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
using static BuyMe.Application.Invoice.Queries.GetAllInvoicesQuery;
using static BuyMe.Application.PaymentReceive.Queries.GetAllPaymentReceiveQuery;

namespace BuyMe.UnitTests.PaymentReceiveTest.Queries.GetAllPaymentReceive
{
    [Collection("QueryCollection")]
    public class GetAllPaymentReceiveQueryTest
    {
        private readonly BuyMeDbContext _context;
        private readonly IMapper _mapper;
        private readonly GetAllPaymentReceiveQueryHandler _sut;
        public GetAllPaymentReceiveQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _sut = new GetAllPaymentReceiveQueryHandler(_context, _mapper);
        }
        [Theory]
        [InlineData(1, "00001#PAYRCV")]
        [InlineData(3, "PAYRCV")]
        [InlineData(0, "00005#PAYRCV")]
        public async Task GetAllInvoiceTypes(int expect, string value)
        {
            var res = await _sut.Handle(new GetAllPaymentReceiveQuery() { DM = new DataManager() { SearchValue = value } }
            , CancellationToken.None);
            res.count.ShouldBeEquivalentTo(expect);
        }
    }
}
