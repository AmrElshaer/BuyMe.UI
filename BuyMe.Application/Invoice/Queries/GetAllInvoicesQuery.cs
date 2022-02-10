using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Invoice.Queries;
using BuyMe.Application.InvoiceType.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InvoiceDomain = BuyMe.Domain.Entities.Invoice;
namespace BuyMe.Application.Invoice.Queries
{
    public  class GetAllInvoicesQuery:IRequest<QueryResult<InvoiceDto>>
    {
        public DataManager DM { get; set; }

        public GetAllInvoicesQuery()
        {
            DM ??= new DataManager();
        }
        public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, QueryResult<InvoiceDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetAllInvoicesQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<QueryResult<InvoiceDto>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.Invoices.Include(a=>a.Shipment).Include(a=>a.InvoiceType).ApplyFiliter(request).ApplySkip(request).ApplyTake(request);
                var count = dataSource.Count();
                var invoices = await dataSource.OrderByDescending(a => a.InvoiceId).ToListAsync();
                return new QueryResult<InvoiceDto>() { count = count, result = _mapper.Map<IList<InvoiceDto>>(invoices) };
            }
        }
    }
    public static class InvoiceExtension
    {


        public static IQueryable<InvoiceDomain> ApplyTake(this IQueryable<InvoiceDomain> dataSource, GetAllInvoicesQuery request)
        {
            if (HasTakeValue(request)) dataSource = dataSource.Take(request.DM.Take.Value);
            return dataSource;
        }

        public static IQueryable<InvoiceDomain> ApplySkip(this IQueryable<InvoiceDomain> dataSource, GetAllInvoicesQuery request)
        {
            if (HasSkipValue(request)) dataSource = dataSource.Skip(request.DM.Skip.Value);
            return dataSource;
        }

        public static IQueryable<InvoiceDomain> ApplyFiliter(this IQueryable<InvoiceDomain> dataSource, GetAllInvoicesQuery request)
        {
            if (HasSearchValue(request)) dataSource = dataSource.Where(a => a.InvoiceName.Contains(request.DM.SearchValue)
            ||a.Shipment.ShipmentName.Contains(request.DM.SearchValue));
            return dataSource;
        }

        private static bool HasSearchValue(GetAllInvoicesQuery request)
        {
            return !string.IsNullOrEmpty(request.DM.SearchValue);
        }

        private static bool HasTakeValue(GetAllInvoicesQuery request)
        {
            return !(request.DM.Take == null || request.DM.Take == 0);
        }

        private static bool HasSkipValue(GetAllInvoicesQuery request)
        {
            return !(request.DM.Skip == null || request.DM.Skip == 0);
        }
    }
}
