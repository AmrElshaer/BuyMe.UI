using AutoMapper;
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

namespace BuyMe.Application.Category.Queries
{
    public class GetCategoryChartQuery : IRequest<IList<ChartData>>
    {

        public class GetCategoryChartQueryHandler : IRequestHandler<GetCategoryChartQuery, IList<ChartData>>
        {
            private readonly IBuyMeDbContext context;
            private readonly ICurrentUserService currentUserService;

            public GetCategoryChartQueryHandler(IBuyMeDbContext context,ICurrentUserService currentUserService)
            {
                this.context = context;
                this.currentUserService = currentUserService;
            }
            public async Task<IList<ChartData>> Handle(GetCategoryChartQuery request, CancellationToken cancellationToken)
            {
                var charData=await this.context.Categories.Include(a => a.Products).Where(a=>a.CompanyId==currentUserService.CompanyId)
                    .Select(a => new ChartData() {  XValue=a.CategoryName, YValue=a.Products.Count()}).ToListAsync();
                return charData;
            }
        }
    }
}
