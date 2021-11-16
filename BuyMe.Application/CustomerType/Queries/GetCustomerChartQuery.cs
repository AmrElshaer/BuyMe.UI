using BuyMe.Application.Category.Queries;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomerType.Queries
{
    public class GetCustomerChartQuery:IRequest<IList<ChartData>>
    {
        public class GetCustomerChartQueryHandler : IRequestHandler<GetCustomerChartQuery, IList<ChartData>>
        {
            private readonly IBuyMeDbContext context;
            private readonly ICurrentUserService currentUserService;

            public GetCustomerChartQueryHandler(IBuyMeDbContext context, ICurrentUserService currentUserService)
            {
                this.context = context;
                this.currentUserService = currentUserService;
            }
            public async Task<IList<ChartData>> Handle(GetCustomerChartQuery request, CancellationToken cancellationToken)
            {
                var charData = await this.context.CustomerTypes.Include(a => a.Customers).Where(a => a.CompanyId == currentUserService.CompanyId)
                    .Select(a => new ChartData() { XValue = a.CustomerTypeName, YValue = a.Customers.Count() }).ToListAsync();
                return charData;
            }
        }
    }
}
