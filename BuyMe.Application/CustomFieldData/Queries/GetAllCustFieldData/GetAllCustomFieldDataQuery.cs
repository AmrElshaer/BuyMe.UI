using AutoMapper;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.CustomFieldData.Queries.GetAllCustFieldData
{
    public class GetAllCustomFieldDataQuery: IRequest<IList<CustomFieldDataDto>>
    {
        public string Category { get; init; }
        public GetAllCustomFieldDataQuery(string category)
        {
            this.Category = category;
        }
        public class GetCustomFieldDataQueryHandler : IRequestHandler<GetAllCustomFieldDataQuery, IList<CustomFieldDataDto>>
        {
            private readonly IBuyMeDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            private readonly IMapper mapper;

            public GetCustomFieldDataQueryHandler(IBuyMeDbContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUserService = currentUserService;
                this.mapper = mapper;
            }

            public async Task<IList<CustomFieldDataDto>> Handle(GetAllCustomFieldDataQuery request, CancellationToken cancellationToken)
            {
                var customFieldDatas = await _context.CustomFieldDatas.Where(a => a.CompanyId == _currentUserService.CompanyId &&
                a.Category == request.Category).ToListAsync();
                return mapper.Map<IList<CustomFieldDataDto>>(customFieldDatas);
            }


        }
    }
}
