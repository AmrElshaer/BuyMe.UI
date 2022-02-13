using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using BuyMe.Application.PaymentType.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PaymentTypeDomain = BuyMe.Domain.Entities.PaymentType;
namespace BuyMe.Application.PaymentType.Queries
{
    public class GetAllPaymentTypeQuery:BaseRequestQuery,IRequest<QueryResult<PaymentTypeDto>>
    {
      
        public class GetAllPaymemntTypeQueriesHandler : IRequestHandler<GetAllPaymentTypeQuery, QueryResult<PaymentTypeDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly IMapper _mapper;

            public GetAllPaymemntTypeQueriesHandler(IBuyMeDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QueryResult<PaymentTypeDto>> Handle(GetAllPaymentTypeQuery request, CancellationToken cancellationToken)
            {
                var dataSource = _context.PaymentTypes.ApplyFiliter(request).ApplySkip(request).ApplyTake(request);
                var count = dataSource.Count();
                var paymentTypes = await dataSource.OrderByDescending(a => a.PaymentTypeId).ToListAsync();
                return new QueryResult<PaymentTypeDto>() { count = count, result = _mapper.Map<IList<PaymentTypeDto>>(paymentTypes) };
            }
        }
    }
}
public static class PaymentTypeExtension
{
    public static IQueryable<PaymentTypeDomain> ApplyFiliter(this IQueryable<PaymentTypeDomain> dataSource, GetAllPaymentTypeQuery request)
    {
        return DataManagerExtension.HasSearchValue(request)? 
            dataSource.Where(a => a.PaymentTypeName.Contains(request.DM.SearchValue)):dataSource;
    }
}