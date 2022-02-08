using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.Employee.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InvoiceTypeDomain= BuyMe.Domain.Entities.InvoiceType;

namespace BuyMe.Application.InvoiceType.Queries
{
    public  class GetAllInvoiceTypeQueries:IRequest<QueryResult<InvoiceTypeDto>>
    {
        public DataManager DM { get; set; }

        public GetAllInvoiceTypeQueries()
        {
            DM ??= new DataManager();
        }

        public class GetAllInvoiceTypeQueriesHandler : IRequestHandler<GetAllInvoiceTypeQueries, QueryResult<InvoiceTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetAllInvoiceTypeQueriesHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<InvoiceTypeDto>> Handle(GetAllInvoiceTypeQueries request, CancellationToken cancellationToken)
            {
                var dataSource = _context.InvoiceTypes.ApplyFiliter(request).ApplySkip(request).ApplyTake(request);
                var count = dataSource.Count();
                var invoiceTypes = await dataSource.OrderByDescending(a => a.InvoiceTypeId).ToListAsync();
                return new QueryResult<InvoiceTypeDto>() { count = count, result = _mapper.Map<IList<InvoiceTypeDto>>(invoiceTypes) };
            }

           
        }
    }
    public static class InvoiceTypeExtension
    {
       

        public static IQueryable<InvoiceTypeDomain> ApplyTake(this IQueryable<InvoiceTypeDomain> dataSource,GetAllInvoiceTypeQueries request)
        {
            if (HasTakeValue(request)) dataSource = dataSource.Take(request.DM.Take.Value);
            return dataSource;
        }

        public static IQueryable<InvoiceTypeDomain> ApplySkip(this IQueryable<InvoiceTypeDomain> dataSource, GetAllInvoiceTypeQueries request)
        {
            if (HasSkipValue(request)) dataSource = dataSource.Skip(request.DM.Skip.Value);
            return dataSource;
        }

        public static IQueryable<InvoiceTypeDomain> ApplyFiliter(this IQueryable<InvoiceTypeDomain> dataSource, GetAllInvoiceTypeQueries  request)
        {
            if (HasSearchValue(request)) dataSource = dataSource.Where(a => a.InvoiceTypeName.Contains(request.DM.SearchValue));
            return dataSource;
        }

        private static bool HasSearchValue(GetAllInvoiceTypeQueries request)
        {
            return !string.IsNullOrEmpty(request.DM.SearchValue);
        }

        private static bool HasTakeValue(GetAllInvoiceTypeQueries request)
        {
            return !(request.DM.Take == null || request.DM.Take == 0);
        }

        private static bool HasSkipValue(GetAllInvoiceTypeQueries request)
        {
            return !(request.DM.Skip == null || request.DM.Skip == 0);
        }
    }
}
