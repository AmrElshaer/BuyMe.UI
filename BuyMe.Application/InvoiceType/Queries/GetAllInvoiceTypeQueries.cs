using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvoiceTypeDomain = BuyMe.Domain.Entities.InvoiceType;

namespace BuyMe.Application.InvoiceType.Queries
{
    public  class GetAllInvoiceTypeQueries:BaseRequestQuery,IRequest<QueryResult<InvoiceTypeDto>>
    {
       

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
        public static IQueryable<InvoiceTypeDomain> ApplyFiliter(this IQueryable<InvoiceTypeDomain> dataSource, GetAllInvoiceTypeQueries  request)
        {
            if (DataManagerExtension.HasSearchValue(request)) dataSource = dataSource.Where(a => a.InvoiceTypeName.Contains(request.DM.SearchValue));
            return dataSource;
        }
        
    }
}
