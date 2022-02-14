using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.InvoiceType.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.PaymentReceive.Queries
{
    public class GetAllPaymentReceiveQuery: BaseRequestQuery,IRequest<QueryResult<PaymentReceiveDto>>
    {
        public class GetAllPaymentReceiveQueryHandler : IRequestHandler<GetAllPaymentReceiveQuery, QueryResult<PaymentReceiveDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetAllPaymentReceiveQueryHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<QueryResult<PaymentReceiveDto>> Handle(GetAllPaymentReceiveQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.PaymentReceives.Include(a=>a.PaymentType).Include(a=>a.Invoice)
                    .ApplyFiliter(request).ApplySkip(request).ApplyTake(request);
                var count = dataSource.Count();
                var invoiceTypes = await dataSource.OrderByDescending(a => a.PaymentReceiveId).ToListAsync();
                return new QueryResult<PaymentReceiveDto>() { count = count, result = _mapper.Map<IList<PaymentReceiveDto>>(invoiceTypes) };
            }
        }
    }
    public static class PaymentReceiveExtension
    {
        public static IQueryable<Domain.Entities.PaymentReceive> ApplyFiliter(this IQueryable<Domain.Entities.PaymentReceive> dataSource, GetAllPaymentReceiveQuery request)
        {
            return DataManagerExtension.HasSearchValue(request)?
                dataSource.Where(a => a.PaymentReceiveName.Contains(request.DM.SearchValue)):dataSource;
            
        }

    }
}
